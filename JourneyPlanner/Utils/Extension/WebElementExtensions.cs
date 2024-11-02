using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using JourneyPlanner.Utils.Selenium;
using System;

namespace JourneyPlanner.Extensions
{
    public static class WebElementExtensions
    {
        
        // Highlight elements
        public static void WeHighlightElement(this IWebElement element)
        {
            var js = (IJavaScriptExecutor)Driver.Browser();
            js.ExecuteScript("arguments[0].style.border = '4px solid blue'", element);
        }

        // Wait until element is displayed
        public static bool WeElementIsDisplayed(this IWebElement element, int sec = 30)
        {
            var wait = new WebDriverWait(Driver.Browser(), TimeSpan.FromSeconds(sec));
            return wait.Until(d =>
            {
                try
                {

                    return element.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            );
        }

        // wait until element clickable
        public static void WeElementToBeClickable(this IWebElement element, int sec = 15)
        {
            var wait = new WebDriverWait(Driver.Browser(), TimeSpan.FromSeconds(sec));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }


        // Click extenstion method 
        public static void WeClick(this IWebElement element, int sec = 15)
        {
            element.WeElementToBeClickable(sec);
            element.WeHighlightElement();
            element.WeElementIsEnabled();
            element.Click();
        }

        // Send key extenstion method 
        public static void WeSendKeys(this IWebElement element, string text, int sec = 15, bool clearFirst = false)
        {
            element.WeElementIsDisplayed(sec);
            if (clearFirst == true) element.Click();
            element.SendKeys(text);
        }

        // Wait until element is enabled 
        public static bool WeElementIsEnabled(this IWebElement element, int sec = 10)
        {
            var wait = new WebDriverWait(Driver.Browser(), TimeSpan.FromSeconds(sec));
            return wait.Until(d =>
            {
                try
                {
                    element.WeHighlightElement();
                    return element.Enabled;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            }
             
            );
        }

}
}
