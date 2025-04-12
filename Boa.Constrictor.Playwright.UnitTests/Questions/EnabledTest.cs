using FluentAssertions;
using Microsoft.Playwright;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Boa.Constrictor.Playwright.UnitTests.Questions;

public class EnabledTest : BasePlaywrightLocatorQuestionTest
{
    [Test]
    public async Task TestGetEnabled()
    {
        // Arrange
        Locator
            .Setup(x => x.IsEnabledAsync(It.IsAny<LocatorIsEnabledOptions>()))
            .Returns(Task.FromResult(false));

        // Act
        var enabled = await Actor.AsksForAsync(Enabled.Of(PlaywrightLocator));

        // Assert
        enabled.Should().BeFalse();
    }
}