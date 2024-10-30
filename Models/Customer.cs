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
    internal class Customer : Action
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string AttenTion { get; set; }
        public string EnglishName { get; set; }
        public string KhmerName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string SQL { get; set; }
        public static int RowEffected {  get; set; }
        public DataGridViewRow dgv;
        
        public override void Create(DataGridView dg)
        {
            try
            {
                this.SQL = "INSERT INTO tblCustomers(EnglishName,KhmerName,Address,AttentionTo,ContactNumber,Email,CreateBy,CreateAt)values(@EnglishName,@KhmerName,@Address,@AttentionTo,@ContactNumber,@Email,@CreateBy,GETDATE())";
                Database.cmd = new SqlCommand(this.SQL,Database.con);
                Database.cmd.Parameters.AddWithValue("@EnglishName", this.EnglishName);
                Database.cmd.Parameters.AddWithValue("@KhmerName", this.KhmerName);
                Database.cmd.Parameters.AddWithValue("@Address", this.Address);
                Database.cmd.Parameters.AddWithValue("@AttentionTo", this.AttenTion);
                Database.cmd.Parameters.AddWithValue("@ContactNumber", this.ContactNo);
                Database.cmd.Parameters.AddWithValue("@Email", this.Email);
                Database.cmd.Parameters.AddWithValue("@CreateBy",User.CreateBy);
                RowEffected = Database.cmd.ExecuteNonQuery();
                if(RowEffected> 0)
                {
                    MessageBox.Show("Create customer successfully!");    
                }
            }
            catch (Exception ex) {

                MessageBox.Show("Error create customer:" + ex.Message); 
            }
        }
        public override void UpdateById(DataGridView dg)
        {
            try
            {
                this.dgv = dg.SelectedRows[0];
                this.Id = int.Parse(dgv.Cells[0].Value.ToString());
                this.SQL = "" +
                    "UPDATE tblCustomers " +
                        "SET    EnglishName=@EnglishName," +
                                "KhmerName=@KhmerName," +
                                "Address=@Address," +
                                "AttentionTo=@AttentionTo," +
                                "ContactNumber=@ContactNumber," +
                                "Email=@Email," +
                                "UpdateBy =@UpdateBy,"+
                                "UpdateAt=GETDATE() " +
                        "WHERE Id=@Id";
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                Database.cmd.Parameters.AddWithValue("@EnglishName", this.EnglishName);
                Database.cmd.Parameters.AddWithValue("@KhmerName", this.KhmerName);
                Database.cmd.Parameters.AddWithValue("@Address", this.Address);
                Database.cmd.Parameters.AddWithValue("@AttentionTo", this.AttenTion);
                Database.cmd.Parameters.AddWithValue("@ContactNumber", this.ContactNo);
                Database.cmd.Parameters.AddWithValue("@Email", this.Email);
                Database.cmd.Parameters.AddWithValue("@UpdateBy", User.UpdateBy);
                Database.cmd.Parameters.AddWithValue("@Id", this.Id);
                RowEffected = Database.cmd.ExecuteNonQuery();
                if (RowEffected > 0)
                {
                    MessageBox.Show("Update customer successfully!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error update customer:"+ ex.Message);
            }
        }
        public override void LoadingData(DataGridView dg)
        {
            try
            {
                this.SQL = "select Top 10 * from tblCustomers order by Id desc";
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                dg.Rows.Clear();
                foreach (DataRow r in Database.tbl.Rows)
                {
                    object[] row = { r["Id"], r["EnglishName"], r["Address"], r["AttentionTo"], r["KhmerName"], r["ContactNumber"], r["Email"] };
                    dg.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public override void SearchItem(DataGridView dg,TextBox txtSearchItem)
        {
            try
            {
                this.SQL = "select * from tblCustomers where EnglishName like CONCAT('%',@EnglishName,'%') or ContactNumber=@EnglishName";
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                Database.cmd.Parameters.AddWithValue("@EnglishName", txtSearchItem.Text.Trim());
                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                dg.Rows.Clear();
                foreach (DataRow r in Database.tbl.Rows)
                {
                    object[] row = { r["Id"], r["EnglishName"], r["Address"], r["AttentionTo"], r["KhmerName"], r["ContactNumber"], r["Email"] };
                    dg.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public  void TranferData(DataGridView dg, TextBox txtQuotedName, TextBox txtAddress, TextBox txtAttenTion , TextBox txtKhmerName, TextBox txtContactNo, TextBox txtEmail)
        {
            try
            {
                if (dg.Rows.Count > 0)
                {
                    this.dgv = dg.SelectedRows[0];
                    txtQuotedName.Text = dgv.Cells[1].Value.ToString();
                    txtAddress.Text = dgv.Cells[2].Value.ToString();
                    txtAttenTion.Text = dgv.Cells[3].Value.ToString();
                    txtKhmerName.Text = dgv.Cells[4].Value.ToString();
                    txtContactNo.Text = dgv.Cells[5].Value.ToString();
                    txtEmail.Text = dgv.Cells[6].Value.ToString();
                }
            }
            catch (Exception ex) {

                MessageBox.Show("Error transfer customer:" + ex.Message);
            
            }
        }
        public override void DeleteById(DataGridView dg)
        {
            try
            {   
                if (dg.Rows.Count < 0)
                {
                    return;
                }
                this.dgv = dg.SelectedRows[0];
                Id = int.Parse(dgv.Cells[0].Value.ToString());
                this.SQL = "DELETE FROM tblCustomers WHERE Id=@Id";
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                Database.cmd.Parameters.AddWithValue("@Id", Id);
                if (MessageBox.Show("Do you want to delete!", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RowEffected = Database.cmd.ExecuteNonQuery();
                    if (RowEffected == 1)
                    {
                        MessageBox.Show("Delete customer succesfully");
                        dg.Rows.Remove(dgv);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error delete customer:"+ ex.Message);
            }

        }

    }
}
