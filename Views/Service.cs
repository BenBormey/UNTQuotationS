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
using UNT_Quotation.Models;
using UNTQuotation.Models;

namespace UNT_Quotation.Views
{
    public partial class Service : Form
    {
        public Service()
        {
            InitializeComponent();
        }

        private void Service_Load(object sender, EventArgs e)
        {
            service = new ServiceModels();
            service.loadData(dgvService);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ServiceModels service;
        private void button2_Click(object sender, EventArgs e)
        {
            if (Funtions.startBox(txtTitle, txtprice, txtContent) == 0)
            {
                return; 
            }
            service = new ServiceModels();
            service.Title= txtTitle.Text;
            service.Content = txtContent.Text;  
            service.Price = double.Parse(txtprice.Text);
            service.create();
            Funtions.ClearBox(txtprice,txtContent,txtTitle);
            dgvService.Rows.Clear();
            service.loadData(dgvService);
        }

        private void dgvService_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            service = new ServiceModels();
            service.Tranferdata(dgvService,txtTitle,txtContent,txtprice);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            service = new ServiceModels();
            service.Delete(dgvService);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Funtions.startBox(txtTitle, txtprice, txtContent) == 0)
            {
                return;
            }
            service = new ServiceModels();
            service.Title = txtTitle.Text;
            service.Content = txtContent.Text;
            service.Price = double.Parse(txtprice.Text);
            service.Update(dgvService);
            dgvService.Rows.Clear();
            service.loadData(dgvService);
            Funtions.ClearBox(txtContent,txtprice,txtTitle);
        }
    }
}
