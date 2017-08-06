namespace SimpleRDS.Controls.CrudControls
{
    partial class EditSubscriptionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPlan = new System.Windows.Forms.Label();
            this.cbPlan = new System.Windows.Forms.ComboBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.dtpActiveFrom = new System.Windows.Forms.DateTimePicker();
            this.lblActiveFrom = new System.Windows.Forms.Label();
            this.lblEnds = new System.Windows.Forms.Label();
            this.dtpEnds = new System.Windows.Forms.DateTimePicker();
            this.lblExpireAt = new System.Windows.Forms.Label();
            this.dtpExpireAt = new System.Windows.Forms.DateTimePicker();
            this.lblCreated = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(3, 10);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(40, 21);
            this.lblPlan.TabIndex = 0;
            this.lblPlan.Text = "Plan";
            // 
            // cbPlan
            // 
            this.cbPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlan.FormattingEnabled = true;
            this.cbPlan.Location = new System.Drawing.Point(111, 7);
            this.cbPlan.Name = "cbPlan";
            this.cbPlan.Size = new System.Drawing.Size(200, 29);
            this.cbPlan.TabIndex = 0;
            this.cbPlan.SelectedIndexChanged += new System.EventHandler(this.cbPlan_SelectedIndexChanged);
            // 
            // cmbState
            // 
            this.cmbState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(111, 90);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(200, 29);
            this.cmbState.TabIndex = 1;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(3, 93);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(45, 21);
            this.lblState.TabIndex = 2;
            this.lblState.Text = "Stare";
            // 
            // dtpActiveFrom
            // 
            this.dtpActiveFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpActiveFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActiveFrom.Location = new System.Drawing.Point(111, 139);
            this.dtpActiveFrom.Name = "dtpActiveFrom";
            this.dtpActiveFrom.Size = new System.Drawing.Size(200, 29);
            this.dtpActiveFrom.TabIndex = 2;
            this.dtpActiveFrom.ValueChanged += new System.EventHandler(this.dtpActiveFrom_ValueChanged);
            // 
            // lblActiveFrom
            // 
            this.lblActiveFrom.AutoSize = true;
            this.lblActiveFrom.Location = new System.Drawing.Point(3, 145);
            this.lblActiveFrom.Name = "lblActiveFrom";
            this.lblActiveFrom.Size = new System.Drawing.Size(81, 21);
            this.lblActiveFrom.TabIndex = 5;
            this.lblActiveFrom.Text = "Activ de la";
            // 
            // lblEnds
            // 
            this.lblEnds.AutoSize = true;
            this.lblEnds.Location = new System.Drawing.Point(3, 191);
            this.lblEnds.Name = "lblEnds";
            this.lblEnds.Size = new System.Drawing.Size(96, 21);
            this.lblEnds.TabIndex = 7;
            this.lblEnds.Text = "Se incheie la";
            // 
            // dtpEnds
            // 
            this.dtpEnds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEnds.Checked = false;
            this.dtpEnds.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnds.Location = new System.Drawing.Point(111, 185);
            this.dtpEnds.Name = "dtpEnds";
            this.dtpEnds.ShowCheckBox = true;
            this.dtpEnds.Size = new System.Drawing.Size(200, 29);
            this.dtpEnds.TabIndex = 3;
            this.dtpEnds.ValueChanged += new System.EventHandler(this.dtpEnds_ValueChanged);
            // 
            // lblExpireAt
            // 
            this.lblExpireAt.AutoSize = true;
            this.lblExpireAt.Location = new System.Drawing.Point(3, 238);
            this.lblExpireAt.Name = "lblExpireAt";
            this.lblExpireAt.Size = new System.Drawing.Size(68, 21);
            this.lblExpireAt.TabIndex = 9;
            this.lblExpireAt.Text = "Expira la";
            // 
            // dtpExpireAt
            // 
            this.dtpExpireAt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpExpireAt.Checked = false;
            this.dtpExpireAt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpireAt.Location = new System.Drawing.Point(111, 232);
            this.dtpExpireAt.Name = "dtpExpireAt";
            this.dtpExpireAt.ShowCheckBox = true;
            this.dtpExpireAt.Size = new System.Drawing.Size(200, 29);
            this.dtpExpireAt.TabIndex = 4;
            this.dtpExpireAt.ValueChanged += new System.EventHandler(this.dtpExpireAt_ValueChanged);
            // 
            // lblCreated
            // 
            this.lblCreated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreated.Location = new System.Drawing.Point(7, 381);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(304, 52);
            this.lblCreated.TabIndex = 10;
            this.lblCreated.Text = "Creat de {0} la data de {1}";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(211, 436);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 40);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "Ok";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(3, 275);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(58, 21);
            this.lblAddress.TabIndex = 12;
            this.lblAddress.Text = "Adresa";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(111, 275);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(200, 103);
            this.txtAddress.TabIndex = 5;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Location = new System.Drawing.Point(7, 45);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(304, 29);
            this.lblInfo.TabIndex = 13;
            // 
            // EditSubscriptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblCreated);
            this.Controls.Add(this.lblExpireAt);
            this.Controls.Add(this.dtpExpireAt);
            this.Controls.Add(this.lblEnds);
            this.Controls.Add(this.dtpEnds);
            this.Controls.Add(this.lblActiveFrom);
            this.Controls.Add(this.dtpActiveFrom);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.cbPlan);
            this.Controls.Add(this.lblPlan);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "EditSubscriptionControl";
            this.Size = new System.Drawing.Size(318, 479);
            this.Load += new System.EventHandler(this.EditSubscriptionControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.ComboBox cbPlan;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.DateTimePicker dtpActiveFrom;
        private System.Windows.Forms.Label lblActiveFrom;
        private System.Windows.Forms.Label lblEnds;
        private System.Windows.Forms.DateTimePicker dtpEnds;
        private System.Windows.Forms.Label lblExpireAt;
        private System.Windows.Forms.DateTimePicker dtpExpireAt;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblInfo;
    }
}
