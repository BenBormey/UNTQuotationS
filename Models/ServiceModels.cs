using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNT_quotation.Data;
using System.Data.SqlClient;
using System.Data;

namespace UNT_Quotation.Models
{
    internal class ServiceModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public double Price { get; set; }
        public string SQL { get; set; }
        public int rowefftive;
        public int Rowisfetive;
        public DataGridViewRow dgv;

        public void create()
        {
            try
            {
                this.SQL = "insert into DesscriptionService (Title,Content,CreateAt,Price) values(@nameService,@Content,getdate(),@Price);";
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                Database.cmd.Parameters.AddWithValue("@nameService", this.Title);
                Database.cmd.Parameters.AddWithValue("@Content", this.Content);
                Database.cmd.Parameters.AddWithValue("@Price", this.Price);
                this.rowefftive = Database.cmd.ExecuteNonQuery();
                if (this.rowefftive > 0)
                {
                    MessageBox.Show("Create sesuss!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        public void loadData(DataGridView dg)
        {
            try
            {
                this.SQL = "select * from DesscriptionService;";
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                foreach (DataRow r in Database.tbl.Rows)
                {
                    object[] row = { r["Id"], r["Title"], r["Content"], r["Price"], r["CreateAt"], r["UpdateAt"] };
                    dg.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void Tranferdata(DataGridView dg, TextBox txtTitle, TextBox txtContent, TextBox txtPrice)
        {
            try
            {
                this.dgv = dg.SelectedRows[0];
                txtTitle.Text = dgv.Cells[1].Value.ToString();
                txtContent.Text = dgv.Cells[2].Value.ToString();
                txtPrice.Text = dgv.Cells[3].Value.ToString();

            }
            catch (Exception ex)
            {

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
                this.SQL = "delete  from DesscriptionService where Id = @id";
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
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
        public void Update(DataGridView dg)
        {
            try
            {
                this.dgv = dg.SelectedRows[0];
                Id = int.Parse(dgv.Cells[0].Value.ToString());
                this.SQL = "update  DesscriptionService set Title= @Title, Content = @Content, Price = @Price,UpdateAt = Getdate() where Id =@QuotationId";
                Database.cmd = new SqlCommand(this.SQL, Database.con);

                Database.cmd.Parameters.AddWithValue("@Title", this.Title);
                Database.cmd.Parameters.AddWithValue("@Content", this.Content);
                Database.cmd.Parameters.AddWithValue("@Price", this.Price);
                Database.cmd.Parameters.AddWithValue("@QuotationId", this.Id);
                Rowisfetive = Database.cmd.ExecuteNonQuery();

                if (Rowisfetive > 0)
                {
                    MessageBox.Show("Update sesuss!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
