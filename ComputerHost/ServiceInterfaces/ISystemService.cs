using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ComputerHost
{
    [ServiceContract]
    public interface ISystemService
    {
        [OperationContract]
        string CheckConnection();
        [OperationContract]
        void ChangeVolume(double ChangeValue);
        [OperationContract]
        double GetVolume();
        [OperationContract]
        void Mute();
        [OperationContract]
        void ShutDown();

    }
}
