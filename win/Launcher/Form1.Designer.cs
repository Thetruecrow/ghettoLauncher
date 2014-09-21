
namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        ///
        /// 
        /// 
        int m_InstallLocationCount;
        System.String m_NameStacks, m_LocationStacks, m_ImageStacks;
        System.String[] m_installNames;
        System.String [] m_installLocations;
        System.Drawing.Image[] m_installImages;
        private System.Windows.Forms.Button[] buttons;

        private void ParseLine(System.String line)
        {
            int equator = line.IndexOf("=");
            if (equator == 0) // Ignore lines without an equator
                return;
            else equator++; // Increment the equator to skip the equal

            if (line.StartsWith("#InstallCount"))
                m_InstallLocationCount = System.Convert.ToInt32(line.Substring(equator, line.Length-equator));
            else if (line.StartsWith("#InstallNames"))
            {
                int quote1 = line.IndexOf('"') + 1, quote2 = line.LastIndexOf('"');
                m_NameStacks = line.Substring(quote1, quote2 - quote1);
            }
            else if (line.StartsWith("#InstallLocations"))
            {
                int quote1 = line.IndexOf('"') + 1, quote2 = line.LastIndexOf('"');
                m_LocationStacks = line.Substring(quote1, quote2 - quote1);
            }
            else if (line.StartsWith("#InstallImages"))
            {
                int quote1 = line.IndexOf('"') + 1, quote2 = line.LastIndexOf('"');
                m_ImageStacks = line.Substring(quote1, quote2 - quote1);
            }
        }

        private void LoadIniData()
        {
            m_InstallLocationCount = 0;
            m_NameStacks = m_LocationStacks = m_ImageStacks = "";
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader("settings.ini"))
                { while (!sr.EndOfStream) { ParseLine(sr.ReadLine()); } }
            } catch (System.Exception) { }

            if (m_InstallLocationCount == 0)
                return;
            buttons = new System.Windows.Forms.Button[m_InstallLocationCount];
            m_installLocations = new System.String[m_InstallLocationCount];
            m_installNames = new System.String[m_InstallLocationCount];
            m_installImages = new System.Drawing.Image[m_InstallLocationCount];
            for (int i = 0; i < m_InstallLocationCount; i++)
            {
                m_installNames[i] = "";
                m_installImages[i] = global::WoW_Launcher.Properties.Resources.wow_normal;
            }

            int index = 0, length;
            while ((length = m_NameStacks.IndexOf(";")) > 0)
            {
                m_installNames[index] = m_NameStacks.Substring(0, length);
                m_NameStacks = m_NameStacks.Substring(length + 1, m_NameStacks.Length - (length + 1));
                index++;
            }
            index = 0;
            while ((length = m_LocationStacks.IndexOf(";")) > 0)
            {
                m_installLocations[index] = m_LocationStacks.Substring(0, length);
                m_LocationStacks = m_LocationStacks.Substring(length + 1, m_LocationStacks.Length - (length + 1));
                index++;
            }
            index = 0;
            while ((length = m_ImageStacks.IndexOf(";")) > 0)
            {
                int iconType = System.Convert.ToInt32(m_ImageStacks.Substring(0, length));
                m_ImageStacks = m_ImageStacks.Substring(length + 1, m_ImageStacks.Length - (length + 1));
                switch (iconType)
                {
                    case 1:
                        m_installImages[index] = global::WoW_Launcher.Properties.Resources.wow_bc_normal;
                        break;
                    case 2:
                        m_installImages[index] = global::WoW_Launcher.Properties.Resources.wow_wotlk_normal;
                        break;
                    case 3:
                        m_installImages[index] = global::WoW_Launcher.Properties.Resources.wow_cat_normal;
                        break;
                    default:
                        m_installImages[index] = global::WoW_Launcher.Properties.Resources.wow_normal;
                        break;
                }
                index++;
            }
        }

        private void InitializeButtons()
        {
            LoadIniData();
            for (int i = 0; i < m_InstallLocationCount; i++)
            {
                this.buttons[i] = new System.Windows.Forms.Button();
                this.buttons[i].BackColor = System.Drawing.Color.Transparent;
                this.buttons[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                this.buttons[i].Enabled = true;
                this.buttons[i].FlatAppearance.BorderColor = System.Drawing.Color.White;
                this.buttons[i].FlatAppearance.BorderSize = 0;
                this.buttons[i].FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
                this.buttons[i].FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                this.buttons[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.buttons[i].Image = m_installImages[i];
                this.buttons[i].Location = new System.Drawing.Point(40, 40 + (138 * i));
                this.buttons[i].Name = m_installNames[i];
                this.buttons[i].Size = new System.Drawing.Size(128, 128);
                this.buttons[i].TabIndex = 2;
                this.buttons[i].UseVisualStyleBackColor = false;
                this.buttons[i].Click += new System.EventHandler(this.buttonClick);
                this.Controls.Add(this.buttons[i]);
            }
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitbuttonfaggot = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Transparent;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Close.ForeColor = System.Drawing.Color.Transparent;
            this.Close.Location = new System.Drawing.Point(987, 9);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(25, 25);
            this.Close.TabIndex = 0;
            this.Close.Text = "X";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(208, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 548);
            this.panel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.exitbuttonfaggot});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(227, 26);
            this.toolStripMenuItem1.Text = "Set Install Locations";
            // 
            // exitbuttonfaggot
            // 
            this.exitbuttonfaggot.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbuttonfaggot.Name = "exitbuttonfaggot";
            this.exitbuttonfaggot.Size = new System.Drawing.Size(227, 26);
            this.exitbuttonfaggot.Text = "Exit Launcher";
            this.exitbuttonfaggot.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::WoW_Launcher.Properties.Resources.BurningCrusade;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitbuttonfaggot;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

