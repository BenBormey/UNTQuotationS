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
using UNTQuotation.Models;

namespace UNT_Quotation.Views
{
    public partial class ServiceForm : Form
    {
        public ServiceForm()
        {
            InitializeComponent();
        }
        Service service;
        private void QuotationForm_Load(object sender, EventArgs e)
        {
            service = new Service();
            service.LoadingData(dgService);
            
        }

        private void dgvQuotationDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            service = new Service();
            service.TranferData(dgService,txtServiceName,txtKhServiceName,txtPrice,txtCurrency,chkActive);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Funtions.startBox(txtServiceName,txtPrice,txtCurrency) == 0)
            {
                return;
            }
            service = new Service();
            service.ServiceName = txtServiceName.Text.Trim();
            service.Price =Convert.ToDouble(txtPrice.Text.Trim());
            service.Currency = Convert.ToDouble(txtCurrency.Text.Trim());
            if (chkActive.Checked)
            {
                service.IsActive = 1;
            }
            else
            {
                service.IsActive = 0;
            }
            
            int chech = Funtions.CheckDouplicatedItem("select ServiceName from tblService where ServiceName=@ItemName", txtServiceName, "Service Name");
            if (chech == 1)
            {
                return;
            }
            service.Create(dgService);
            dgService.Rows.Clear();
            service.LoadingData(dgService);
            Funtions.ClearBox(txtServiceName);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btuDelete_Click(object sender, EventArgs e)
        {
            service=new Service();
            service.DeleteById(dgService);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Funtions.startBox(txtServiceName) == 0)
            {
                return;
            }
            service = new Service();
            service.ServiceName = txtServiceName.Text;
            int chech = Funtions.CheckDouplicatedItem("select ServiceName from tblService where ServiceName=@ItemName", txtServiceName, "Service Name");
            if (chech == 1)
            {
                return;
            }
            service.UpdateById(dgService);
            Funtions.ClearBox(txtServiceName);
        }

        private void txtServiceName_Leave(object sender, EventArgs e)
        {
             
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                if (Funtions.startBox(txtSearch) == 0)
                {
                    return;
                }
                service.SearchItem(dgService,txtSearch);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
