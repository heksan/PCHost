using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerHost.SeleniumHandlers
{
    public static class MainSeleniumHandler
    {
        private static IWebDriver driver;
        public static IWebDriver GetDriver()
        {
            if (driver!=null)
            {
                return driver;
            }
            else
            {
                driver = InitBrowser();
                return driver;
            }
        }
        private static IWebDriver InitBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--whitelisted-ips=\"\"");
            options.AddArgument("disable-infobars");
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
