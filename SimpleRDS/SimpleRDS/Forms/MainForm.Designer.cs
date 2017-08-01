
namespace SimpleRDS.Forms
{
    partial class MainForm
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHello = new System.Windows.Forms.Label();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpClients = new System.Windows.Forms.TabPage();
            this.ucClients = new SimpleRDS.Controls.ClientsUserControl();
            this.tpUsers = new System.Windows.Forms.TabPage();
            this.ucAcounts = new SimpleRDS.Controls.AccuntsUserControl();
            this.tpPlans = new System.Windows.Forms.TabPage();
            this.ucPlans = new SimpleRDS.Controls.PlansUserControl();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.ucSettings = new SimpleRDS.Controls.SettingsUserControl();
            this.tcMain.SuspendLayout();
            this.tpClients.SuspendLayout();
            this.tpUsers.SuspendLayout();
            this.tpPlans.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHello
            // 
            this.lblHello.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHello.Location = new System.Drawing.Point(0, 0);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(1184, 24);
            this.lblHello.TabIndex = 0;
            this.lblHello.Text = "Salut {USER}";
            this.lblHello.Visible = false;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpClients);
            this.tcMain.Controls.Add(this.tpUsers);
            this.tcMain.Controls.Add(this.tpPlans);
            this.tcMain.Controls.Add(this.tpSettings);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 24);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1184, 742);
            this.tcMain.TabIndex = 1;
            this.tcMain.Visible = false;
            // 
            // tpClients
            // 
            this.tpClients.Controls.Add(this.ucClients);
            this.tpClients.Location = new System.Drawing.Point(4, 30);
            this.tpClients.Name = "tpClients";
            this.tpClients.Padding = new System.Windows.Forms.Padding(3);
            this.tpClients.Size = new System.Drawing.Size(1176, 708);
            this.tpClients.TabIndex = 0;
            this.tpClients.Text = "Clienti";
            this.tpClients.UseVisualStyleBackColor = true;
            // 
            // ucClients
            // 
            this.ucClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucClients.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucClients.Location = new System.Drawing.Point(3, 3);
            this.ucClients.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucClients.Name = "ucClients";
            this.ucClients.Size = new System.Drawing.Size(1170, 702);
            this.ucClients.TabIndex = 0;
            // 
            // tpUsers
            // 
            this.tpUsers.Controls.Add(this.ucAcounts);
            this.tpUsers.Location = new System.Drawing.Point(4, 30);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsers.Size = new System.Drawing.Size(650, 425);
            this.tpUsers.TabIndex = 1;
            this.tpUsers.Text = "Utilizatori";
            this.tpUsers.UseVisualStyleBackColor = true;
            // 
            // ucAcounts
            // 
            this.ucAcounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAcounts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucAcounts.Location = new System.Drawing.Point(3, 3);
            this.ucAcounts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucAcounts.Name = "ucAcounts";
            this.ucAcounts.Size = new System.Drawing.Size(644, 419);
            this.ucAcounts.TabIndex = 0;
            // 
            // tpPlans
            // 
            this.tpPlans.Controls.Add(this.ucPlans);
            this.tpPlans.Location = new System.Drawing.Point(4, 30);
            this.tpPlans.Name = "tpPlans";
            this.tpPlans.Padding = new System.Windows.Forms.Padding(3);
            this.tpPlans.Size = new System.Drawing.Size(650, 425);
            this.tpPlans.TabIndex = 3;
            this.tpPlans.Text = "Planuri";
            this.tpPlans.UseVisualStyleBackColor = true;
            // 
            // ucPlans
            // 
            this.ucPlans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPlans.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucPlans.Location = new System.Drawing.Point(3, 3);
            this.ucPlans.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucPlans.Name = "ucPlans";
            this.ucPlans.Size = new System.Drawing.Size(644, 419);
            this.ucPlans.TabIndex = 0;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.ucSettings);
            this.tpSettings.Location = new System.Drawing.Point(4, 30);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(650, 425);
            this.tpSettings.TabIndex = 2;
            this.tpSettings.Text = "Setari";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // ucSettings
            // 
            this.ucSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSettings.Location = new System.Drawing.Point(3, 3);
            this.ucSettings.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ucSettings.Name = "ucSettings";
            this.ucSettings.Size = new System.Drawing.Size(644, 419);
            this.ucSettings.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 766);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.lblHello);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tcMain.ResumeLayout(false);
            this.tpClients.ResumeLayout(false);
            this.tpUsers.ResumeLayout(false);
            this.tpPlans.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpClients;
        private System.Windows.Forms.TabPage tpUsers;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.TabPage tpPlans;
        private Controls.SettingsUserControl ucSettings;
        private Controls.ClientsUserControl ucClients;
        private Controls.AccuntsUserControl ucAcounts;
        private Controls.PlansUserControl ucPlans;
    }
}