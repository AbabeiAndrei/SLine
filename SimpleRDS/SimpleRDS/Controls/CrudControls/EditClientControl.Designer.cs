namespace SimpleRDS.Controls.CrudControls
{
    partial class EditClientControl
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
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtCnp = new System.Windows.Forms.TextBox();
            this.lblCnp = new System.Windows.Forms.Label();
            this.lblSerieNumar = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblBirthDay = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.chkIsCompany = new System.Windows.Forms.CheckBox();
            this.txtSerieNumar = new System.Windows.Forms.MaskedTextBox();
            this.dtpBirthDay = new System.Windows.Forms.DateTimePicker();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.gbSubscriptions = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lvSubscriptions = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDetails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCloseContract = new System.Windows.Forms.Button();
            this.pnlSecond = new System.Windows.Forms.Panel();
            this.gbInvoices = new System.Windows.Forms.GroupBox();
            this.btnEditInvoice = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lvInvoices = new System.Windows.Forms.ListView();
            this.chNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chInvDetails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlActions = new System.Windows.Forms.Panel();
            this.lblCreated = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.sfdPrint = new System.Windows.Forms.SaveFileDialog();
            this.pnlMain.SuspendLayout();
            this.gbSubscriptions.SuspendLayout();
            this.pnlSecond.SuspendLayout();
            this.gbInvoices.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(3, 13);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(113, 21);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "Nume complet";
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(7, 37);
            this.txtFullName.MaxLength = 255;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(602, 29);
            this.txtFullName.TabIndex = 0;
            // 
            // txtCnp
            // 
            this.txtCnp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCnp.Location = new System.Drawing.Point(7, 162);
            this.txtCnp.MaxLength = 13;
            this.txtCnp.Name = "txtCnp";
            this.txtCnp.Size = new System.Drawing.Size(318, 29);
            this.txtCnp.TabIndex = 2;
            // 
            // lblCnp
            // 
            this.lblCnp.AutoSize = true;
            this.lblCnp.Location = new System.Drawing.Point(3, 138);
            this.lblCnp.Name = "lblCnp";
            this.lblCnp.Size = new System.Drawing.Size(41, 21);
            this.lblCnp.TabIndex = 2;
            this.lblCnp.Text = "CNP";
            // 
            // lblSerieNumar
            // 
            this.lblSerieNumar.AutoSize = true;
            this.lblSerieNumar.Location = new System.Drawing.Point(3, 207);
            this.lblSerieNumar.Name = "lblSerieNumar";
            this.lblSerieNumar.Size = new System.Drawing.Size(100, 21);
            this.lblSerieNumar.TabIndex = 4;
            this.lblSerieNumar.Text = "Serie/Numar";
            // 
            // txtMobile
            // 
            this.txtMobile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMobile.Location = new System.Drawing.Point(359, 231);
            this.txtMobile.MaxLength = 24;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(250, 29);
            this.txtMobile.TabIndex = 6;
            // 
            // lblMobile
            // 
            this.lblMobile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(355, 207);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(50, 21);
            this.lblMobile.TabIndex = 6;
            this.lblMobile.Text = "Mobil";
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(359, 162);
            this.txtPhone.MaxLength = 24;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 29);
            this.txtPhone.TabIndex = 5;
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(355, 138);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(59, 21);
            this.lblPhone.TabIndex = 8;
            this.lblPhone.Text = "Telefon";
            // 
            // lblBirthDay
            // 
            this.lblBirthDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBirthDay.AutoSize = true;
            this.lblBirthDay.Location = new System.Drawing.Point(355, 74);
            this.lblBirthDay.Name = "lblBirthDay";
            this.lblBirthDay.Size = new System.Drawing.Size(97, 21);
            this.lblBirthDay.TabIndex = 10;
            this.lblBirthDay.Text = "Data nasterii";
            // 
            // txtCity
            // 
            this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCity.Location = new System.Drawing.Point(7, 165);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(290, 29);
            this.txtCity.TabIndex = 8;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(3, 141);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(43, 21);
            this.lblCity.TabIndex = 12;
            this.lblCity.Text = "Oras";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(7, 40);
            this.txtAddress.MaxLength = 1024;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(290, 91);
            this.txtAddress.TabIndex = 7;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(3, 16);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(58, 21);
            this.lblAddress.TabIndex = 14;
            this.lblAddress.Text = "Adresa";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(7, 234);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(290, 29);
            this.txtEmail.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(3, 210);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 21);
            this.lblEmail.TabIndex = 16;
            this.lblEmail.Text = "Email";
            // 
            // chkIsCompany
            // 
            this.chkIsCompany.AutoSize = true;
            this.chkIsCompany.Location = new System.Drawing.Point(7, 83);
            this.chkIsCompany.Name = "chkIsCompany";
            this.chkIsCompany.Size = new System.Drawing.Size(129, 25);
            this.chkIsCompany.TabIndex = 1;
            this.chkIsCompany.Text = "Este companie";
            this.chkIsCompany.UseVisualStyleBackColor = true;
            // 
            // txtSerieNumar
            // 
            this.txtSerieNumar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerieNumar.Location = new System.Drawing.Point(7, 231);
            this.txtSerieNumar.Mask = "AA/000000";
            this.txtSerieNumar.Name = "txtSerieNumar";
            this.txtSerieNumar.Size = new System.Drawing.Size(318, 29);
            this.txtSerieNumar.TabIndex = 3;
            // 
            // dtpBirthDay
            // 
            this.dtpBirthDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBirthDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDay.Location = new System.Drawing.Point(359, 99);
            this.dtpBirthDay.Name = "dtpBirthDay";
            this.dtpBirthDay.Size = new System.Drawing.Size(250, 29);
            this.dtpBirthDay.TabIndex = 4;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dtpBirthDay);
            this.pnlMain.Controls.Add(this.txtMobile);
            this.pnlMain.Controls.Add(this.txtSerieNumar);
            this.pnlMain.Controls.Add(this.lblFullName);
            this.pnlMain.Controls.Add(this.chkIsCompany);
            this.pnlMain.Controls.Add(this.txtFullName);
            this.pnlMain.Controls.Add(this.lblCnp);
            this.pnlMain.Controls.Add(this.txtCnp);
            this.pnlMain.Controls.Add(this.lblSerieNumar);
            this.pnlMain.Controls.Add(this.lblMobile);
            this.pnlMain.Controls.Add(this.lblPhone);
            this.pnlMain.Controls.Add(this.txtPhone);
            this.pnlMain.Controls.Add(this.lblBirthDay);
            this.pnlMain.Controls.Add(this.gbSubscriptions);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(615, 573);
            this.pnlMain.TabIndex = 17;
            // 
            // gbSubscriptions
            // 
            this.gbSubscriptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSubscriptions.Controls.Add(this.btnEdit);
            this.gbSubscriptions.Controls.Add(this.lvSubscriptions);
            this.gbSubscriptions.Controls.Add(this.btnAdd);
            this.gbSubscriptions.Controls.Add(this.btnCloseContract);
            this.gbSubscriptions.Location = new System.Drawing.Point(0, 270);
            this.gbSubscriptions.Name = "gbSubscriptions";
            this.gbSubscriptions.Size = new System.Drawing.Size(609, 297);
            this.gbSubscriptions.TabIndex = 15;
            this.gbSubscriptions.TabStop = false;
            this.gbSubscriptions.Text = "Abonamente";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(397, 251);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 40);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Modifica";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lvSubscriptions
            // 
            this.lvSubscriptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSubscriptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chAddress,
            this.chState,
            this.chDetails});
            this.lvSubscriptions.FullRowSelect = true;
            this.lvSubscriptions.GridLines = true;
            this.lvSubscriptions.Location = new System.Drawing.Point(6, 28);
            this.lvSubscriptions.MultiSelect = false;
            this.lvSubscriptions.Name = "lvSubscriptions";
            this.lvSubscriptions.Size = new System.Drawing.Size(597, 217);
            this.lvSubscriptions.TabIndex = 11;
            this.lvSubscriptions.UseCompatibleStateImageBehavior = false;
            this.lvSubscriptions.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Nume";
            this.chName.Width = 120;
            // 
            // chAddress
            // 
            this.chAddress.Text = "Adresa";
            this.chAddress.Width = 200;
            // 
            // chState
            // 
            this.chState.Text = "Stare";
            this.chState.Width = 100;
            // 
            // chDetails
            // 
            this.chDetails.Text = "Detalii";
            this.chDetails.Width = 173;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(503, 251);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Adauga";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCloseContract
            // 
            this.btnCloseContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCloseContract.ForeColor = System.Drawing.Color.Red;
            this.btnCloseContract.Location = new System.Drawing.Point(6, 251);
            this.btnCloseContract.Name = "btnCloseContract";
            this.btnCloseContract.Size = new System.Drawing.Size(159, 40);
            this.btnCloseContract.TabIndex = 12;
            this.btnCloseContract.Text = "Inchide contractul";
            this.btnCloseContract.UseVisualStyleBackColor = true;
            this.btnCloseContract.Click += new System.EventHandler(this.btnCloseContract_Click);
            // 
            // pnlSecond
            // 
            this.pnlSecond.Controls.Add(this.gbInvoices);
            this.pnlSecond.Controls.Add(this.txtEmail);
            this.pnlSecond.Controls.Add(this.txtAddress);
            this.pnlSecond.Controls.Add(this.lblEmail);
            this.pnlSecond.Controls.Add(this.lblCity);
            this.pnlSecond.Controls.Add(this.txtCity);
            this.pnlSecond.Controls.Add(this.lblAddress);
            this.pnlSecond.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSecond.Location = new System.Drawing.Point(615, 0);
            this.pnlSecond.Name = "pnlSecond";
            this.pnlSecond.Size = new System.Drawing.Size(312, 573);
            this.pnlSecond.TabIndex = 18;
            // 
            // gbInvoices
            // 
            this.gbInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInvoices.Controls.Add(this.btnEditInvoice);
            this.gbInvoices.Controls.Add(this.btnPrint);
            this.gbInvoices.Controls.Add(this.lvInvoices);
            this.gbInvoices.Location = new System.Drawing.Point(0, 270);
            this.gbInvoices.Name = "gbInvoices";
            this.gbInvoices.Size = new System.Drawing.Size(309, 297);
            this.gbInvoices.TabIndex = 17;
            this.gbInvoices.TabStop = false;
            this.gbInvoices.Text = "Facturi";
            // 
            // btnEditInvoice
            // 
            this.btnEditInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditInvoice.Location = new System.Drawing.Point(7, 251);
            this.btnEditInvoice.Name = "btnEditInvoice";
            this.btnEditInvoice.Size = new System.Drawing.Size(100, 40);
            this.btnEditInvoice.TabIndex = 15;
            this.btnEditInvoice.Text = "Modifica";
            this.btnEditInvoice.UseVisualStyleBackColor = true;
            this.btnEditInvoice.Click += new System.EventHandler(this.btnEditInvoice_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(197, 251);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 40);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "Printeza";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lvInvoices
            // 
            this.lvInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvInvoices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNumber,
            this.chDate,
            this.chInvDetails});
            this.lvInvoices.FullRowSelect = true;
            this.lvInvoices.GridLines = true;
            this.lvInvoices.Location = new System.Drawing.Point(7, 28);
            this.lvInvoices.MultiSelect = false;
            this.lvInvoices.Name = "lvInvoices";
            this.lvInvoices.Size = new System.Drawing.Size(290, 217);
            this.lvInvoices.TabIndex = 0;
            this.lvInvoices.UseCompatibleStateImageBehavior = false;
            this.lvInvoices.View = System.Windows.Forms.View.Details;
            // 
            // chNumber
            // 
            this.chNumber.Text = "Factura";
            this.chNumber.Width = 100;
            // 
            // chDate
            // 
            this.chDate.Text = "Data";
            this.chDate.Width = 80;
            // 
            // chInvDetails
            // 
            this.chInvDetails.Text = "Detalii";
            this.chInvDetails.Width = 100;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.lblCreated);
            this.pnlActions.Controls.Add(this.btnOk);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(0, 573);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(927, 46);
            this.pnlActions.TabIndex = 15;
            // 
            // lblCreated
            // 
            this.lblCreated.AutoSize = true;
            this.lblCreated.Location = new System.Drawing.Point(3, 22);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(52, 21);
            this.lblCreated.TabIndex = 15;
            this.lblCreated.Text = "label1";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(812, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 40);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // sfdPrint
            // 
            this.sfdPrint.DefaultExt = "*.pdf";
            this.sfdPrint.Filter = "PDF Files|*.pdf";
            this.sfdPrint.Title = "Exportare factura";
            // 
            // EditClientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSecond);
            this.Controls.Add(this.pnlActions);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "EditClientControl";
            this.Size = new System.Drawing.Size(927, 619);
            this.Load += new System.EventHandler(this.EditClientControl_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.gbSubscriptions.ResumeLayout(false);
            this.pnlSecond.ResumeLayout(false);
            this.pnlSecond.PerformLayout();
            this.gbInvoices.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtCnp;
        private System.Windows.Forms.Label lblCnp;
        private System.Windows.Forms.Label lblSerieNumar;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblBirthDay;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.CheckBox chkIsCompany;
        private System.Windows.Forms.MaskedTextBox txtSerieNumar;
        private System.Windows.Forms.DateTimePicker dtpBirthDay;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlSecond;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCloseContract;
        private System.Windows.Forms.ListView lvSubscriptions;
        private System.Windows.Forms.GroupBox gbSubscriptions;
        private System.Windows.Forms.GroupBox gbInvoices;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ListView lvInvoices;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chAddress;
        private System.Windows.Forms.ColumnHeader chState;
        private System.Windows.Forms.ColumnHeader chDetails;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chInvDetails;
        private System.Windows.Forms.Button btnEditInvoice;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.SaveFileDialog sfdPrint;
    }
}
