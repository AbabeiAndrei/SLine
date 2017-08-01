namespace SimpleRDS.Controls
{
    partial class SettingsUserControl
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
            this.nudInvoiceNumber = new System.Windows.Forms.NumericUpDown();
            this.txtInvoiceSeries = new System.Windows.Forms.TextBox();
            this.lblInvoiceStartNumber = new System.Windows.Forms.Label();
            this.lblInvoiceSeries = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudInvoiceNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // nudInvoiceNumber
            // 
            this.nudInvoiceNumber.Location = new System.Drawing.Point(184, 53);
            this.nudInvoiceNumber.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudInvoiceNumber.Name = "nudInvoiceNumber";
            this.nudInvoiceNumber.Size = new System.Drawing.Size(134, 29);
            this.nudInvoiceNumber.TabIndex = 11;
            this.nudInvoiceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInvoiceSeries
            // 
            this.txtInvoiceSeries.Location = new System.Drawing.Point(184, 9);
            this.txtInvoiceSeries.Name = "txtInvoiceSeries";
            this.txtInvoiceSeries.Size = new System.Drawing.Size(134, 29);
            this.txtInvoiceSeries.TabIndex = 10;
            // 
            // lblInvoiceStartNumber
            // 
            this.lblInvoiceStartNumber.AutoSize = true;
            this.lblInvoiceStartNumber.Location = new System.Drawing.Point(11, 55);
            this.lblInvoiceStartNumber.Name = "lblInvoiceStartNumber";
            this.lblInvoiceStartNumber.Size = new System.Drawing.Size(111, 21);
            this.lblInvoiceStartNumber.TabIndex = 9;
            this.lblInvoiceStartNumber.Text = "Numar factura";
            // 
            // lblInvoiceSeries
            // 
            this.lblInvoiceSeries.AutoSize = true;
            this.lblInvoiceSeries.Location = new System.Drawing.Point(11, 12);
            this.lblInvoiceSeries.Name = "lblInvoiceSeries";
            this.lblInvoiceSeries.Size = new System.Drawing.Size(97, 21);
            this.lblInvoiceSeries.TabIndex = 8;
            this.lblInvoiceSeries.Text = "Serie factura";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(3, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(126, 43);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Resetare";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(197, 167);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 43);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Salvare";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SettingsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudInvoiceNumber);
            this.Controls.Add(this.txtInvoiceSeries);
            this.Controls.Add(this.lblInvoiceStartNumber);
            this.Controls.Add(this.lblInvoiceSeries);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "SettingsUserControl";
            this.Size = new System.Drawing.Size(326, 213);
            ((System.ComponentModel.ISupportInitialize)(this.nudInvoiceNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudInvoiceNumber;
        private System.Windows.Forms.TextBox txtInvoiceSeries;
        private System.Windows.Forms.Label lblInvoiceStartNumber;
        private System.Windows.Forms.Label lblInvoiceSeries;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}
