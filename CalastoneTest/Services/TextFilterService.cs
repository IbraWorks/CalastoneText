using System.Text;
using System.Text.RegularExpressions;
using CalastoneTest.Strategies;

namespace CalastoneTest.Services;

public class TextFilterService : ITextFilterService
{
    private readonly IFilterStrategy _filterStrategy;

    public TextFilterService(IFilterStrategy filterStrategy)
    {
        _filterStrategy = filterStrategy;
    }
    public string FilterText(string text)
    {
        // because the text is inconsistent with spaces after punctuation (e.g.: conversation?'So)
        // we cannot do a simple text.Split(" ") as easily. Strategy therefore is to Regex match
        // on full whole words (not including punctuation characters or numbers). We iterate through matches
        // keeping track of the index of the match and the last matched index. we use these indexes
        // to check if there are any non-word characters between the current match and the last match
        // and append those non-word characters.
        var matches = Regex.Matches(text, @"\b[a-zA-Z]+\b") // Match whole words
            .ToArray(); 

        var filteredTextStringBuilder = new StringBuilder();
        var lastMatchIndex = 0;

        foreach (var match in matches)
        {
            if (match.Index > lastMatchIndex)
            {
                // if the current match index is greater than the last match index
                // that means there are non-word characters in between.
                // we need to append them before filtering on the match
                var nonWordChars = text.Substring(lastMatchIndex, match.Index - lastMatchIndex);
                filteredTextStringBuilder.Append(nonWordChars);
            }
            
            var result = _filterStrategy.ApplyFilter(match.Value);
            filteredTextStringBuilder.Append(result);
            
            // move the lastMatchIndex to the end of the word.
            lastMatchIndex = match.Index + match.Length;
        }
        
        // need to check if if there any non-word characters left after the last match found (e.g. a full stop)
        // if there are we append them.
        if (lastMatchIndex < text.Length)
        {
            var remainingChars = text.Substring(lastMatchIndex);
            filteredTextStringBuilder.Append(remainingChars);
        }

        return filteredTextStringBuilder.ToString();        
    }
}