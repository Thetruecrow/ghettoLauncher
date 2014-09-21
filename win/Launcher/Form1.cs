using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PostComponentInitialization();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            bool found = false;
            int index = 0;
            for (; index < 4; index++)
            {
                if (buttons[index] == sender)
                {
                    found = true;
                    index += this.m_indexOffset;
                    break;
                }
            }

            if (found && m_installLocations[index].Length > 0)
            {
                System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
                start.Arguments = "";
                start.FileName = System.String.Copy(m_installLocations[index]);
                if(this.m_is64BitInstall[index])
                    start.FileName += "\\wow-64.exe";
                else start.FileName += "\\wow.exe";
                this.WindowState = FormWindowState.Minimized;
                // Run the external process & wait for it to finish
                try
                {
                    using (System.Diagnostics.Process proc = System.Diagnostics.Process.Start(start))
                        proc.WaitForExit();
                }
                catch (Exception)
                { Close_Click(sender, e); return; }
                this.WindowState = FormWindowState.Normal;
            } else Close_Click(sender, e);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close_Click(sender, e);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateButtons();
        }
    }
}
