using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace ComputerHost.Controllers
{
    public class SystemController
    {
        private CoreAudioDevice _defaultPlaybackDevice;
        public SystemController()
        {
            var audioController = new CoreAudioController();
            _defaultPlaybackDevice = audioController.DefaultPlaybackDevice;
        }
        internal double GetVolume()
        {
            return _defaultPlaybackDevice.Volume;
        }

        internal void ChangeVolume(double changeValue)
        {
            _defaultPlaybackDevice.SetVolumeAsync(changeValue);
        }

        internal void Mute()
        {
            _defaultPlaybackDevice.SetMuteAsync(true);
        }

        internal void ShutDown()
        {
            System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
        }
    }
}
