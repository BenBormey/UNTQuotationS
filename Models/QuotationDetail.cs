using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNT_quotation.Data;
using System.Data.SqlClient;
using System.Data;

namespace UNTQuotation.Models
{
    internal class QuotationDetail : Action
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string AttenTion { get; set; }
        public string QuotedName { get; set; }
        public string KhmerName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string SQL { get; set; }
        public static int Rowisfetive {  get; set; }
        public DataGridViewRow dgv;
        
        public override void create(DataGridView dg)
        {
            try
            {
                this.SQL = "insert into tblCustomers(EnglishName,KhmerName,Address,AttentionTo,ContactNumber,Email,CreateBy,CreateAt) values (@EnglishName, @KhmerName, @Address, @AttentionTo, @ContactNumber, @Email, 1, GETDATE());";
                this.SQL = "insert into QuotationDetail(Address,QuotedName,AttenTion,KhmerName,ContactNo,Email) values(@Address,@QuotedName,@AttenTion,@KhmerName,@ContactNo,@Email)";
                Database.cmd = new SqlCommand(this.SQL,Database.con);
        
                Database.cmd.Parameters.AddWithValue("@EnglishName", this.Address);
                Database.cmd.Parameters.AddWithValue("@KhmerName", this.KhmerName);
                Database.cmd.Parameters.AddWithValue("@Address", this.Address);
                Database.cmd.Parameters.AddWithValue("@AttentionTo", this.AttenTion);
                Database.cmd.Parameters.AddWithValue("@ContactNumber", this.ContactNo);
                Database.cmd.Parameters.AddWithValue("@Email", this.Email);
                
                Rowisfetive = Database.cmd.ExecuteNonQuery();

                if(Rowisfetive> 0)
                {
                    MessageBox.Show("Create sesuss!");
                    
                }
            }
            catch (Exception ex) {

                MessageBox.Show("Error:" + ex.Message);
            
            }

        }

        public override void Update(DataGridView dg)
        {
            try
            {
                this.dgv = dg.SelectedRows[0];
                Id = int.Parse(dgv.Cells[0].Value.ToString());
                this.SQL = "update QuotationDetail set QuotedName= @QuotedName,Address =@Address, Attention =@QuotedName,KhmerName =@KhmerName,ContactNo = @ContactNo, Email = @Email where QuotationId=@QuotationId";
                Database.cmd = new SqlCommand(this.SQL, Database.con);

                Database.cmd.Parameters.AddWithValue("@Address", this.Address);
                Database.cmd.Parameters.AddWithValue("@AttenTion", this.AttenTion);
                Database.cmd.Parameters.AddWithValue("@QuotedName", this.QuotedName);
                Database.cmd.Parameters.AddWithValue("@KhmerName", this.KhmerName);
                Database.cmd.Parameters.AddWithValue("@ContactNo", this.ContactNo);
                Database.cmd.Parameters.AddWithValue("@Email", this.Email);
                Database.cmd.Parameters.AddWithValue("@QuotationId", this.Id);
                Rowisfetive = Database.cmd.ExecuteNonQuery();

                if (Rowisfetive > 0)
                {
                    MessageBox.Show("Update sesuss!");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:"+ ex.Message);
            }
        }
        public void loadData(DataGridView dg)
        {
            try
            {
                this.SQL = "select * from tblCustomers;";
                Database.cmd = new SqlCommand( this.SQL, Database.con);
                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                foreach ( DataRow r in Database.tbl.Rows)
                {
                    object[] row = { r["Id"], r["EnglishName"], r["Address"], r["AttentionTo"], r["KhmerName"], r["ContactNumber"], r["Email"] };
                    dg.Rows.Add(row);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:"+ ex.Message);
            }
        }

        public  void TranferData(DataGridView dg, TextBox txtQuotedName, TextBox txtAddress, TextBox txtAttenTion , TextBox txtKhmerName, TextBox txtContactNo, TextBox txtEmail)
        {
            try
            {
                this.dgv = dg.SelectedRows[0];
                txtQuotedName.Text = dgv.Cells[1].Value.ToString();
                txtAddress.Text = dgv.Cells[2].Value.ToString();
                txtAttenTion.Text = dgv.Cells[3].Value.ToString();
                txtKhmerName.Text = dgv.Cells[4].Value.ToString();
                txtContactNo.Text = dgv.Cells[5].Value.ToString();
                txtEmail.Text = dgv.Cells[6].Value.ToString();
            }
            catch (Exception ex) {

                MessageBox.Show("Error:" + ex.Message);
            
            }
        }


        public void Delete(DataGridView dg)
        {
            try
            {
              
                if (dg.Rows.Count < 0)
                {
                    return;

                }
                this.dgv = dg.SelectedRows[0];
                Id = int.Parse(dgv.Cells[0].Value.ToString());
                this.SQL = "delete from QuotationDetail where QuotationId =@id";
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                Database.cmd.Parameters.AddWithValue("@id", Id);
                if (MessageBox.Show("Do you want to delete!", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    Rowisfetive = Database.cmd.ExecuteNonQuery();
                    if (Rowisfetive == 1)
                    {
                        MessageBox.Show("Deleted!");
                        dg.Rows.Remove(dgv);
                    }


                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:"+ ex.Message);
            }

        }

    }
}
