using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTests
{
    
    public class SoftUniTest
    {
        private WebDriver driver;

        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://softuni.bg/";
            driver.Manage().Window.Maximize();

        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_AssertMainPageTitle()
        {
            // Act
            driver.Url = "https://softuni.bg/";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";

            // Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void Test_AssertAboutUsTitle()
        {            
            // Act
            
            var zaNsElement = driver.FindElement(By.CssSelector("#header-nav > div.toggle-nav.toggle-holder > ul > li:nth-child(1) > a > span"));
            zaNsElement.Click();

            string expectedTitle = "За нас - Софтуерен университет";


            // Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));

            
        }

        [Test]
        public void Test_Login_InvalidUserNameAndPassword()
        {
            //driver.Navigate().GoToUrl("https://softuni.bg/");
            //driver.Manage().Window.Size = new System.Drawing.Size(1280, 690);
            driver.FindElement(By.CssSelector(".softuni-btn-primary")).Click();
            driver.FindElement(By.CssSelector(".authentication-page")).Click();
            driver.FindElement(By.Id("username")).SendKeys("user1");
            driver.FindElement(By.CssSelector(".authentication-page")).Click();
            driver.FindElement(By.Id("password-input")).SendKeys("user1");
            driver.FindElement(By.CssSelector(".softuni-btn")).Click();
            Assert.That(driver.FindElement(By.CssSelector("li")).Text, Is.EqualTo("Невалидно потребителско име или парола"));
            driver.Close();
        }
    }
}