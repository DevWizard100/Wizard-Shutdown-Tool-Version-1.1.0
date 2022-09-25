using System.CodeDom;
using System.Diagnostics;

namespace Wizard_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)

        {
            // string strCmdText;
            // strCmdText = "/c shutdown -a";
            // System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            var startcancel = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C shutdown -a",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            Process.Start(startcancel);

            label9.Text = ("The process was canceled!");
            button7.Text = ("1. St");
            button1.Text = ("2. St");
            button4.Text = ("3. St");
            button6.Text = ("4. St");
            button5.Text = ("5. St");
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // string strCmdText;
            // strCmdText = "/c shutdown -s -t 7200";
            // System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            var start1 = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C shutdown -s -t 7200",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            Process.Start(start1);

            button1.Text = ("active");
            label9.Text = ("");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // string strCmdText;
            // strCmdText = "/c shutdown -s -t 10800";
            // System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            var start2 = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C shutdown -s -t 10800",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            Process.Start(start2);

            button4.Text = ("active");
            label9.Text = ("");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // string strCmdText;
            // strCmdText = "/c shutdown -s -t 14400";
            // System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            var start3 = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C shutdown -s -t 14400",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            Process.Start(start3);

            button6.Text = ("active");
            label9.Text = ("");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // string strCmdText;
            // strCmdText = "/c shutdown -s -t 18000";
            // System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            var start4 = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C shutdown -s -t 18000",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            Process.Start(start4);

            button5.Text = ("active");
            label9.Text = ("");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // string strCmdText;
            // strCmdText = "/c shutdown -s -t 3600";
            // System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            var start5 = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C shutdown -s -t 3600",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            Process.Start(start5);

            button7.Text = ("active");
            label9.Text = ("");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var shutdown1 = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C shutdown -s",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            Process.Start(shutdown1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var restart = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C shutdown -r",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            Process.Start(restart);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}