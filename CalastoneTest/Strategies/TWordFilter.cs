namespace CalastoneTest.Strategies;

public class TWordFilter : IFilterStrategy
{
    public string ApplyFilter(string word)
    {
        if (word.Contains('t'))
        {
            return "";
        }

        return word;
    }
}