namespace UNTQuotation
{
    partial class QuotationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuotationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cboCustomerName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAttention = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboService = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttoUpdate = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgQuotation = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQuotationId = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.cbovalitity = new System.Windows.Forms.ComboBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotation)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(168, 140);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 37);
            this.label1.TabIndex = 44;
            this.label1.Text = "Quoted to :";
            // 
            // cboCustomerName
            // 
            this.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCustomerName.FormattingEnabled = true;
            this.cboCustomerName.Location = new System.Drawing.Point(344, 140);
            this.cboCustomerName.Margin = new System.Windows.Forms.Padding(6);
            this.cboCustomerName.Name = "cboCustomerName";
            this.cboCustomerName.Size = new System.Drawing.Size(636, 33);
            this.cboCustomerName.TabIndex = 1;
            this.cboCustomerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboQuoted_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(190, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 37);
            this.label2.TabIndex = 46;
            this.label2.Text = "Address :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(142, 388);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 37);
            this.label3.TabIndex = 48;
            this.label3.Text = "Attention to :";
            // 
            // txtAttention
            // 
            this.txtAttention.Enabled = false;
            this.txtAttention.Location = new System.Drawing.Point(344, 400);
            this.txtAttention.Margin = new System.Windows.Forms.Padding(6);
            this.txtAttention.Multiline = true;
            this.txtAttention.Name = "txtAttention";
            this.txtAttention.Size = new System.Drawing.Size(636, 119);
            this.txtAttention.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 548);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(333, 37);
            this.label4.TabIndex = 50;
            this.label4.Text = "Desscription Service  :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cboService
            // 
            this.cboService.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboService.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboService.FormattingEnabled = true;
            this.cboService.IntegralHeight = false;
            this.cboService.Location = new System.Drawing.Point(344, 550);
            this.cboService.Margin = new System.Windows.Forms.Padding(6);
            this.cboService.Name = "cboService";
            this.cboService.Size = new System.Drawing.Size(634, 33);
            this.cboService.TabIndex = 5;
            this.cboService.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1224, 285);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 37);
            this.label5.TabIndex = 52;
            this.label5.Text = "Unit :";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(1316, 281);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(6);
            this.txtUnit.Multiline = true;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(652, 42);
            this.txtUnit.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1112, 367);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 37);
            this.label6.TabIndex = 54;
            this.label6.Text = "Rate (USD) :";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(1316, 363);
            this.txtRate.Margin = new System.Windows.Forms.Padding(6);
            this.txtRate.Multiline = true;
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(652, 42);
            this.txtRate.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1198, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 37);
            this.label7.TabIndex = 56;
            this.label7.Text = "Date :";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(1308, 54);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(6);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(652, 31);
            this.dtpDate.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1176, 133);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 37);
            this.label8.TabIndex = 58;
            this.label8.Text = "Validity :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1172, 440);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 37);
            this.label10.TabIndex = 62;
            this.label10.Text = "Remark :";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(1316, 444);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(6);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(652, 144);
            this.txtRemark.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(33, 670);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 37);
            this.label11.TabIndex = 64;
            this.label11.Text = "List ";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(135)))), ((int)(((byte)(56)))));
            this.btnExportToExcel.FlatAppearance.BorderSize = 0;
            this.btnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExcel.Image")));
            this.btnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportToExcel.Location = new System.Drawing.Point(1260, 1150);
            this.btnExportToExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(286, 69);
            this.btnExportToExcel.TabIndex = 66;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Image = ((System.Drawing.Image)(resources.GetObject("buttonClose.Image")));
            this.buttonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClose.Location = new System.Drawing.Point(1700, 1150);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(264, 69);
            this.buttonClose.TabIndex = 67;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttoUpdate
            // 
            this.buttoUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.buttoUpdate.FlatAppearance.BorderSize = 0;
            this.buttoUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttoUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttoUpdate.ForeColor = System.Drawing.Color.White;
            this.buttoUpdate.Image = ((System.Drawing.Image)(resources.GetObject("buttoUpdate.Image")));
            this.buttoUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttoUpdate.Location = new System.Drawing.Point(424, 1150);
            this.buttoUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.buttoUpdate.Name = "buttoUpdate";
            this.buttoUpdate.Size = new System.Drawing.Size(286, 69);
            this.buttoUpdate.TabIndex = 69;
            this.buttoUpdate.Text = "Update";
            this.buttoUpdate.UseVisualStyleBackColor = false;
            this.buttoUpdate.Click += new System.EventHandler(this.buttoUpdate_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(135)))), ((int)(((byte)(56)))));
            this.btnPrintReport.FlatAppearance.BorderSize = 0;
            this.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReport.ForeColor = System.Drawing.Color.White;
            this.btnPrintReport.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintReport.Image")));
            this.btnPrintReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintReport.Location = new System.Drawing.Point(828, 1150);
            this.btnPrintReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(286, 69);
            this.btnPrintReport.TabIndex = 70;
            this.btnPrintReport.Text = "Print";
            this.btnPrintReport.UseVisualStyleBackColor = false;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgQuotation);
            this.groupBox1.Location = new System.Drawing.Point(34, 702);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(1938, 410);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            // 
            // dgQuotation
            // 
            this.dgQuotation.AllowUserToAddRows = false;
            this.dgQuotation.AllowUserToDeleteRows = false;
            this.dgQuotation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuotation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column9,
            this.Column2,
            this.Column10,
            this.Column12,
            this.Column11,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgQuotation.Location = new System.Drawing.Point(6, 30);
            this.dgQuotation.Margin = new System.Windows.Forms.Padding(6);
            this.dgQuotation.MultiSelect = false;
            this.dgQuotation.Name = "dgQuotation";
            this.dgQuotation.ReadOnly = true;
            this.dgQuotation.RowHeadersWidth = 82;
            this.dgQuotation.RowTemplate.Height = 30;
            this.dgQuotation.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgQuotation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgQuotation.Size = new System.Drawing.Size(1926, 374);
            this.dgQuotation.TabIndex = 0;
            this.dgQuotation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuotation_CellDoubleClick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(42, 17);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(668, 79);
            this.label15.TabIndex = 43;
            this.label15.Text = "UNT WHOLESALE ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1094, 204);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(215, 37);
            this.label9.TabIndex = 60;
            this.label9.Text = "Quotation ID :";
            // 
            // txtQuotationId
            // 
            this.txtQuotationId.Location = new System.Drawing.Point(1316, 200);
            this.txtQuotationId.Margin = new System.Windows.Forms.Padding(6);
            this.txtQuotationId.Multiline = true;
            this.txtQuotationId.Name = "txtQuotationId";
            this.txtQuotationId.Size = new System.Drawing.Size(652, 42);
            this.txtQuotationId.TabIndex = 9;
            this.txtQuotationId.Leave += new System.EventHandler(this.txtQuotationId_Leave);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(135)))), ((int)(((byte)(56)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(40, 1150);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(286, 69);
            this.buttonSave.TabIndex = 68;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // cbovalitity
            // 
            this.cbovalitity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbovalitity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbovalitity.FormattingEnabled = true;
            this.cbovalitity.Location = new System.Drawing.Point(1316, 133);
            this.cbovalitity.Margin = new System.Windows.Forms.Padding(6);
            this.cbovalitity.Name = "cbovalitity";
            this.cbovalitity.Size = new System.Drawing.Size(652, 33);
            this.cbovalitity.TabIndex = 8;
            this.cbovalitity.Text = "   ";
            this.cbovalitity.SelectedIndexChanged += new System.EventHandler(this.dobValidity_SelectedIndexChanged);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnAddService
            // 
            this.btnAddService.BackColor = System.Drawing.Color.White;
            this.btnAddService.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddService.FlatAppearance.BorderSize = 0;
            this.btnAddService.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddService.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnAddService.Image = global::UNT_Quotation.Properties.Resources.folder_plus_circle__1_;
            this.btnAddService.Location = new System.Drawing.Point(994, 548);
            this.btnAddService.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(72, 44);
            this.btnAddService.TabIndex = 6;
            this.btnAddService.UseVisualStyleBackColor = false;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackColor = System.Drawing.Color.White;
            this.btnAddCustomer.FlatAppearance.BorderSize = 0;
            this.btnAddCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnAddCustomer.Image = global::UNT_Quotation.Properties.Resources.folder_plus_circle__1_;
            this.btnAddCustomer.Location = new System.Drawing.Point(994, 140);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(72, 44);
            this.btnAddCustomer.TabIndex = 2;
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Enabled = false;
            this.txtAddress.Location = new System.Drawing.Point(344, 200);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(6);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(636, 167);
            this.txtAddress.TabIndex = 3;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(135)))), ((int)(((byte)(56)))));
            this.btnAddItem.FlatAppearance.BorderSize = 0;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddItem.Location = new System.Drawing.Point(1316, 610);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(294, 69);
            this.btnAddItem.TabIndex = 89;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "NO.";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "QuotationId";
            this.Column9.MinimumWidth = 150;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "CustomerId";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "QuotationDate";
            this.Column10.MinimumWidth = 10;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 200;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "ServiceId";
            this.Column12.MinimumWidth = 10;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 150;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Validity";
            this.Column11.MinimumWidth = 10;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ServiceName";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Unit";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Rate";
            this.Column5.MinimumWidth = 10;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Remark";
            this.Column6.MinimumWidth = 10;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Amount";
            this.Column7.MinimumWidth = 10;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 150;
            // 
            // QuotationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2036, 1269);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.btnAddService);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.buttoUpdate);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtQuotationId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbovalitity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboService);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAttention);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCustomerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "QuotationForm";
            this.Text = "Quotation Information";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Quotation_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAttention;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboService;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttoUpdate;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgQuotation;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtQuotationId;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox cbovalitity;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}

