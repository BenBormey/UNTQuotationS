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
using UNT_Quotation.Funtion;
using UNTQuotation.Models;

namespace UNT_Quotation.Views
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }
        Customer customer;
        private void QuotationForm_Load(object sender, EventArgs e)
        {
            customer = new Customer();
            customer.LoadingData(dgCustomer);
            //Font = new Font("Arial", 10); // Regular font for data
            //ForeColor = Color.Black; // Text color
            //BackColor = Color.LightGray; // Background color
                                         //  Alignment = DataGridViewContentAlignment.MiddleLeft;// Align text to the left
        }

        private void dgvQuotationDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            customer = new Customer();
            customer.TranferData(dgCustomer,txtQuotedName,txtAddress,txtAttenTion,txtkhmerName,txtContactNo,txtEmail);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Funtions.startBox(txtQuotedName, txtAddress, txtAttenTion, txtkhmerName, txtContactNo, txtEmail) == 0)
            {
                return;
            }
            customer = new Customer();
            customer.Address = txtAddress.Text;
            customer.AttenTion = txtAttenTion.Text;
            customer.KhmerName = txtkhmerName.Text;
            customer.ContactNo = txtContactNo.Text;
            customer.Email = txtEmail.Text;
            customer.EnglishName = txtQuotedName.Text;
            int check =
            Funtions.CheckDouplicatedItem("select ContactNumber from tblCustomers where ContactNumber=@ItemName", txtContactNo, "Contuct Us");
            if (check == 1)
            {
                return;
            }
            int check1 = Funtions.CheckDouplicatedItem("select Email from tblCustomers where Email=@ItemName", txtEmail, "Email");
            if (check1 == 1)
            {
                return;
            }
            customer.Create(dgCustomer);
            customer.LoadingData(dgCustomer);
            Funtions.ClearBox(txtQuotedName, txtAddress, txtAttenTion, txtkhmerName, txtContactNo, txtEmail);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btuDelete_Click(object sender, EventArgs e)
        {
            customer=new Customer();
            customer.DeleteById(dgCustomer);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Funtions.startBox(txtQuotedName, txtAddress, txtAttenTion, txtkhmerName, txtContactNo, txtEmail) == 0)
            {
                return;
            }
            customer = new Customer();
            customer.Address = txtAddress.Text;
            customer.AttenTion = txtAttenTion.Text;
            customer.KhmerName = txtkhmerName.Text;
            customer.ContactNo = txtContactNo.Text;
            customer.Email = txtEmail.Text;
            customer.EnglishName = txtQuotedName.Text;
            txtContactNo_Leave(sender, e);
            txtEmail_Leave(sender, e);
            customer.UpdateById(dgCustomer); 
            Funtions.ClearBox(txtQuotedName, txtAddress, txtAttenTion, txtkhmerName, txtContactNo, txtEmail);
        }

        private void txtContactNo_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void txtContactNo_Leave(object sender, EventArgs e)
        {
            int check =
            Funtions.CheckDouplicatedItem("select ContactNumber from tblCustomers where ContactNumber=@ItemName", txtContactNo, "Contuct Us");
            if (check == 1)
            {
                return;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            int check = Funtions.CheckDouplicatedItem("select Email from tblCustomers where Email=@ItemName", txtEmail, "Email");
            if(check == 1)
            {
                return;
            }
        }
    }
}
