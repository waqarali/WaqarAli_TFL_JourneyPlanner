using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Support.Extensions;
using JourneyPlanner.Utils.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace JourneyPlanner.Hooks
{
    [Binding]
    internal static class ScenarioHooks
    {

        private static ScenarioContext _scenarioContext;

        /// <summary>
        /// Starts the web Browser depending upon the ScenarioContext 
        /// </summary>
        /// <param name="scenarioContext"></param>
        [BeforeScenario]
        internal static void StartWebDriver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            if (_scenarioContext.ScenarioInfo.Tags.Contains("Chrome"))
            {
                DriverController.Instance.StartChrome();

            }
            else if (_scenarioContext.ScenarioInfo.Tags.Contains("Firefox"))
            {
                DriverController.Instance.StartFirefox();
            }

            else
            {
                //DriverController.Instance.StartChrome();
                //DriverController.Instance.WebDriver.Manage().Cookies.DeleteAllCookies();
            }

        }
        /// <summary>
        /// Stop the web Browser. 
        /// </summary>
        /// <param name="scenarioContext"></param>
        [AfterScenario]
        internal static void TearDown()
        {
            DriverController.Instance.StopWebDriver();
        }
    }
}

