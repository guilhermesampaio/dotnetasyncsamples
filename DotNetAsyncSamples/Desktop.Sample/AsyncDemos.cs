using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Sample
{
    public partial class AsyncDemos : Form
    {
        public AsyncDemos()
        {
            InitializeComponent();
        }

        private void syncData_Click(object sender, EventArgs e)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            txtLog.AppendText("Sync Data: Message from sync data" + Environment.NewLine);
        }

        private async void AsyncData_Click(object sender, EventArgs e)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            txtLog.AppendText("Async Data: Message from async data" + Environment.NewLine);
        }
    }
}
