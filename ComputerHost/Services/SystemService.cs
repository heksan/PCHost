using ComputerHost.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ComputerHost.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SystemService : ISystemService
    {
        private SystemController _systemController;
        public SystemService()
        {
            _systemController = new SystemController();
        }
        public void ChangeVolume(double ChangeValue)
        {
            _systemController.ChangeVolume(ChangeValue);
        }

        public string CheckConnection()
        {
            return string.Format("Hello");
        }

        public double GetVolume()
        {
            return _systemController.GetVolume();
        }

        public void Mute()
        {
            _systemController.Mute();
        }

        public void ShutDown()
        {
            _systemController.ShutDown();
        }
    }
}
