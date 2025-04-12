using FluentAssertions;
using Microsoft.Playwright;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Boa.Constrictor.Playwright.UnitTests.Questions;

public class AttributeTest : BasePlaywrightLocatorQuestionTest
{
    [Test]
    [TestCase(nameof(PlaywrightLocator))]
    [TestCase(nameof(BoaWebLocator))]
    public async Task TestGetAttribute(string locatorType)
    {
        // Arrange
        Locator
            .Setup(x => x.GetAttributeAsync(It.IsAny<string>(), It.IsAny<LocatorGetAttributeOptions>()))
            .Returns(Task.FromResult("abc123"));

        var locator = locatorType == nameof(PlaywrightLocator) ? PlaywrightLocator : BoaWebLocator;

        // Act
        var attribute = await Actor.AsksForAsync(Attribute.Of(locator, "my-attribute"));

        // Assert
        attribute.Should().Be("abc123");
    }

    [Test]
    [TestCase(nameof(PlaywrightLocator))]
    [TestCase(nameof(BoaWebLocator))]
    public async Task TestNoAttributeFound(string locatorType)
    {
        var locator = locatorType == nameof(PlaywrightLocator) ? PlaywrightLocator : BoaWebLocator;

        // Act
        var attribute = await Actor.AsksForAsync(Attribute.Of(locator, "my-attribute"));

        // Assert
        attribute.Should().BeNull();
    }

    [Test]
    [TestCase(nameof(PlaywrightLocator))]
    [TestCase(nameof(BoaWebLocator))]
    public async Task TestGetAttribute_BoaWebLocator(string locatorType)
    {
        // Arrange
        Locator
            .Setup(x => x.GetAttributeAsync(It.IsAny<string>(), It.IsAny<LocatorGetAttributeOptions>()))
            .Returns(Task.FromResult("abc123"));

        var locator = locatorType == nameof(PlaywrightLocator) ? PlaywrightLocator : BoaWebLocator;


        // Act
        var attribute = await Actor.AsksForAsync(Attribute.Of(locator, "my-attribute"));

        // Assert
        attribute.Should().Be("abc123");
    }

    [Test]
    [TestCase(nameof(PlaywrightLocator))]
    [TestCase(nameof(BoaWebLocator))]
    public async Task TestNoAttributeFound_BoaWebLocator(string locatorType)
    {
        var locator = locatorType == nameof(PlaywrightLocator) ? PlaywrightLocator : BoaWebLocator;


        // Act
        var attribute = await Actor.AsksForAsync(Attribute.Of(locator, "my-attribute"));

        // Assert
        attribute.Should().BeNull();
    }
}