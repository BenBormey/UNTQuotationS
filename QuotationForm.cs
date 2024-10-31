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
        public static string name;
        public QuotationForm()
        {
            InitializeComponent();
            Database.connetion();
            
        }
        Quotation quotation=new Quotation();
        private void Quotation_Load(object sender, EventArgs e)
        {
            //quotation.SetCustomer(cboCustomerName);
            quotation.SetService(cboService);
            //cbovalitity.Items.Add("45 Day");
            //cbovalitity.Items.Add("75 Day");
            //cbovalitity.Items.Add("100 Day");
            cbovalitity.Items.Clear();
            for (int i = 1; i <= 60; i++)
            {
                cbovalitity.Items.Add($"{i} Day");
            }
        }
        private void cboQuoted_KeyPress(object sender, KeyPressEventArgs e)

        {
            quotation.CustomerName = cboCustomerName.Text;
            quotation.GetCustomerAddress(cboCustomerName,txtAddress, txtAttention);

        }

        private void addQuotedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //QuotationForm quotation = new QuotationForm();
            //quotation.ShowDialog();
            //cboCustomerName.Items.Clear();
            //this.quotation.SetCustomer(cboCustomerName);

        }

 

       

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap pr = new Bitmap(this.dgQuotation.Width, this.dgQuotation.Height);
            dgQuotation.DrawToBitmap(pr, new Rectangle(0, 0, this.dgQuotation.Width, this.dgQuotation.Height));
            e.Graphics.DrawImage(pr, 10, 10);
        }
 

        private void btnAddService_Click(object sender, EventArgs e)
        {
            ServiceForm service = new ServiceForm();
            service.ShowDialog();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {

        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            quotation.ExportToExcel(dgQuotation);
        }
        public static  int RowNumber = 1;
        public void AddDataToDataGrid()
        {
            if (cboCustomerName.Text.Equals(""))
            {
                cboCustomerName.Focus();
                return;
            }
            
            if (cboService.Text.Equals(""))
            {
                cboService.Focus();
                return;
            }
            if (cbovalitity.Text.Equals(""))
            {
                cbovalitity.Focus();
                return;
            }
            if (Funtions.startBox(txtUnit, txtRate) == 0)
            {
                return;
            }
            quotation.CustomerId =Convert.ToInt32(cboCustomerName.Text.Trim());
            quotation.QuotationDate = dtpDate.Value;
            quotation.Validity = cbovalitity.Text.Trim();
            quotation.ServiceId = quotation.GetServiceId(cboService);
            quotation.ServiceName = cboService.Text.Trim();
            quotation.Unit = Convert.ToInt32(txtUnit.Text.Trim());
            quotation.Rate = Convert.ToDouble(txtRate.Text.Trim());
            quotation.Remark = txtRemark.Text.Trim();
            foreach (DataGridViewRow DGV in dgQuotation.Rows)
            {
                int chechCustomerId, chechServiceId;
                chechCustomerId = Convert.ToInt32(DGV.Cells[2].Value);
                chechServiceId = Convert.ToInt32(DGV.Cells[4].Value);
                if (chechServiceId == quotation.ServiceId)
                {
                    MessageBox.Show("Service Id has been allready!");
                    cboService.Focus();
                    return;
                }
                if (chechCustomerId != quotation.CustomerId)
                {
                    cboCustomerName.Focus();
                    return;
                }

            }
            Object[] row = { RowNumber, quotation.QuotationId, quotation.CustomerId, quotation.QuotationDate, quotation.ServiceId, quotation.Validity, quotation.ServiceName, quotation.Unit, quotation.Rate, quotation.Remark, quotation.Amount() };
            dgQuotation.Rows.Add(row);
            RowNumber++;
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddDataToDataGrid();

        }

        private void txtQuotationId_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to print quotation?","Print Quotation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            { 
                quotation.CommitQuotationData(dgQuotation);
            }
        }

        private void dgQuotation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            quotation.TranferData(dgQuotation, txtAttention, cboService, txtRate, txtUnit, txtRemark, txtAddress, txtAttention, txtQuotationId, cbovalitity, cboCustomerName);
            //  quotations.TranferData(dgvQuotation);
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboService_Click(object sender, EventArgs e)
        {
            quotation.SetService(cboService);
        }

        private void removeServiceItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgQuotation.Rows.Count == 0)
            {
                return;
            }
            DataGridViewRow DGV=new DataGridViewRow();
            DGV=dgQuotation.SelectedRows[0];
            dgQuotation.Rows.Remove(DGV);
        }

        private void cboService_SelectedIndexChanged(object sender, EventArgs e)
        {
            quotation=new Quotation();
            quotation.GetServicePrice(cboService, txtRate);
        }
    }
}
