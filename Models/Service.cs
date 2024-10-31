using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNT_quotation.Data;
using System.Data.SqlClient;
using System.Data;
using UNT_Quotation.Models;

namespace UNTQuotation.Models
{
    internal class Service : Action
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public double Price { get; set; }
        public double Currency { get; set; }
        public int IsActive { get; set; }
        public string SQL { get; set; }
        public static int RowEffected {  get; set; }
        public DataGridViewRow dgv;
        
        public override void Create(DataGridView dg)
        {
            try
            {
                this.SQL = "INSERT INTO tblService(ServiceName,Price,Currency,IsActive,CreateBy,CreateAt)Values(@ServiceName,@Price,@Currency,@IsActive,@CreateBy,GETDATE())";
                Database.cmd = new SqlCommand(this.SQL,Database.con);
                Database.cmd.Parameters.AddWithValue("@ServiceName", this.ServiceName);
                Database.cmd.Parameters.AddWithValue("@Price", this.Price);
                Database.cmd.Parameters.AddWithValue("@Currency", this.Currency);
                Database.cmd.Parameters.AddWithValue("@IsActive", this.IsActive);
                Database.cmd.Parameters.AddWithValue("@CreateBy",User.CreateBy);
                RowEffected = Database.cmd.ExecuteNonQuery();
                if(RowEffected> 0)
                {
                    MessageBox.Show("Create service successfully!");    
                }
            }
            catch (Exception ex) {

                MessageBox.Show("Error create service:" + ex.Message); 
            }
        }
        public override void UpdateById(DataGridView dg)
        {
            try
            {
                this.dgv = dg.SelectedRows[0];
                this.Id = int.Parse(dgv.Cells[0].Value.ToString());
                this.SQL = "" +
                    "UPDATE tblservice " +
                        "SET    ServiceName=@ServiceName," +
                                "UpdateBy =@UpdateBy,"+
                                "UpdateAt=GETDATE() " +
                        "WHERE ServiceId=@Id";
                Database.cmd = new SqlCommand(this.SQL, Database.con);       
                Database.cmd.Parameters.AddWithValue("@ServiceName", this.ServiceName);
                Database.cmd.Parameters.AddWithValue("@UpdateBy", User.UpdateBy);
                Database.cmd.Parameters.AddWithValue("@Id", this.Id);
                RowEffected = Database.cmd.ExecuteNonQuery();
                if (RowEffected > 0)
                {
                    MessageBox.Show("Update service successfully!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error update service:"+ ex.Message);
            }
        }
        public override void LoadingData(DataGridView dg)
        {
            try
            {
                this.SQL = "select Top 10 * from tblservice order by ServiceId desc";
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                dg.Rows.Clear();
                foreach (DataRow r in Database.tbl.Rows)
                {
                    object[] row = { r["ServiceId"], r["ServiceName"], r["KhServiceName"], r["Price"], r["Currency"], r["IsActive"] };
                    dg.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data service:" + ex.Message);
            }
        }
        public  void TranferData(DataGridView dg, TextBox txtEnServiceName, TextBox txtKhServiceName, TextBox txtPrice,TextBox txtCurrency,CheckBox chkIsActive)
        {
            try
            {
                if (dg.Rows.Count > 0)
                {
                    this.dgv = dg.SelectedRows[0];
                    txtEnServiceName.Text = dgv.Cells[1].Value.ToString();
                    txtKhServiceName.Text = dgv.Cells[2].Value.ToString();
                    txtPrice.Text = dgv.Cells[3].Value.ToString();
                    txtCurrency.Text = dgv.Cells[3].Value.ToString();
                    if (dgv.Cells[4].Value.ToString().Equals("True"))
                    {
                        chkIsActive.Checked = true;
                    }
                    else
                    {
                        chkIsActive.Checked = false;
                    }
                }
            }
            catch (Exception ex) {

                MessageBox.Show("Error transfer service:" + ex.Message);        
            }
        }
        public override void DeleteById(DataGridView dg)
        {
            try
            {   
                if (dg.Rows.Count == 0)
                {
                    return;
                }
                this.dgv = dg.SelectedRows[0];
                Id = int.Parse(dgv.Cells[0].Value.ToString());
                this.SQL = "DELETE FROM tblService WHERE ServiceId=@Id";
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                Database.cmd.Parameters.AddWithValue("@Id", Id);
                if (MessageBox.Show("Do you want to delete!", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RowEffected = Database.cmd.ExecuteNonQuery();
                    if (RowEffected == 1)
                    {
                        MessageBox.Show("Delete service succesfully");
                        dg.Rows.Remove(dgv);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error delete service:" + ex.Message);
            }

        }
        public override void SearchItem(DataGridView dg, TextBox txtSearchItem)
        {
            try
            {
                this.SQL = "select * from tblService where ServiceName like CONCAT('%',@ServiceName,'%')";
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                Database.cmd.Parameters.AddWithValue("@ServiceName", txtSearchItem.Text.Trim());
                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                dg.Rows.Clear();
                foreach (DataRow r in Database.tbl.Rows)
                {
                    object[] row = { r["ServiceId"], r["ServiceName"], r["KhServiceName"], r["Price"], r["Currency"], r["IsActive"] };
                    dg.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

    }
}
