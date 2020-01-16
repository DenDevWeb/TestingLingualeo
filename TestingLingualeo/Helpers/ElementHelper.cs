using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestingLingualeo.Helpers
{
    public class ElementHelper
    {
        public static bool HasElement(IWebDriver driver, By selector, TimeSpan time)
        {
            WebDriverWait wait = new WebDriverWait(driver, time);
            try
            {
                if (wait.Until(d => driver.FindElements(selector).Count>0))
                {
                    return true;
                }
            }
            catch (WebDriverTimeoutException e)
            {
                return false;
            }
            
            return false;
        }
        
        public static bool HasElementText(IWebDriver driver, By selector, TimeSpan time)
        {
            WebDriverWait wait = new WebDriverWait(driver, time);
            try
            {
                //IWebElement test = driver.FindElement(selector);
                if (wait.Until(d => driver.FindElement(selector).Text != ""))
                {
                    return true;
                }
            }
            catch (WebDriverTimeoutException e)
            {
                return false;
            }
            

            return false;
        }
    }
}