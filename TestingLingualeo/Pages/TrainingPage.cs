using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using TestingLingualeo.Exception;
using TestingLingualeo.Helpers;
using TestingLingualeo.Models;

namespace TestingLingualeo.Pages
{
    public class TrainingPage : IPage
    {
        private readonly IWebDriver _driver;
        private readonly string _url =
            @"https://lingualeo.com/ru/training";

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[2]/div[2]/div/div/div/div/div[1]/div[5]/div/a/div")] 
        private IWebElement _world_to_translation_button;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[2]/div/div/div/div/div[3]/div[1]/div[4]/button[6]")] 
        private IWebElement _dont_know_button;
        
        private static readonly string WORD_TRANSLATION =
            "/html/body/div[1]/div/div[2]/div[2]/div/div/div/div/div[1]/div[5]/div/a/div";

        private static readonly string TRANSLATION_INCORRECT =
            "/html/body/div[1]/div/div[2]/div/div/div/div/div[3]/div[2]/div[2]/div/div[1]/div[1]";
        
        private static readonly string DONT_NOW =
            "/html/body/div[1]/div/div[2]/div/div/div/div/div[3]/div[1]/div[4]/button[6]";
        
        public TrainingPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
        }

        public TrainingPage Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
            return this;
        }

        public TrainingPage GoToWord_Translation()
        {
            if (ElementHelper.HasElement(_driver, By.XPath(WORD_TRANSLATION), TimeSpan.FromMilliseconds(500)))
            {
                _world_to_translation_button.Click();
            }
            return this;
        }

        public TrainingPage Submit()
        {
            if (ElementHelper.HasElement(_driver, By.XPath(DONT_NOW), TimeSpan.FromMilliseconds(500)))
            {
                _dont_know_button.Click();
            }
            
            if (ElementHelper.HasElementText(_driver, By.XPath(TRANSLATION_INCORRECT), TimeSpan.FromMilliseconds(50)))
            {
                throw new TextException("The translation is incorrect");
            }

            return this;
        }
        public string GetPageName()
        {
            return "Учиться";
        }

        public bool AreEqual()
        {
            return _driver.Title == GetPageName();
        }
    }
}