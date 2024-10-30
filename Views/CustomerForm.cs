﻿using System;
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
using UNTQuotation;
using UNTQuotation.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

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
            int check, check1;
            check=Funtions.CheckDouplicatedItem("select ContactNumber from tblCustomers where ContactNumber=@ItemName", txtContactNo, "Contuct Us");
            if (check == 1)
            {
                return;
            }
            check1 = Funtions.CheckDouplicatedItem("select Email from tblCustomers where Email=@ItemName", txtEmail, "Email");
            if (check1 == 1)
            {
                return;
            }
            customer.UpdateById(dgCustomer); 
            Funtions.ClearBox(txtQuotedName, txtAddress, txtAttenTion, txtkhmerName, txtContactNo, txtEmail);
        }

        private void txtContactNo_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void txtContactNo_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
             
        }

        private void dgCustomer_Enter(object sender, EventArgs e)
        {
           
        }

        private void dgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            customer = new Customer();
            customer.TranferData(dgCustomer, txtQuotedName, txtAddress, txtAttenTion, txtkhmerName, txtContactNo, txtEmail);
        }
        private void dgCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow DGV = new DataGridViewRow();
            DGV =dgCustomer.SelectedRows[0];
            QuotationForm quotationForm = new QuotationForm(DGV.Cells[1].Value.ToString());
           
            //this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                customer.SearchItem(dgCustomer,txtSearchItem);
            }
        }
    }
}
