using ComputerHost.Objects;
using ComputerHost.SeleniumHandlers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ComputerHost.Services
{

    [ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
    public class YouTubeService : IYouTubeService
    {
        private SeleniumYouTubeOperator seleniumYT;

        public YouTubeService()
        {
            seleniumYT = new SeleniumYouTubeOperator();
        }
        public void Back()
        {
            seleniumYT.Back();
        }
        public void ExitYouTube()
        {
            seleniumYT.Close();
        }

        public List<PlayableElement> GetVideos()
        {
            return seleniumYT.GetVideos();
        }

        public void OpenVideo(string s)
        {
            seleniumYT.OpenVideo(s);
        }

        public void OpenYoutube()
        {
            seleniumYT.OpenYoutube();
        }

        public void Replay()
        {
            seleniumYT.Replay();
        }

        public void SearchForVideos(string s)
        {
            seleniumYT.SearchFor(s);
        }

        public void PausePlay()
        {
            seleniumYT.PausePlay();
        }

        public void Next()
        {
            seleniumYT.Next();
        }

        public string GetTittle()
        {
            return seleniumYT.GetTittle();
        }

        public List<PlayableElement> GetVideosN(int i)
        {
            return seleniumYT.GetVideosN(i);
        }

        public void CloseYouTube()
        {
            seleniumYT.Close();
        }
        [Obsolete]
        public int ReconnectYouTube()
        {
            int state = seleniumYT.GetYouTubeState();
            return state;
        }
    }

}
