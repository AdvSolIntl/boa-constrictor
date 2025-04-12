using FluentAssertions;
using Microsoft.Playwright;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Boa.Constrictor.Playwright.UnitTests.Questions;

public class InnerTextTest : BasePlaywrightLocatorQuestionTest
{
    [Test]
    public async Task TestGetInnerText()
    {
        // Arrange
        Locator
            .Setup(x => x.InnerTextAsync(It.IsAny<LocatorInnerTextOptions>()))
            .Returns(Task.FromResult("Hello"));

        // Act
        var innerText = await Actor.AsksForAsync(InnerText.Of(PlaywrightLocator));

        // Assert
        innerText.Should().Be("Hello");
    }
}