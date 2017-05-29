using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCJackHost
{
    public partial class PCHost : Form
    {
        public PCHost()
        {
            InitializeComponent();
            App = new ServerApp();
        }
        

        private void StartButton_Click(object sender, EventArgs e)
        {
            string ip = App.Start();
            IPLabel.Text = ip;
        }
        public ServerApp App { get; set; }

        private void IPLabel_SizeChanged(object sender, EventArgs e)
        {
            IPLabel.Left = (this.ClientSize.Width - IPLabel.Size.Width) / 2;
        }

        private void Close(object sender, FormClosedEventArgs e)
        {
            App.Stop();
            base.Close();
        }
    }
}
