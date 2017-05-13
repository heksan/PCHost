using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;
using System.Threading;
using ComputerHost.Common;
using ComputerHost.SeleniumHandlers;
using System.Linq;
using ComputerHost.Objects;
using System.Threading.Tasks;

namespace ComputerHost.SeleniumHandlers
{
    public class SeleniumYouTubeOperator
    {
        IWebDriver driver;
        List<PlayableElement> videos = new List<PlayableElement>();

        public SeleniumYouTubeOperator()
        {
        }

        public void OpenYoutube()
        {
            driver = MainSeleniumHandler.GetDriver();
            driver.Navigate().GoToUrl(YouTubeValues.YouTubeAddress);
        }

        public List<PlayableElement> GetVideos()
        {
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(drive => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            IReadOnlyCollection<IWebElement> elList;
            videos = new List<PlayableElement>();

            elList = driver.FindElements(By.ClassName(YouTubeValues.YTMainVideoLockup));
            if (elList.Count != 0)
            {
                foreach (IWebElement el in elList)
                {
                    if (el.Displayed)
                    {
                        VideoElementsSafeguardMainPage(() => { ListVideoMainPage(el); }, el);
                    }
                }
            }
            else
            {
                elList = driver.FindElements(By.XPath(string.Format(YouTubeValues.LiContainsVideo)));
                foreach (IWebElement el in elList)
                {
                    if (el.Displayed)
                    {
                        VideoElementsSafeguardSuggestionBar(() => { ListVideoSuggestionBar(el); }, el);
                    }
                }
            }
            return videos;
        }

        public List<PlayableElement> GetVideosN(int number)
        {
            List<PlayableElement> names = GetVideos();

            return names.Take(number).ToList();
        }

        public void Close()
        {
            if (driver != null)
            {
                driver.Close();
            }
        }

        public void Back()
        {
            driver.Navigate().Back();
        }       

        public void SearchFor(string search)
        {
            IWebElement searchbox = driver.FindElement(By.Id(YouTubeValues.SearchBox));
            searchbox.Click();
            searchbox.SendKeys(Keys.Control + "a");
            searchbox.SendKeys(search);
            searchbox.SendKeys(Keys.Enter);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleContains(search));

        }

        public void Replay()
        {
            IWebElement player = driver.FindElement(By.Id(YouTubeValues.VideoField));
            player.SendKeys(YouTubeValues.Beginning);
        }

        internal async void OpenVideo(string title)
        {
            var video = videos.FirstOrDefault(x => x.Title.Equals(title));
            driver.Navigate().GoToUrl(video.Link);
        }

        public string GetTittle()
        {
            if (driver.FindElement(By.ClassName(YouTubeValues.WatchFieldTitle)) != null)
            {
                return driver.Title;

            }
            else
            {
                return string.Empty;
            }
        }

        public void Next()
        {
            IWebElement el = driver.FindElement(By.ClassName(CommonHtmlElements.ContentWrapper));
            el.Click();
            string s = el.FindElement(By.TagName(CommonHtmlElements.Link)).GetAttribute(CommonHtmlElements.Title);
        }

        public void PausePlay()
        {
            IWebElement player = driver.FindElement(By.Id(YouTubeValues.VideoField));
            player.Click();
        }

        #region private
        private string SafeString(string s)
        {
            s = s.Replace("\"", "\"");
            s = s.Replace("\r", "");
            s = s.Replace("\n", "");
            return s;
        }
        private void VideoElementsSafeguardMainPage(Action e, IWebElement el)
        {
            try
            {
                e.Invoke();
            }
            catch (NoSuchElementException)
            {
                var title = el.FindElement(By.ClassName(YouTubeValues.LockupTittle)).FindElement(By.TagName(CommonHtmlElements.Link)).GetAttribute(CommonHtmlElements.Title);
                var time = "live";
                var link = el.FindElement(By.TagName(CommonHtmlElements.Link)).GetAttribute(CommonHtmlElements.Href);
                videos.Add(new PlayableElement(title, time, link));
            }
            catch (StaleElementReferenceException)
            {
                return;
            }
        }
        private void VideoElementsSafeguardSuggestionBar(Action e, IWebElement el)
        {
            try
            {
                e.Invoke();
            }
            catch (NoSuchElementException)
            {
                var title = el.FindElement(By.ClassName(CommonHtmlElements.Title)).GetAttribute(CommonHtmlElements.Text);
                title = SafeString(title);
                var time = "live";
                var link = el.FindElement(By.TagName(CommonHtmlElements.Link)).GetAttribute(CommonHtmlElements.Href);
                videos.Add(new PlayableElement(title, time, link));
            }
            catch (StaleElementReferenceException)
            {
                return;
            }
        }
        private void ListVideoSuggestionBar(IWebElement el)
        {
            var title = el.FindElement(By.ClassName(CommonHtmlElements.Title)).GetAttribute(CommonHtmlElements.Text);
            title = SafeString(title);
            var timeElement = el.FindElement(By.ClassName(YouTubeValues.VideoTime));
            var time = timeElement.GetAttribute(CommonHtmlElements.Text);
            var link = el.FindElement(By.TagName(CommonHtmlElements.Link)).GetAttribute(CommonHtmlElements.Href);
            videos.Add(new PlayableElement(title, time, link));
        }

        private void ListVideoMainPage(IWebElement el)
        {
            var title = el.FindElement(By.ClassName(YouTubeValues.LockupTittle)).FindElement(By.TagName(CommonHtmlElements.Link)).GetAttribute(CommonHtmlElements.Title);
            var time = el.FindElement(By.ClassName(YouTubeValues.VideoTime)).GetAttribute(CommonHtmlElements.Text);
            var link = el.FindElement(By.TagName(CommonHtmlElements.Link)).GetAttribute(CommonHtmlElements.Href);
            videos.Add(new PlayableElement(title, time, link));
        }
        #endregion
        #region obsolete
        [Obsolete]
        internal int GetYouTubeState()
        {
            if (driver == null)
            {
                return 0;
            }
            try
            {
                if (driver.Url.Contains("watch"))
                {
                    return 2;
                }
            }
            catch (Exception)
            {
                return 0;
            }
            if (driver.Url.Contains("search"))
            {
                return 1;
            }
            else
            {
                driver.Navigate().GoToUrl("http://www.youtube.com");
                return 1;
            }
        }
        #endregion
    }
}