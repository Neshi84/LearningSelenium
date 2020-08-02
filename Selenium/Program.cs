using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Selenium
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://ws.rfzo.rs/FinKontrola/login.html";
            

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            driver.FindElement(By.Id("userLogin")).SendKeys("dzbpalanka");
            driver.FindElement(By.Id("passwordLogin")).SendKeys("QX08z9cQ");
            driver.FindElement(By.Id("adminLogin")).Click();
            driver.Navigate().GoToUrl("https://ws.rfzo.rs/FinKontrola/index_zo.php");

           

            var oprema = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("idEvidencija")));

            
            var selectElement = new SelectElement(oprema);

            var kolicina = driver.FindElement(By.Id("kolicina"));
            var brojZposlenih = driver.FindElement(By.Id("brojZaposlenih"));
            var snimiEvidenciju = driver.FindElement(By.Id("snimi_evidenciju"));

            selectElement.SelectByValue("11");
            kolicina.Click();
            kolicina.SendKeys("10");
            brojZposlenih.SendKeys("355");

            snimiEvidenciju.Click();
        }
    }
}
