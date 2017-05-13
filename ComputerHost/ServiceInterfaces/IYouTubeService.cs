using ComputerHost.Objects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ComputerHost
{
    [ServiceContract]
    public interface IYouTubeService
    {
        [OperationContract]
        void OpenYoutube();

        [OperationContract]
        void SearchForVideos(string s);

        [OperationContract]
        List<PlayableElement> GetVideos();

        [OperationContract]
        List<PlayableElement> GetVideosN(int i);

        [OperationContract]
        void ExitYouTube();

        [OperationContract]
        void OpenVideo(string s);

        [OperationContract]
        void Replay();

        [OperationContract]
        void Back();

        [OperationContract]
        void PausePlay();

        [OperationContract]
        void Next();

        [OperationContract]
        string GetTittle();

        [OperationContract]
        void CloseYouTube();

    }  
}
