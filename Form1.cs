using System.Diagnostics;
using System.Drawing;
using System;

namespace Wizard_Calculator
{
    public partial class Form1 : Form
    {

        TimeSpan timeLeft;


        public Form1()
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(399, 390);
            if (WindowState == FormWindowState.Minimized)
            {
                MessageBox.Show("test");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timerPerformance.Start();
            PerformaceTimer.Start();
            GetAllProcesses();
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
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult restartbox = MessageBox.Show("Confirm the restart ", "Cancel", MessageBoxButtons.YesNo);

            if (DialogResult.Yes == restartbox)
            {
                Application.Restart();
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Want to stop the process?", "Confirm the process", MessageBoxButtons.YesNo);

            if (DialogResult.Yes == dialogResult)
            {

            }

            if (DialogResult.No == dialogResult)
            {

            }
        }

        //Timer:
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
            lblTimer.Text = timeLeft.ToString(@"hh\:mm\:ss");

            if (timeLeft.TotalSeconds <= 0)
            {
                timer.Stop();
                PerfromAction();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Text = "Run";

            label9.Text = "";

            CheckTextBoxValues();

            bool isStartable = true;


            try
            {
                timeLeft = new TimeSpan(Convert.ToInt32(txtHours.Text), Convert.ToInt32(txtMinutes.Text), Convert.ToInt32(txtSeconds.Text));
            }
            catch (FormatException ex)
            {
                isStartable = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (isStartable == true)
            {
                timer.Start();
                lblTimer.Text = timeLeft.ToString(@"hh\:mm\:ss");
            }
        }

        private void CheckTextBoxValues()
        {
            if (txtHours.Text.Count() == 0)
                txtHours.Text = "0";

            if (txtMinutes.Text.Count() == 0)
                txtMinutes.Text = "0";

            if (txtSeconds.Text.Count() == 0)
                txtSeconds.Text = "0";
        }

        private void PerfromAction()
        {
            if (rbShutdown.Checked == true)
                Process.Start("shutdown", "/s");
            else if (rbRestart.Checked == true)
                Process.Start("shutdown", "/r");
            else if (rbSavePower.Checked == true)
                Process.Start("rundll32.exe", "powrprof.dll, SetSuspendState");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            lblTimer.Text = "00:00:00";
            label9.Text = ("The process was canceled!");
            btnStart.Text = "Start";
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Process.Start("winver.exe");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string filePath = openFileDialog1.FileName;
                MessageBox.Show(" - " + filePath);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
        }

        //Performance Check

        PerformanceCounter cpucheck = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        PerformanceCounter ramcheck = new PerformanceCounter("Memory", "Available MBytes");


        private void PerformaceTimer_Tick(object sender, EventArgs e)
        {
            lbl_ram.Text = ((int)ramcheck.NextValue() + " MB");
            lbl_cpu.Text = ((int)cpucheck.NextValue() + " %");

            this.Text = ("Wizard System Tools - " + (int)ramcheck.NextValue() + " MB");
        }

        private void checkcpurambtn_CheckedChanged(object sender, EventArgs e)
        {
            if (checkcpurambtn.Checked)
            {
                lbl_cpu.Text = ("0 %");
                lbl_ram.Text = ("0 MB");
                this.Text = "Wizard System Tools - 0 MB";
                PerformaceTimer.Start();
                checkcpurambtn.Text = ("Enabled");

            }
            else
            {
                PerformaceTimer.Stop();

                checkcpurambtn.Text = ("Disabled");
                lbl_ram.Text = ("Disabled.");
                lbl_cpu.Text = ("Disabled.");
                this.Text = "Wizard System Tools";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (radioButtonfast.Checked)
            {
                PerformaceTimer.Interval = 500;
                updatespeedlbl.Text = ("Update Speed: Fast");
            }
            else if (radioButtonnormal.Checked)
            {
                PerformaceTimer.Interval = 1000;
                updatespeedlbl.Text = ("Update Speed: Normal");
            }
            else if (radioButtonslow.Checked)
            {
                PerformaceTimer.Interval = 1500;
                updatespeedlbl.Text = ("Update Speed: Slow");
            }
        }

        Process[] proc;


       void GetAllProcesses()
        {
            listboxprocesses.Sorted = false;
            proc = Process.GetProcesses();
            listboxprocesses.Items.Clear();
            foreach (Process p in proc)
                listboxprocesses.Items.Add(p.ProcessName);

            
        }

        private void reloadtasksbtn_Click(object sender, EventArgs e)
        {
            if(checkBoxShowTasks.Checked)
            {
                GetAllProcesses();
            }
            else
            {
                MessageBox.Show("Enable Show Tasks");
            }
        }

        private void endtaskbtn_Click(object sender, EventArgs e)
        {
            
            try
            {
                string test = listboxprocesses.SelectedItem.ToString();

                DialogResult = DialogResult = MessageBox.Show("Are you sure you want to kill " + test + ".exe?", "Process Explorer", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("no process selected.");
            }

            

            if(DialogResult == DialogResult.OK)
            {
                try
                {
                    proc[listboxprocesses.SelectedIndex].Kill();
                    GetAllProcesses();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
       
        }

        //Stopuhr !!

        TimeSpan time2left;
        private void button17_Click(object sender, EventArgs e)
        {
            if (HouresTxt.Text.Count() ==0)
            {
                HouresTxt.Text = "0";
            }
            if (MinutesTxt.Text.Count() ==0)
            {
                MinutesTxt.Text = "0";
            }
            if (SecondsTxt.Text.Count() ==0)
            {
                SecondsTxt.Text = "0";
            }

            bool startbar = true;

            if (TimerLabel.Text == "00:00:00")
            {
                try
                {
                    time2left = new TimeSpan(Convert.ToInt32(HouresTxt.Text), Convert.ToInt32(MinutesTxt.Text), Convert.ToInt32(SecondsTxt.Text));
                }
                catch (FormatException ex)
                {
                    startbar = false;
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            if (startbar == true)
            {
                timer2.Start();
                TimerLabel.Text = time2left.ToString(@"hh\:mm\:ss");
            }

            button17.Text = "Start";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            time2left = time2left.Subtract(TimeSpan.FromSeconds(1));
            TimerLabel.Text = time2left.ToString(@"hh\:mm\:ss");

            if (time2left.TotalSeconds <= 0)
            {
                timer2.Stop();
                MessageBox.Show("Zeit ist abgelaufen");

            }
        }

        private void StopTimer2_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            button17.Text = "continue";
        }

        private void ResetTimer2_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            TimerLabel.Text = "00:00:00";
            button17.Text = "Start";
        }

        TimeSpan TimeStopwatch;
        private void StopwatchTimer_Tick(object sender, EventArgs e)
        {
            TimeStopwatch = TimeStopwatch.Add(TimeSpan.FromSeconds(1));
            lblStopwatch.Text = TimeStopwatch.ToString(@"hh\:mm\:ss");
        }

        private void Stopwatchstartbtn_Click(object sender, EventArgs e)
        {
            StopwatchTimer.Start();
            lblStopwatch.Text = TimeStopwatch.ToString(@"hh\:mm\:ss");
        }

        private void Stopwatchstopbtn_Click(object sender, EventArgs e)
        {
            StopwatchTimer.Stop();
        }

        private void Stopwatchresetbtn_Click(object sender, EventArgs e)
        {
            lblStopwatch.Text = "00:00:00";

        }

        private void Sortprocessitems_Click(object sender, EventArgs e)
        {
            listboxprocesses.Sorted = true;
        }

        private void checkBoxShowTasks_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxShowTasks.Checked)
            {
                GetAllProcesses();
                reloadtasksbtn.Enabled = true;
            }
            else
            {
                listboxprocesses.Items.Clear();
                reloadtasksbtn.Enabled = false;
            }
        }






























        //Disclaimer: Attention from here on there is very unclear and poorly written code as it was my first project please do not take an example from me thanks :)

        //Short Shutdown Time Presets

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


        //Cancel Shutdown Process
        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Want to stop the process?", "Cancel", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
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

                timer.Stop();
                lblTimer.Text = "00:00:00";
                btnStart.Text = "Start";
            }

            // string strCmdText;
            // strCmdText = "/c shutdown -a";
            // System.Diagnostics.Process.Start("CMD.exe", strCmdText);
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
            DialogResult = DialogResult = MessageBox.Show("Do you really want to restart the pc?", "Cancel", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (DialogResult == DialogResult.OK)
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
        }

        private void button9_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult = MessageBox.Show("Do you really want to restart the pc?", "Cancel", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (DialogResult == DialogResult.OK)
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
        }
    }
}


