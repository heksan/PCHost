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

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostYT = new ServiceHost(typeof(YouTubeService));
            hostYT.AddServiceEndpoint(typeof(IYouTubeService), new BasicHttpBinding(), GetValidEthernetAddress("youtube"));
            ServiceHost hostSystem = new ServiceHost(typeof(SystemService));
            hostSystem.AddServiceEndpoint(typeof(ISystemService), new BasicHttpBinding(), GetValidEthernetAddress("system"));
            try
            {
               hostYT.Open();
                hostSystem.Open();

#if DEBUG
                Console.WriteLine("Press enter to close...");
                Console.ReadLine();
#endif
                hostYT.Close();
                hostSystem.Close();
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
            Console.WriteLine("please type " + localIP + " in the app for "+ v);
            return String.Format("http:/"+localIP+":8082/"+v+"/basic");
            

        }

        private static string GetValidWirelessAddress(string v)
        {
            string localIP = string.Empty;
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ( ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)//ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
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
            Console.WriteLine("please type " + localIP + " in the app");
            return String.Format("http:/" + localIP + ":8082/" + v + "/basic");
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
