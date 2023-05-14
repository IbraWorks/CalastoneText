using System.Text;
using System.Text.RegularExpressions;

namespace CalastoneTest.Strategies;

public class ThreeOrMoreWordsFilter : IFilterStrategy
{
    public string ApplyFilter(string word)
    {
        return word.Length >= 3 ? word : "";
    }
}