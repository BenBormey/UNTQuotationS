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

namespace UNTQuotation
{
    public partial class QuotationForm : Form
    {
        public QuotationForm()
        {
            InitializeComponent();
            Database.connetion();
        }
        QuotationModels quotations;
        private void Quotation_Load(object sender, EventArgs e)
        {
            ForeColor = Color.Black;
            BackColor = Color.LightGray;
            quotations = new QuotationModels();
            quotations.SetQuotation(cboQuoted);
            quotations.SetService(cboDsSevice);
            cbovalitity.Items.Add("45 Day");
            cbovalitity.Items.Add("75 Day");
            cbovalitity.Items.Add("100 Day");
            // quotations.loadData(dgvQuotation);




        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cboQuoted_KeyPress(object sender, KeyPressEventArgs e)

        {
            quotations = new QuotationModels();

            QuotationModels.QuotedName = cboQuoted.Text;
            quotations.GetQuotation(txtAddress, txtAttention);

        }

        private void addQuotedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuotationForm quotation = new QuotationForm();
            quotation.ShowDialog();
            cboQuoted.Items.Clear();
            quotations.SetQuotation(cboQuoted);

        }



        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Funtions.startBox(txtAddress, txtAttention, txtQuotationId, txtRemark, txtRate, txtUnit) == 0)
            {
                return;
            }
            quotations = new QuotationModels();
            QuotationModels.QuotedName = cboQuoted.Text;
            quotations.Address = txtAddress.Text;
            quotations.Attention = txtAttention.Text;
            quotations.Desscription = cboDsSevice.Text;
            quotations.Date = dobDate.Value;
            quotations.Validity = cbovalitity.Text;
            quotations.QuotationId = int.Parse(txtQuotationId.Text);
            quotations.Unit = txtUnit.Text;
            quotations.Rate = double.Parse(txtRate.Text);
            quotations.ReMark = txtRemark.Text;
            quotations.Create(dgvQuotation);
            Funtions.ClearBox(txtQuotationId, txtRemark, txtRate, txtUnit);
            cboDsSevice.Text = " ";

            cbovalitity.Text = " ";



        }

        private void dobValidity_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

       

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap pr = new Bitmap(this.dgvQuotation.Width, this.dgvQuotation.Height);
            dgvQuotation.DrawToBitmap(pr, new Rectangle(0, 0, this.dgvQuotation.Width, this.dgvQuotation.Height));
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
            quotations = new QuotationModels();
            cboQuoted.Items.Clear();
            quotations.SetQuotation(cboQuoted);

        }


        private void dgvQuotation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            quotations = new QuotationModels();
            quotations.TranferData(dgvQuotation, txtAttention, cboDsSevice, txtRate, txtUnit, txtRemark, txtAddress, txtAttention, txtQuotationId, cbovalitity, cboQuoted);
            //  quotations.TranferData(dgvQuotation);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }


        private void buttonExport_Click(object sender, EventArgs e)
        {
            quotations = new QuotationModels();
            quotations.PrintData(dgvQuotation);
        }

        private void buttoUpdate_Click(object sender, EventArgs e)
        {
            if (Funtions.startBox(txtAddress, txtAttention, txtQuotationId, txtRemark, txtRate, txtUnit) == 0)
            {
                return;
            }
            quotations = new QuotationModels();
            QuotationModels.QuotedName = cboQuoted.Text;
            quotations.Address = txtAddress.Text;
            quotations.Attention = txtAttention.Text;
            quotations.Desscription = cboDsSevice.Text;
            quotations.Date = dobDate.Value;
            quotations.Validity = cbovalitity.Text;
            quotations.QuotationId = int.Parse(txtQuotationId.Text);
            quotations.Unit = txtUnit.Text;
            quotations.Rate = double.Parse(txtRate.Text);
            quotations.ReMark = txtRemark.Text;
            quotations.Update(dgvQuotation);
            Funtions.ClearBox(txtQuotationId, txtRemark, txtRate, txtUnit);
            cboDsSevice.Text = " ";
            cbovalitity.Text = " ";
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

        }
    }
}
