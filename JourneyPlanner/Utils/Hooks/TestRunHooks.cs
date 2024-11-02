using JourneyPlanner.Utils.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace JourneyPlanner.Hooks
{

    [Binding]
    internal static class TestRunHooks
    {

        private static ScenarioContext _scenarioContext;

        /// <summary>
        /// Stop the web Driver 
        /// </summary>
        /// <param name="scenarioContext"></param>
        [AfterTestRun]
        internal static void StopWebDriver(ScenarioContext scenarioContext)
        {

            _scenarioContext = scenarioContext;

            if (!_scenarioContext.ScenarioInfo.Tags.Contains("Debug"))
                DriverController.Instance.StopWebDriver();
        }
    }
}
