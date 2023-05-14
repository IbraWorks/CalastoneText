using CalastoneTest.Strategies;
using FluentAssertions;

namespace CalastoneTest.Tests.Filters;

public class ThreeOrMoreWordsFilterTests
{
    private readonly ThreeOrMoreWordsFilter _sut;

    public ThreeOrMoreWordsFilterTests()
    {
        _sut = new ThreeOrMoreWordsFilter();
    }
    
    [Fact]
    public void GivenWordHasLessThanThreeCharacters_WhenFilterApplied_ReturnsEmptyString()
    {
        const string word = "Hi";
        var result = _sut.ApplyFilter(word);
        result.Should().BeEmpty();
    }
    
    [Fact]
    public void GivenWordHasThreeOrMoreCharacters_WhenFilterApplied_ReturnsSameWord()
    {
        const string word = "Hello";
        var result = _sut.ApplyFilter(word);
        result.Should().Be(word);
    }
}