namespace CalastoneTest.Strategies;

public class VowelsInMiddleOfWordFilter : IFilterStrategy
{
    private static readonly HashSet<char> Vowels = new()
    {
        'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'
    };
    public string ApplyFilter(string word)
    {
        if (word.Length <= 2)
        {
            return word;
        }
        // if the word is even, there is no real middle, we take two characters to filter out
        var length = word.Length % 2 == 0 ? 2 : 1;
        var middle = word.Substring(word.Length / 2 - 1, 2);
        return middle.Any(letter => Vowels.Contains(letter)) ? "" : word;
    }
}