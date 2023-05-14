using CalastoneTest.Services;
using CalastoneTest.Strategies;
using CalastoneTest.Wrappers;
using FluentAssertions;
using Moq;

namespace CalastoneTest.Tests.Services;

public class TextFilterServiceTests
{
    private readonly Mock<IFilterStrategy> _filterStrategyMock;
    private readonly TextFilterService _sut;

    public TextFilterServiceTests()
    {
        _filterStrategyMock = new Mock<IFilterStrategy>();
        _sut = new TextFilterService(_filterStrategyMock.Object);
    }
    
    [Fact]
    public void GivenNoWordsToFilter_WhenFilteringText_ReturnsSameText()
    {
        // Arrange
        var text = ".?.|@$$808";

        // Act
        var result = _sut.FilterText(text);

        // Assert
        result.Should().Be(text);
    }
    
    [Fact]
    public void GivenWordsToFilterExist_WhenFilteringText_ReturnsFilteredText()
    {
        // Arrange

        _filterStrategyMock.Setup(f => f.ApplyFilter("Text")).Returns("");
        _filterStrategyMock.Setup(f => f.ApplyFilter("contains")).Returns("");
        _filterStrategyMock.Setup(f => f.ApplyFilter("total")).Returns("");
        _filterStrategyMock.Setup(f => f.ApplyFilter("of")).Returns("of");
        _filterStrategyMock.Setup(f => f.ApplyFilter("t")).Returns("");
        _filterStrategyMock.Setup(f => f.ApplyFilter("words")).Returns("words");
        const string text = "Text contains total of t words.";

        // Act
        var result = _sut.FilterText(text);

        // Assert
        result.Should().Be("   of  words.");
    }
}