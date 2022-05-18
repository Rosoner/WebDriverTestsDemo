using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// create new chrome driver
var driver = new ChromeDriver();

// Navigate to Wikipedia
driver.Url = "https://www.wikipedia.org/";

System.Console.WriteLine("Current title: " + driver.Title);

// locate search field by Id
var searchField = driver.FindElement(By.Id("searchInput"));

// click on element
searchField.Click();

// fill QA and press Enter keyboard button 
searchField.SendKeys("QA" + Keys.Enter);

System.Console.WriteLine("Title after search: " + driver.Title);

// close browser
driver.Quit();
