using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

[Binding]
public class JourneyPlannerSteps
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    [BeforeScenario]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Navigate().GoToUrl("https://tfl.gov.uk/");
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        AcceptCookies();
    }

    private void AcceptCookies()
    {
        Thread.Sleep(2000);
        try
        {
            var cookieBanner = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")));
            cookieBanner.Click();
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("Cookie banner did not appear within the specified time.");
        }
    }

    [AfterScenario]
    public void Cleanup()
    {
        _driver.Quit();
    }

    private void EnterLocation(string location, string fieldId)
    {
        var locationInput = _driver.FindElement(By.Id(fieldId));
        locationInput.SendKeys(location);
    }

    private void SelectSuggestion(string location)
    {
        var suggestion = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//span[@class='stop-name' and contains(., '{location}')]")));
        suggestion.Click();
    }

    private void ClickButtonById(string buttonId)
    {
        var button = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(buttonId)));
        button.Click();
    }

    private void ClickButtonByCss(string cssSelector)
    {
        var button = _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(cssSelector)));
        button.Click();
    }

    [Given(@"I navigate to the TfL homepage")]
    public void GivenINavigateToTheTfLHomepage()
    {
        // Already handled in SetUp.
    }

    [When(@"I enter ""(.*)"" in the from location")]
    public void WhenIEnterInTheFromLocation(string fromLocation)
    {
        EnterLocation(fromLocation, "InputFrom");
    }

    [When(@"I select ""(.*)"" from suggestions")]
    public void WhenISelectFromSuggestions(string location)
    {
        SelectSuggestion(location);
    }

    [When(@"I enter ""(.*)"" in the to location")]
    public void WhenIEnterInTheToLocation(string toLocation)
    {
        EnterLocation(toLocation, "InputTo");
    }

    [When(@"I click Plan my journey")]
    public void WhenIClickPlanMyJourney()
    {
        ClickButtonById("plan-journey-button");
    }

    [When(@"I click Update journey")]
    public void WhenIClickUpdateJourney()
    {
        var button = _driver.FindElement(By.CssSelector(".update-buttons .plan-journey-button"));
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", button);
    }

    [When(@"I click Edit preferences")]
    public void WhenIClickEditPreferences()
    {
        ClickButtonByCss(".edit-preferences button");
    }

    [When(@"I select Routes with least walking")]
    public void WhenISelectRoutesWithLeastWalking()
    {
        var leastWalkingOption = _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("label[for='JourneyPreference_2']")));
        leastWalkingOption.Click();
    }

    [Then(@"I should see the updated journey time")]
    public void ThenIShouldSeeTheUpdatedJourneyTime()
    {
        var journeyResults = _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".journey-results")));
        var journeyTime = _driver.FindElement(By.CssSelector(".journey-results .journey-time")).Text;
        Assert.That(!string.IsNullOrEmpty(journeyTime), "Walking time should be displayed.");
    }

    [Then(@"I should see the walking and cycling time results")]
    public void ThenIShouldSeeTheWalkingAndCyclingTimeResults()
    {
        var walkingTime = _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".journey-box.cycling .journey-info"))).Text;
        Assert.That(!string.IsNullOrEmpty(walkingTime), "Walking time should be displayed.");
    }

    [Given(@"I have planned a journey from ""(.*)"" to ""(.*)""")]
    public void GivenIHavePlannedAJourneyFromTo(string fromLocation, string toLocation)
    {
        GivenINavigateToTheTfLHomepage();
        WhenIEnterInTheFromLocation(fromLocation);
        WhenISelectFromSuggestions(fromLocation);
        WhenIEnterInTheToLocation(toLocation);
        WhenISelectFromSuggestions(toLocation);
        WhenIClickPlanMyJourney();
        ThenIShouldSeeTheWalkingAndCyclingTimeResults();
    }

    [Given(@"I have Updated preferences")]
    public void GivenIHaveUpdatedPreferences()
    {
        WhenIClickEditPreferences();
        WhenISelectRoutesWithLeastWalking();
        WhenIClickUpdateJourney();
        ThenIShouldSeeTheUpdatedJourneyTime();
    }

    [When(@"I click View Details")]
    public void WhenIClickViewDetails()
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".journey-details")));
        var viewDetailsButton = _driver.FindElement(By.CssSelector(".journey-details .show-detailed-results.view-hide-details"));
        viewDetailsButton.Click();
    }

    [Then(@"I should see complete access information for ""(.*)""")]
    public void ThenIShouldSeeCompleteAccessInformationFor(string stationName)
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".details")));
        var locationName = _driver.FindElement(By.CssSelector(".journey-detail-step .stop-location-and-time .location-name")).Text;
        Assert.That(!locationName.Contains(stationName));
    }

    [Then(@"I should see an error message indicating no results found")]
    public void ThenIShouldSeeAnErrorMessageIndicatingNoResultsFound()
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".main.results-wrapper")));
        var walkingTime = _driver.FindElements(By.CssSelector(".journey-box.cycling .journey-info"));
        var cyclingTime = _driver.FindElements(By.CssSelector(".journey-box.cycling .journey-info"));
        Assert.That(walkingTime.Count == 0);
        Assert.That(cyclingTime.Count == 0);
    }

    [When(@"I do not enter any locations")]
    public void WhenIDoNotEnterAnyLocations()
    {
        // Intentionally left empty.
    }

    [Then(@"I should see an error message indicating that locations are required")]
    public void ThenIShouldSeeAnErrorMessageIndicatingThatLocationsAreRequired()
    {
        var fromErrorMessage = _driver.FindElement(By.Id("InputFrom-error")).Text;
        var toErrorMessage = _driver.FindElement(By.Id("InputTo-error")).Text;
        Assert.That(fromErrorMessage.Contains("The From field is required"), "Expected From field error message.");
        Assert.That(toErrorMessage.Contains("The To field is required"), "Expected To field error message.");
    }
}
