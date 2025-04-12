using FluentAssertions;
using Microsoft.Playwright;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Boa.Constrictor.Playwright.UnitTests.Questions;

public class VisibilityTest : BasePlaywrightLocatorQuestionTest
{
    [Test]
    public async Task TestGetVisibility()
    {
        // Arrange
        Locator
            .Setup(x => x.IsVisibleAsync(It.IsAny<LocatorIsVisibleOptions>()))
            .Returns(Task.FromResult(true));

        // Act
        var visibility = await Actor.AsksForAsync(Visibility.Of(PlaywrightLocator));

        // Assert
        visibility.Should().BeTrue();
    }

    [Test]
    public async Task TestGetVisibility_BoaLocator()
    {
        // Arrange
        Locator
            .Setup(x => x.IsVisibleAsync(It.IsAny<LocatorIsVisibleOptions>()))
            .Returns(Task.FromResult(true));

        // Act
        var visibility = await Actor.AsksForAsync(Visibility.Of(PlaywrightLocator));

        // Assert
        visibility.Should().BeTrue();
    }
}