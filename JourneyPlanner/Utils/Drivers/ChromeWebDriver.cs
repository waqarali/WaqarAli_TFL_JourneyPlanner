using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyPlanner.Drivers
{
    internal static class ChromeWebDriver
    {
        /// <summary>
        /// Create an instance of ChromeDriver and disable the extensions
        /// </summary>
        /// <returns></returns>
        internal static IWebDriver LoadChoromDriver()
        {

            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            var options = new ChromeOptions();
            options.AddArgument("--disable-extensions");

            var driver = new ChromeDriver(driverService, options);
            Console.WriteLine(driver.Manage().Window.Size);
            
            return driver;
          
        }

    }

}
