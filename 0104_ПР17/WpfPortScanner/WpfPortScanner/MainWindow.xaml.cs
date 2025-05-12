using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;


namespace WpfPortScanner
{
    public partial class MainWindow : Window
    {
        public class PortResult
        {
            public int Port { get; set; }
            public string Status { get; set; }
        }

        private ObservableCollection<PortResult> results = new ObservableCollection<PortResult>();
        private int totalPorts;
        private int scannedPorts;

        public MainWindow()
        {
            InitializeComponent();
            listResults.ItemsSource = results;
        }

        private async void BtnScan_Click(object sender, RoutedEventArgs e)
        {
            if (!IPAddress.TryParse(txtIP.Text, out IPAddress ip))
            {
                System.Windows.MessageBox.Show("Неверный IP-адрес");
                return;
            }

            int start = (int)numStart.Value;
            int end = (int)numEnd.Value;

            results.Clear();
            totalPorts = end - start + 1;
            scannedPorts = 0;
            progressBar.Value = 0;
            btnScan.IsEnabled = false;

            await Task.Run(() =>
            {
                Parallel.For(start, end + 1, new ParallelOptions { MaxDegreeOfParallelism = 50 }, port =>
                {
                    CheckPort(ip, port);
                    UpdateProgress();
                });
            });

            btnScan.IsEnabled = true;
        }

        private void CheckPort(IPAddress ip, int port)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    var result = client.BeginConnect(ip, port, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(100);
                    client.EndConnect(result);

                    UpdateResults(port, success ? "открыт" : "закрыт");
                }
            }
            catch
            {
                UpdateResults(port, "закрыт");
            }
        }

        private void UpdateResults(int port, string status)
        {
            Dispatcher.Invoke(() =>
            {
                results.Add(new PortResult { Port = port, Status = status });
            });
        }

        private void UpdateProgress()
        {
            Interlocked.Increment(ref scannedPorts);
            Dispatcher.Invoke(() =>
            {
                progressBar.Value = (double)scannedPorts / totalPorts * 100;
            });
        }
    }
}