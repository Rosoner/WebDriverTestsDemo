using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenTestingCalculator
{
    public class WebDriverCalculatorTest
    {
        private ChromeDriver driver;
        IWebElement field1;
        IWebElement field2;
        IWebElement operato;
        IWebElement calculate;
        IWebElement resultField;
        IWebElement clearField;

        // create properties in the Class

    [OneTimeSetUp]
        public void OpenAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://number-calculator.nakov.repl.co/";

            // locate elements
             field1 = driver.FindElement(By.Id("number1"));
             field2 = driver.FindElement(By.Id("number2"));
             operato = driver.FindElement(By.Id("operation"));
             calculate = driver.FindElement(By.Id("calcButton"));
             resultField = driver.FindElement(By.Id("result"));
             clearField = driver.FindElement(By.Id("resetButton"));
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [TestCase("5", "6", "+", "Result: 11")]
        [TestCase("5", "5", "+", "Result: 10")]
        [TestCase("3", "2", "+", "Result: 5")]
        [TestCase("alabala", "alabala", "-", "Result: invalid input")]

        public void Test_Calculator(string num1, string num2, string operto, string result)
        {
        
            // Act
            field1.SendKeys(num1);
            operato.SendKeys(operto);
            field2.SendKeys(num2);

            calculate.Click();

            //string expectedValue = "Result: 11";

            Assert.That(result, Is.EqualTo(resultField.Text));

            // clear after every test case fields
            clearField.Click();

        }
    }
}