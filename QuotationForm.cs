using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNT_quotation.Data;
using UNT_Quotation.Views;
using UNTQuotation.Models;
using System.Drawing.Printing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using UNT_Quotation.Funtion;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace UNTQuotation
{
    public partial class QuotationForm : Form
    {
        public QuotationForm()
        {
            InitializeComponent();
            Database.connetion();
        }
        Quotation quotation;
        private void Quotation_Load(object sender, EventArgs e)
        {
            //ForeColor = Color.Black;
            //BackColor = Color.LightGray;
            quotation = new Quotation();
            quotation.SetCustomer(cboCustomerName);
            quotation.SetService(cboService);
            cbovalitity.Items.Add("45 Day");
            cbovalitity.Items.Add("75 Day");
            cbovalitity.Items.Add("100 Day");
            quotation.SetCustomer(cboCustomerName);
            quotation.SetService(cboService);




        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cboQuoted_KeyPress(object sender, KeyPressEventArgs e)

        {
            quotation = new Quotation();
            quotation.CustomerName = cboCustomerName.Text;
            quotation.GetCustomerAddress(cboCustomerName,txtAddress, txtAttention);

        }

        private void addQuotedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuotationForm quotation = new QuotationForm();
            quotation.ShowDialog();
            cboCustomerName.Items.Clear();
            this.quotation.SetCustomer(cboCustomerName);

        }



        private void buttonSave_Click(object sender, EventArgs e)
        {
            quotation=new Quotation();
            quotation.CommitQuationData(dgQuotation);
        }

        private void dobValidity_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

       

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap pr = new Bitmap(this.dgQuotation.Width, this.dgQuotation.Height);
            dgQuotation.DrawToBitmap(pr, new Rectangle(0, 0, this.dgQuotation.Width, this.dgQuotation.Height));
            e.Graphics.DrawImage(pr, 10, 10);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            

        }


        private void button1_Click(object sender, EventArgs e)
        {
            QuotationForm quotationForm = new QuotationForm();
            quotationForm.ShowDialog();
            quotation = new Quotation();
            cboCustomerName.Items.Clear();
            quotation.SetCustomer(cboCustomerName);

        }


        private void dgvQuotation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            quotation = new Quotation();
            quotation.TranferData(dgQuotation, txtAttention, cboService, txtRate, txtUnit, txtRemark, txtAddress, txtAttention, txtQuotationId, cbovalitity, cboCustomerName);
            //  quotations.TranferData(dgvQuotation);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }


        private void buttonExport_Click(object sender, EventArgs e)
        {
             
        }

        private void buttoUpdate_Click(object sender, EventArgs e)
        {
             
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            ServiceForm service = new ServiceForm();
            service.ShowDialog();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {

        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            quotation=new Quotation();
            quotation.ExportToExcel(dgQuotation);
        }
        public static  int RowNumber = 1;
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            int check = Funtions.CheckDouplicatedItem("select Id  from tblQuotation where Id=@ItemName", txtQuotationId, "Quotation Id");
            if (check == 1)
            {
                return;
            }
            quotation =new Quotation();
            quotation.QuotationId=txtQuotationId.Text.Trim();
            quotation.CustomerId=quotation.GetCustomerAddress(cboCustomerName,txtAddress,txtAttention);
            quotation.QuotationDate=dtpDate.Value;
            quotation.Validity = cbovalitity.Text.Trim();
            quotation.ServiceId = quotation.GetServiceId(cboService);
            quotation.ServiceName = cboService.Text.Trim();
            quotation.Unit=Convert.ToInt32( txtUnit.Text.Trim());
            quotation.Rate =Convert.ToDouble(txtRate.Text.Trim());
            quotation.Remark = txtRemark.Text.Trim();
            foreach (DataGridViewRow DGV in dgQuotation.Rows)
            {
                int chechCustomerId,chechServiceId;
                chechCustomerId=Convert.ToInt32(DGV.Cells[2].Value);
                chechServiceId = Convert.ToInt32(DGV.Cells[4].Value);
                if (chechServiceId==quotation.ServiceId)
                {
                    MessageBox.Show("Service Id has been allready!");
                    cboService.Focus();
                    return;
                }
               
            }
            Object[] row = {RowNumber, quotation.QuotationId,quotation.CustomerId,quotation.QuotationDate,quotation.ServiceId, quotation.Validity, quotation.ServiceName,quotation.Unit,quotation.Rate,quotation.Remark,quotation.Amount()};
            dgQuotation.Rows.Add(row);
            RowNumber++;

        }

        private void txtQuotationId_Leave(object sender, EventArgs e)
        {
            int check=Funtions.CheckDouplicatedItem("select Id  from tblQuotation where Id=@ItemName", txtQuotationId, "Quotation Id");
            if (check == 1)
            {
                return;
            }
        }
    }
}
