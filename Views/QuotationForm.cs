using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNT_Quotation.Funtion;
using UNTQuotation.Models;

namespace UNT_Quotation.Views
{
    public partial class QuotationForm : Form
    {
        public QuotationForm()
        {
            InitializeComponent();
        }
        QuotationDetail quotation;
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Funtions.startBox(txtAddress, txtContactNo, txtEmail, txtkhmerName, txtQuotedName, txtAttenTion) == 0){
                return;
            }
            quotation = new QuotationDetail();
            quotation.Address = txtAddress.Text;
            quotation.AttenTion = txtAttenTion.Text;
            quotation.KhmerName = txtkhmerName.Text;
            quotation.ContactNo = txtContactNo.Text;
            quotation.Email = txtEmail.Text;
            quotation.QuotedName = txtQuotedName.Text;
            quotation.create(dgvQuotationDetail);
            dgvQuotationDetail.Rows.Clear();
            quotation.loadData(dgvQuotationDetail);
            Funtions.ClearBox(txtAddress, txtContactNo, txtEmail, txtkhmerName, txtQuotedName, txtAttenTion);



        }

        private void QuotationForm_Load(object sender, EventArgs e)
        {

            quotation = new QuotationDetail();
            quotation.loadData(dgvQuotationDetail);
            Font = new Font("Arial", 10); // Regular font for data
            ForeColor = Color.Black; // Text color
            BackColor = Color.LightGray; // Background color
          //  Alignment = DataGridViewContentAlignment.MiddleLeft;// Align text to the left

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Funtions.startBox(txtAddress, txtContactNo, txtEmail, txtkhmerName, txtQuotedName, txtAttenTion) == 0)
            {
                return;
            }
            quotation = new QuotationDetail();
            quotation.Address = txtAddress.Text;
            quotation.AttenTion = txtAttenTion.Text;
            quotation.KhmerName = txtkhmerName.Text;
            quotation.ContactNo = txtContactNo.Text;
            quotation.Email = txtEmail.Text;
            quotation.QuotedName = txtQuotedName.Text;
            quotation.Update(dgvQuotationDetail);
            dgvQuotationDetail.Rows.Clear();
            quotation.loadData(dgvQuotationDetail);

            Funtions.ClearBox(txtAddress, txtContactNo, txtEmail, txtkhmerName, txtQuotedName, txtAttenTion);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvQuotationDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            quotation = new QuotationDetail();
            quotation.TranferData(dgvQuotationDetail,txtQuotedName,txtAddress,txtAttenTion,txtkhmerName,txtContactNo,txtEmail);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            quotation = new QuotationDetail();
            quotation.Delete(dgvQuotationDetail);
        }
    }
}
