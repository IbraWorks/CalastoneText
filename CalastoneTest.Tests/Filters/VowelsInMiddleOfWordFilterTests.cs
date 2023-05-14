using CalastoneTest.Strategies;
using FluentAssertions;

namespace CalastoneTest.Tests.Filters;

public class VowelsInMiddleOfWordFilterTests
{
    private readonly VowelsInMiddleOfWordFilter _sut;

    public VowelsInMiddleOfWordFilterTests()
    {
        _sut = new VowelsInMiddleOfWordFilter();
    }
    
    [Fact]
    public void GivenWordIsTooShort_WhenFilterApplied_ReturnsSameWord()
    {
        const string word = "as";
        var result = _sut.ApplyFilter(word);
        result.Should().Be(word);
    }

    [Fact]
    public void GivenOddWordHasVowelInTheMiddle_WhenFilterApplied_ReturnsEmptyString()
    {
        const string word = "Track";
        var result = _sut.ApplyFilter(word);
        result.Should().BeEmpty();
    }
    
    [Fact]
    public void GivenEvenWordHasOneVowelInTheMiddle_WhenFilterApplied_ReturnsEmptyString()
    {
        const string word = "streak";
        var result = _sut.ApplyFilter(word);
        result.Should().BeEmpty();
    }
    
    [Fact]
    public void GivenEvenWordHasTwoVowelsInTheMiddle_WhenFilterApplied_ReturnsEmptyString()
    {
        const string word = "seek";
        var result = _sut.ApplyFilter(word);
        result.Should().BeEmpty();
    }

    [Fact]
    public void GivenWordDoesNotHaveVowelsInTheMiddle_WhenFilterApplied_ReturnsSameWord()
    {
        const string word = "Ache";
        var result = _sut.ApplyFilter(word);
        result.Should().Be(word);
    }
}