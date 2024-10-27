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
    public partial class Quotation : Form
    {
        public Quotation()
        {
            InitializeComponent();
        }
        QuotationModels quotations;
        private void Quotation_Load(object sender, EventArgs e)
        {

            ForeColor = Color.Black; 
            BackColor = Color.LightGray;
            Database.connetion();
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
                quotations.GetQuotation( txtAddress, txtAttention);
            
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
            quotations.QuotationId =int.Parse(txtQuotationId.Text);
            quotations.Unit =txtUnit.Text;
            quotations.Rate = double.Parse(txtRate.Text);
            quotations.ReMark = txtRemark.Text;
            quotations.create(dgvQuotation);
            Funtions.ClearBox(txtQuotationId,txtRemark,txtRate,txtUnit);
            cboDsSevice.Text = " ";

            cbovalitity.Text = " "; 



        }

        private void dobValidity_SelectedIndexChanged(object sender, EventArgs e)
        {
           
          
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            //printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap pr = new Bitmap(this.dgvQuotation.Width, this.dgvQuotation.Height);
            dgvQuotation.DrawToBitmap(pr, new Rectangle(0, 0, this.dgvQuotation.Width, this.dgvQuotation.Height));
            e.Graphics.DrawImage(pr, 10, 10);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close!", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }

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
            QuotationForm quotationForm = new QuotationForm();
            quotationForm.ShowDialog();
            cboQuoted.Items.Clear();
            quotations.SetQuotation(cboQuoted);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Service service = new Service();

            service.ShowDialog();
            cboDsSevice.Items.Clear();
            quotations.SetQuotation(cboDsSevice);
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
    }
}
