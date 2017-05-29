using ComputerHost;
using ComputerHost.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace PCJackHost
{
    public class ServerApp
    {
        ServiceHost hostYT;
        ServiceHost hostSystem;
        public ServerApp()
        {
            hostYT = new ServiceHost(typeof(YouTubeService));
            hostSystem = new ServiceHost(typeof(SystemService));
        }
        public void Stop()
        {
            hostYT.Close();
            hostSystem.Close();
        }
        public string Start()
        {
            
            hostYT.AddServiceEndpoint(typeof(IYouTubeService), new BasicHttpBinding(), GetValidEthernetAddress("youtube"));
           
            hostSystem.AddServiceEndpoint(typeof(ISystemService), new BasicHttpBinding(), GetValidEthernetAddress("system"));
            try
            {
                hostYT.Open();
                hostSystem.Open();

#if DEBUG
                Console.WriteLine("Press enter to close...");
                Console.ReadLine();
#endif
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
#if DEBUG
                Console.WriteLine("Press enter to close...");
                Console.ReadLine();
#endif
                hostYT.Abort();
                hostSystem.Abort();
            }
            return GetValidEthernetAddress("youtube");
        }

        private static string GetValidEthernetAddress(string v)
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {

                    localIP = ip.ToString();
                    //break;
                }
                Console.WriteLine(localIP);
            }
            Console.WriteLine("please type " + localIP + " in the app for " + v);
            return String.Format("Please type " + localIP + " in the app.");


        }

        private static string GetValidWirelessAddress(string v)
        {
            string localIP = string.Empty;
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)//ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            localIP = ip.Address.ToString();
                            break;
                        }
                    }
                }
            }            
            return String.Format("please type " + localIP + " in the app");
        }

        static void PrintAdresses(ServiceHost host)
        {
            foreach (ServiceEndpoint se in host.Description.Endpoints)
            {
                Console.WriteLine(se.Address);
            }
        }
    }
}

