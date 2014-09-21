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
            InitializeButtons();
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
            int index = 0;
            for (; index < m_InstallLocationCount; index++)
                if (buttons[index] == sender)
                    break;
            if (index != m_InstallLocationCount)
            {
                System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
                start.Arguments = "";
                start.FileName = System.String.Copy(m_installLocations[index]);
                start.FileName += "\\wow.exe";
                this.WindowState = FormWindowState.Minimized;
                // Run the external process & wait for it to finish
                using (System.Diagnostics.Process proc = System.Diagnostics.Process.Start(start))
                    proc.WaitForExit();
                this.WindowState = FormWindowState.Normal;
            } else Close_Click(sender, e);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close_Click(sender, e);
        }
    }
}
