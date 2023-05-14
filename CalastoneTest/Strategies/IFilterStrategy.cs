using System.Text;
using System.Text.RegularExpressions;

namespace CalastoneTest.Strategies;

public interface IFilterStrategy
{
    string ApplyFilter(string word);
}