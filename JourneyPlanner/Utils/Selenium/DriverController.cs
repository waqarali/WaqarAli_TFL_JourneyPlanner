using OpenQA.Selenium;
using JourneyPlanner.Drivers;
using System;
using System.Diagnostics;
using System.Threading;

namespace JourneyPlanner.Utils.Selenium
{
    internal class DriverController
    {
        internal static DriverController Instance = new DriverController();
        internal IWebDriver WebDriver { get; set; }

        /// <summary>
        /// Load the ChromeDriver
        /// </summary>
        internal void StartChrome()
        {
            if (WebDriver != null)
                return;
            ;
            WebDriver = ChromeWebDriver.LoadChoromDriver();
        }

        /// <summary>
        /// Load the FireFoxDriver
        /// </summary>
        internal void StartFirefox()
        {
            if (WebDriver != null)
                return;
            WebDriver = FirefoxWebDriver.LoadFirefoxDriver();
        }

        /// <summary>
        /// Stop the WebDriver
        /// </summary>
        internal void StopWebDriver()
        {
            if (WebDriver == null) return;
            try
            {
                WebDriver.Manage().Cookies.DeleteAllCookies();
                Thread.Sleep(3000);
                WebDriver.Quit();
                WebDriver.Dispose();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e, ":: WebDriver stop error");

            }
            WebDriver = null;
            Console.WriteLine(":: WebDriver Stopped");

        }

    }
}
