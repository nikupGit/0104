using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsAppPortScan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            int beginPort = (int)nBeginPort.Value;
            int endPort = (int)nEndPort.Value;
            IPAddress addr = IPAddress.Parse(tIPAddress.Text);

            progressBar1.Maximum = endPort - beginPort + 1;
            progressBar1.Value = 0;
            listView1.Items.Clear();

            // Запуск сканирования в отдельном потоке для избежания блокировки UI
            new System.Threading.Thread(() =>
            {
                for (int port = beginPort; port <= endPort; port++)
                {
                    ScanPort(addr, port, beginPort);
                }
            }).Start();
        }

        private void ScanPort(IPAddress addr, int port, int startPort)
        {
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    IAsyncResult result = socket.BeginConnect(addr, port, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(30, false);

                    string status = success ? "открыт" : "закрыт";
                    UpdateListView(port, status);
                    UpdateProgressBar();
                    socket.Close();
                }
            }
            catch
            {
                UpdateListView(port, "ошибка");
                UpdateProgressBar();
            }
        }

        private void UpdateListView(int port, string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, string>(UpdateListView), port, status);
                return;
            }

            ListViewItem item = new ListViewItem($"Порт {port}");
            item.SubItems.Add(status);
            listView1.Items.Add(item);
        }

        private void UpdateProgressBar()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateProgressBar));
                return;
            }

            progressBar1.Value++;
        }
    }
}