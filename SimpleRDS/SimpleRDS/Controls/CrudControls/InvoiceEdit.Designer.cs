namespace SimpleRDS.Controls.CrudControls
{
    partial class InvoiceEdit
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
            this.rbPaidWith = new System.Windows.Forms.RadioButton();
            this.rbStorno = new System.Windows.Forms.RadioButton();
            this.txtPaidWith = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtStornoFor = new System.Windows.Forms.TextBox();
            this.rbCancel = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rbPaidWith
            // 
            this.rbPaidWith.AutoSize = true;
            this.rbPaidWith.Checked = true;
            this.rbPaidWith.Location = new System.Drawing.Point(15, 14);
            this.rbPaidWith.Name = "rbPaidWith";
            this.rbPaidWith.Size = new System.Drawing.Size(102, 25);
            this.rbPaidWith.TabIndex = 0;
            this.rbPaidWith.TabStop = true;
            this.rbPaidWith.Text = "Plateste cu";
            this.rbPaidWith.UseVisualStyleBackColor = true;
            this.rbPaidWith.CheckedChanged += new System.EventHandler(this.rdPaidWith_CheckedChanged);
            // 
            // rbStorno
            // 
            this.rbStorno.AutoSize = true;
            this.rbStorno.Location = new System.Drawing.Point(15, 58);
            this.rbStorno.Name = "rbStorno";
            this.rbStorno.Size = new System.Drawing.Size(124, 25);
            this.rbStorno.TabIndex = 1;
            this.rbStorno.Text = "Storno pentru";
            this.rbStorno.UseVisualStyleBackColor = true;
            this.rbStorno.CheckedChanged += new System.EventHandler(this.rbStorno_CheckedChanged);
            // 
            // txtPaidWith
            // 
            this.txtPaidWith.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaidWith.Location = new System.Drawing.Point(145, 13);
            this.txtPaidWith.Name = "txtPaidWith";
            this.txtPaidWith.Size = new System.Drawing.Size(144, 29);
            this.txtPaidWith.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(186, 131);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 40);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtStornoFor
            // 
            this.txtStornoFor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStornoFor.Location = new System.Drawing.Point(145, 57);
            this.txtStornoFor.Name = "txtStornoFor";
            this.txtStornoFor.Size = new System.Drawing.Size(141, 29);
            this.txtStornoFor.TabIndex = 4;
            // 
            // rbCancel
            // 
            this.rbCancel.AutoSize = true;
            this.rbCancel.Location = new System.Drawing.Point(15, 103);
            this.rbCancel.Name = "rbCancel";
            this.rbCancel.Size = new System.Drawing.Size(91, 25);
            this.rbCancel.TabIndex = 5;
            this.rbCancel.Text = "Anuleaza";
            this.rbCancel.UseVisualStyleBackColor = true;
            // 
            // InvoiceEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbCancel);
            this.Controls.Add(this.txtStornoFor);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtPaidWith);
            this.Controls.Add(this.rbStorno);
            this.Controls.Add(this.rbPaidWith);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "InvoiceEdit";
            this.Size = new System.Drawing.Size(300, 173);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbPaidWith;
        private System.Windows.Forms.RadioButton rbStorno;
        private System.Windows.Forms.TextBox txtPaidWith;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtStornoFor;
        private System.Windows.Forms.RadioButton rbCancel;
    }
}
