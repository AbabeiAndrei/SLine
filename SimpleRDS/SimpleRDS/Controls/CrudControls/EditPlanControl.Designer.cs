namespace SimpleRDS.Controls.CrudControls
{
    partial class EditPlanControl
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblPricePlan = new System.Windows.Forms.Label();
            this.cbPricePlan = new System.Windows.Forms.ComboBox();
            this.lblActiveFrom = new System.Windows.Forms.Label();
            this.dtpActiveFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpActiveTo = new System.Windows.Forms.DateTimePicker();
            this.lblActiveUntil = new System.Windows.Forms.Label();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 21);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nume";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(100, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(513, 29);
            this.txtName.TabIndex = 1;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(12, 60);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(38, 21);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "Pret";
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(100, 56);
            this.nudPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(198, 29);
            this.nudPrice.TabIndex = 3;
            this.nudPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPricePlan
            // 
            this.lblPricePlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPricePlan.AutoSize = true;
            this.lblPricePlan.Location = new System.Drawing.Point(322, 60);
            this.lblPricePlan.Name = "lblPricePlan";
            this.lblPricePlan.Size = new System.Drawing.Size(100, 21);
            this.lblPricePlan.TabIndex = 4;
            this.lblPricePlan.Text = "Interval plata";
            // 
            // cbPricePlan
            // 
            this.cbPricePlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPricePlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPricePlan.FormattingEnabled = true;
            this.cbPricePlan.Location = new System.Drawing.Point(428, 56);
            this.cbPricePlan.Name = "cbPricePlan";
            this.cbPricePlan.Size = new System.Drawing.Size(185, 29);
            this.cbPricePlan.TabIndex = 5;
            // 
            // lblActiveFrom
            // 
            this.lblActiveFrom.AutoSize = true;
            this.lblActiveFrom.Location = new System.Drawing.Point(12, 111);
            this.lblActiveFrom.Name = "lblActiveFrom";
            this.lblActiveFrom.Size = new System.Drawing.Size(81, 21);
            this.lblActiveFrom.TabIndex = 6;
            this.lblActiveFrom.Text = "Activ de la";
            // 
            // dtpActiveFrom
            // 
            this.dtpActiveFrom.Checked = false;
            this.dtpActiveFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActiveFrom.Location = new System.Drawing.Point(100, 107);
            this.dtpActiveFrom.Name = "dtpActiveFrom";
            this.dtpActiveFrom.ShowCheckBox = true;
            this.dtpActiveFrom.Size = new System.Drawing.Size(198, 29);
            this.dtpActiveFrom.TabIndex = 7;
            this.dtpActiveFrom.ValueChanged += new System.EventHandler(this.dtpActiveFrom_ValueChanged);
            // 
            // dtpActiveTo
            // 
            this.dtpActiveTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpActiveTo.Checked = false;
            this.dtpActiveTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActiveTo.Location = new System.Drawing.Point(428, 107);
            this.dtpActiveTo.Name = "dtpActiveTo";
            this.dtpActiveTo.ShowCheckBox = true;
            this.dtpActiveTo.Size = new System.Drawing.Size(185, 29);
            this.dtpActiveTo.TabIndex = 9;
            this.dtpActiveTo.ValueChanged += new System.EventHandler(this.dtpActiveTo_ValueChanged);
            // 
            // lblActiveUntil
            // 
            this.lblActiveUntil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActiveUntil.AutoSize = true;
            this.lblActiveUntil.Location = new System.Drawing.Point(322, 111);
            this.lblActiveUntil.Name = "lblActiveUntil";
            this.lblActiveUntil.Size = new System.Drawing.Size(98, 21);
            this.lblActiveUntil.TabIndex = 8;
            this.lblActiveUntil.Text = "Activ pana la";
            // 
            // cbState
            // 
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.FormattingEnabled = true;
            this.cbState.Location = new System.Drawing.Point(100, 153);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(198, 29);
            this.cbState.TabIndex = 11;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(12, 156);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(45, 21);
            this.lblState.TabIndex = 10;
            this.lblState.Text = "Stare";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(513, 205);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 40);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // EditPlanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.dtpActiveTo);
            this.Controls.Add(this.lblActiveUntil);
            this.Controls.Add(this.dtpActiveFrom);
            this.Controls.Add(this.lblActiveFrom);
            this.Controls.Add(this.cbPricePlan);
            this.Controls.Add(this.lblPricePlan);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "EditPlanControl";
            this.Size = new System.Drawing.Size(626, 248);
            this.Load += new System.EventHandler(this.EditPlanControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lblPricePlan;
        private System.Windows.Forms.ComboBox cbPricePlan;
        private System.Windows.Forms.Label lblActiveFrom;
        private System.Windows.Forms.DateTimePicker dtpActiveFrom;
        private System.Windows.Forms.DateTimePicker dtpActiveTo;
        private System.Windows.Forms.Label lblActiveUntil;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnOk;
    }
}
