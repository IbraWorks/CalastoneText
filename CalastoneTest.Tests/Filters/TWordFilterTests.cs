using CalastoneTest.Strategies;
using FluentAssertions;

namespace CalastoneTest.Tests.Filters;

public class TWordFilterTests
{
    private readonly TWordFilter _sut;

    public TWordFilterTests()
    {
        _sut = new TWordFilter();
    }
    
    [Fact]
    public void GivenWordContainsLetterT_WhenFilterApplied_ReturnsEmptyString()
    {
        const string word = "Test";
        var result = _sut.ApplyFilter(word);
        result.Should().BeEmpty();
    }

    [Fact]
    public void GivenWordDoesNotContainLetterT_WhenFilterApplied_ReturnsSameWord()
    {
        const string word = "Hello";
        var result = _sut.ApplyFilter(word);
        result.Should().Be(word);
    }
}