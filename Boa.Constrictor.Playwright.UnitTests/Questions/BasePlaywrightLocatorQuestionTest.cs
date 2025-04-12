using Boa.Constrictor.Playwright.Elements;
using Microsoft.Playwright;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Boa.Constrictor.Playwright.UnitTests.Questions;

public class BasePlaywrightLocatorQuestionTest : BasePlaywrightQuestionTest
{
    #region Test Variables

    public IPlaywrightLocator PlaywrightLocator { get; set; }

    public IPlaywrightLocator BoaWebLocator { get; set; }

    public Mock<ILocator> Locator { get; set; }

    #endregion

    #region Setup

    [SetUp]
    public void SetupLocators()
    {
        // Create common mocked locator to be returned by both locator types
        Locator = new Mock<ILocator>();

        // Setup PlaywrightLocator (direct implementation)
        var pwLocator = new Mock<IPlaywrightLocator>();
        pwLocator.Setup(x => x.Description).Returns("Playwright test element");
        pwLocator.Setup(x => x.FindIn(Page.Object)).Returns(Locator.Object);
        PlaywrightLocator = pwLocator.Object;

        // Setup BoaWebLocator (which implements IPlaywrightLocator)
        var mockBy = new Mock<By>(MockBehavior.Loose);
        var boaLocator = new Mock<BoaWebLocator>("BoaWeb test element", mockBy.Object);
        boaLocator.As<IPlaywrightLocator>().Setup(x => x.FindIn(Page.Object)).Returns(Locator.Object);
        BoaWebLocator = boaLocator.Object;
    }
    #endregion
}