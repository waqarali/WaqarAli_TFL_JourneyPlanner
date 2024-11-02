using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace JourneyPlanner.Utils.Selenium
{   

    /// <summary>
    /// Constructor
    /// </summary>
    [Binding]
    public static class Driver
    {
        public static IWebDriver Browser()
        {
            return DriverController.Instance.WebDriver;
        }

    }
}
