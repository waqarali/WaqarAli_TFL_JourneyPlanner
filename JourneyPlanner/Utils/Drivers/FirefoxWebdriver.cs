using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyPlanner.Drivers
{
    internal static class FirefoxWebDriver
    {
        /// <summary>
        /// Create an instance of FireFoxDriver and disable the extensions
        /// </summary>
        /// <returns></returns>
        internal static IWebDriver LoadFirefoxDriver()
        {
 
            var options = new FirefoxOptions();
            options.AddArgument("--disable-extensions");
                        
            var driver = new FirefoxDriver(options);
            return driver;
        }
    }
}
