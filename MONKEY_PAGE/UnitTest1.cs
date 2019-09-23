using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;

/*
 * 
  - Views the latest comic
  - User can view the next comic
  - Views the history of comics
  - Opens the comics from the following dates:
    - December 4, 2018
    - June 19, 2018
    - May 30, 2017
  - Verify a product can be added to cart and the checkout screen works

 * */
namespace MONKEY_PAGE
{
    [TestClass]
    public class TestFramework
    {
        OpenQA.Selenium.IWebDriver wd;
        [TestMethod]
        [DeploymentItem("Data.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "Data.csv", "Data#csv", DataAccessMethod.Sequential)]

        public void LaunchSuite()
        {
            wd = new ChromeDriver(@"..\..\..\..\MONKEY_PAGE\packages\Selenium.Chrome.WebDriver.76.0.0\driver\");
            wd.Navigate().GoToUrl(TestContext.DataRow["Link"].ToString());
            Thread.Sleep(1000);
            int code = 0;
            code = Convert.ToInt32(TestContext.DataRow["Action"].ToString());
            switch (code)
            {
                case 0:
                    randomComic();
                    break;
                case 1:
                    latestComic();
                    break;
                case 2:
                    prevStrip();
                    break;
                case 3:
                    history();
                    break;
                case 4:
                    openDec4();
                    break;
                case 5:
                    openJun19();
                    break;
                case 6:
                    openMay30();
                    break;
                case 7:
                    verify();
                    break;
                default:
                    break;
            }

        }
        //- Views a random comic:
        public void randomComic()
        {
            wd.FindElement(By.CssSelector("[href*='/toc']")).Click();

            Thread.Sleep(1000);

            IList<IWebElement> allets = wd.FindElements(By.ClassName("et"));

            Random random = new Random();
            int index = random.Next(0, allets.Count);

            String[] text = new String[allets.Count];

            int i = 0;

            foreach (IWebElement element in allets)
            {
                text[i++] = element.Text;


                if (index == i)
                {
                    string path = "html/body/div[2]/div[1]/div/div/div[" + i.ToString() + "]/div/div/a[2]";
                    IWebElement button = wd.FindElement(By.XPath(path));

                    button.Click();
                    Console.WriteLine("Clicked on a random comic strip # " + i);
                    Thread.Sleep(5000);
                    break;
                }
            }

        }

        public void latestComic()
        {
            wd.FindElement(By.CssSelector("[href*='/toc']")).Click();

            Thread.Sleep(1000);

            string path = "html/body/div[2]/div[1]/div/div/div[1]/div/div/a[2]";
            IWebElement button = wd.FindElement(By.XPath(path));

            button.Click();
            Console.WriteLine("Clicked on the latest comic strip");
            Thread.Sleep(5000);
        }
        public void prevStrip()
        {
            wd.FindElement(By.CssSelector("[href*='/toc']")).Click();

            Thread.Sleep(2000);

            string path = "html/body/div[2]/div[1]/div/div/div[1]/div/div/a[2]";
            IWebElement button = wd.FindElement(By.XPath(path));

            button.Click();

            IWebElement image = wd.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/p/img"));
            ///html/body/div[2]/div[2]/div[1]/p/img

            Thread.Sleep(2000);

            Actions actionProvider = new Actions(wd);
            IAction goprev = actionProvider.KeyDown( Keys.ArrowLeft).Build();
            goprev.Perform();
            Console.WriteLine("Clicked one strip back");
            Thread.Sleep(2000);

            goprev = actionProvider.KeyDown(Keys.ArrowLeft).Build();
            goprev.Perform();
            Console.WriteLine("Clicked another strip back");

            Thread.Sleep(2000);

        }
        public void history()
        {
            //Views the history of comics
            wd.FindElement(By.CssSelector("[href*='/toc']")).Click();

            Thread.Sleep(1000);

            IList<IWebElement> allets = wd.FindElements(By.ClassName("et"));

            Random random = new Random();
            int index = random.Next(0, allets.Count);

            String[] text = new String[allets.Count];

            int i = 0;

            foreach (IWebElement element in allets)
            {
                text[i++] = element.Text;


                if (index == i)
                {
                    string path = "html/body/div[2]/div[1]/div/div/div[" + i.ToString() + "]/div/div/a[2]";
                    IWebElement button = wd.FindElement(By.XPath(path));
               

                    button.Click();
                    Thread.Sleep(3000);

                    IWebElement a, b;
                    a = wd.FindElement(By.XPath("/html/body/div[2]/div[2]/span/span/a[1]/span"));
                    b = wd.FindElement(By.XPath("/html/body/div[2]/div[2]/span/span/a[2]/span"));

                    Console.WriteLine("Hstory of comic strip # "+i+ " is " + a.Text +" ----> " + b.Text);
                    a.Click();

                    Thread.Sleep(1000);

                    break;
                }
            }
        }
        public void openDec4()
        {
            //- December 4, 2018
            wd.FindElement(By.CssSelector("[href*='/toc']")).Click();

            Thread.Sleep(2000);

            IList<IWebElement> allets = wd.FindElements(By.ClassName("et"));
                    
            String[] text = new String[allets.Count];

            int i = 0;

            foreach (IWebElement element in allets)
            {
                text[i++] = element.Text;

                string strongpath = "html/body/div[2]/div[1]/div/div/div[" + i.ToString() + "]/div/strong";
                IWebElement strongEle = wd.FindElement(By.XPath(strongpath));
               
                if (strongEle.Text.Contains("December 4, 2018"))
                {
                    string path = "html/body/div[2]/div[1]/div/div/div[" + i.ToString() + "]/div/div/a[2]";
                    IWebElement button = wd.FindElement(By.XPath(path));

                    button.Click();
                    Console.WriteLine("Clicked on the comic strip dated December 4, 2018");
                    Thread.Sleep(5000);
                    break;
                }
            }

        }
        public void openJun19()
        {
            //    - June 19, 2018
            
            wd.FindElement(By.CssSelector("[href*='/toc']")).Click();

            Thread.Sleep(2000);

            IList<IWebElement> allets = wd.FindElements(By.ClassName("et"));

            String[] text = new String[allets.Count];

            int i = 0;

            foreach (IWebElement element in allets)
            {
                text[i++] = element.Text;

                string strongpath = "html/body/div[2]/div[1]/div/div/div[" + i.ToString() + "]/div/strong";
                IWebElement strongEle = wd.FindElement(By.XPath(strongpath));

                if (strongEle.Text.Contains("June 19, 2018"))
                {
                    string path = "html/body/div[2]/div[1]/div/div/div[" + i.ToString() + "]/div/div/a[2]";
                    IWebElement button = wd.FindElement(By.XPath(path));

                    button.Click();
                    Console.WriteLine("Clicked on the comic strip dated June 19, 2018");
                    Thread.Sleep(5000);
                    break;
                }
            }
        }
        public void openMay30()
        {
            //- May 30, 2017
            wd.FindElement(By.CssSelector("[href*='/toc']")).Click();

            Thread.Sleep(2000);

            IList<IWebElement> allets = wd.FindElements(By.ClassName("et"));

            String[] text = new String[allets.Count];

            int i = 0;

            foreach (IWebElement element in allets)
            {
                text[i++] = element.Text;

                string strongpath = "html/body/div[2]/div[1]/div/div/div[" + i.ToString() + "]/div/strong";
                IWebElement strongEle = wd.FindElement(By.XPath(strongpath));

                if (strongEle.Text.Contains("May 30, 2017"))
                {
                    string path = "html/body/div[2]/div[1]/div/div/div[" + i.ToString() + "]/div/div/a[2]";
                    IWebElement button = wd.FindElement(By.XPath(path));

                    button.Click();
                    Console.WriteLine("Clicked on the comic strip dated May 30, 2017");
                    Thread.Sleep(5000);
                    break;
                }
            }
        }
        public void verify()
        {
            //- Verify a product can be added to cart and the checkout screen works

            wd.FindElement(By.CssSelector("[href*='https://store.monkeyuser.com']")).Click();
            Thread.Sleep(2000);
         //click on the product 1:
            wd.FindElement(By.CssSelector("[href*='/collections/frontpage/products/bug']")).Click();

            //Assert for add to cart :
            IWebElement cart_button = wd.FindElement(By.XPath("/html/body/div[3]/main/div/div[1]/div/div[2]/div[1]/form/div[2]/button"));
            Assert.IsTrue(cart_button.GetAttribute("name").Contains("add" ));
            cart_button.Click();

            Thread.Sleep(2000);

            IWebElement chkout = wd.FindElement(By.XPath("/html/body/div[3]/main/div/div/form/div/div/div/div[3]/input[2]"));
            Assert.IsTrue(chkout.GetAttribute("value").Contains("Check out"));
            Console.WriteLine("Checkout button is as expected");
            

        }
        public Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContextInstance;


        [TestCleanup]
        public void teardown()
        {
            wd.Quit();
        }
    }

}
