using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PICS_Compare
{
    public partial class Form1 : Form
    {
        private BackgroundWorker worker;

        public Form1()
        {
            InitializeComponent();

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

            //progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.Enabled = false;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
        }

        private void te_textBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy | DragDropEffects.Scroll;
            }
        }

        private void te_textBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                this.te_textBox.Text = "";
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                this.te_textBox.Text += files[0];
            }
        }

        private void pics_textBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy | DragDropEffects.Scroll;
            }
        }

        private void pics_textBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                this.pics_textBox.Text = "";
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                this.pics_textBox.Text += files[0];
            }
        }

        private void run_button_Click(object sender, EventArgs e)
        {
            result_textBox.Text = "";
            result_textBox.Text += te_textBox.Text + "\r\n";
            result_textBox.Text += pics_textBox.Text;

            progressBar1.Enabled = true;
            progressBar1.Value = 0;

            worker.RunWorkerAsync();
        }

        // Worker Thread가 실제 하는 일
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int pct;
            string[] players = new string[100];
            int counter = 0;

            progressBar1.Step = 100 / players.Length;

            foreach (var fi in players)
            {
                pct = ((++counter * 100) / players.Length);
                worker.ReportProgress(pct);
                Thread.Sleep(100);
            }
        }

        // Progress 리포트 - UI Thread
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this.progressBar1.Value = e.ProgressPercentage;
            result_textBox.Text = "" + e.ProgressPercentage;
            progressBar1.PerformStep();
        }

        // 작업 완료 - UI Thread
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // 에러가 있는지 체크
            if (e.Error != null)
            {
                result_textBox.Text = e.Error.Message;
                MessageBox.Show(e.Error.Message, "Error");
                return;
            }

            result_textBox.Text = "성공적으로 완료되었습니다";
        }
    }
}

