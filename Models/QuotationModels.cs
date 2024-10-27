using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNT_quotation.Data;

namespace UNTQuotation.Models
{
    internal class QuotationModels : Action
    {
        public long Id { get; set; }
        public string Quotation { get; set; }
        public string Address { get; set; }
        public string Attention { get; set; }
        public static string QuotedName { get; set; }
        public string KhmerName { get; set; }
        public string Desscription { get; set; }
        public DateTime Date { get; set; }
        public string Validity { get; set; }
        public int QuotationId { get; set; }
        public string Unit { get; set; }
        public double Rate { get; set; }
        public string ReMark { get; set; }
        public string SQL { get; set; }
        public static int id = 0;
        public static int RowIeftive { get; set; }
        public string sqlUpdate { get; set; }
        public DataGridViewRow dgv { get; set; }

        //public override void create(DataGridView dg)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex) { }

        //}


        public void SetQuotation(ComboBox cboQuotations)
        {
            try
            {
                this.SQL = "select * from QuotationDetail;";

                Database.cmd = new SqlCommand(this.SQL, Database.con);

                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                foreach (DataRow r in Database.tbl.Rows)
                {
                    cboQuotations.Items.Add(r["QuotedName"].ToString());

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erorr:" + ex.Message);
            }
        }

        public void SetService(ComboBox cboService)
        {
            try
            {
                this.SQL = "SELECT * FROM DesscriptionService;";

                Database.cmd = new SqlCommand(this.SQL, Database.con);

                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                foreach (DataRow r in Database.tbl.Rows)
                {
                    cboService.Items.Add(r["Title"].ToString());

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erorr:" + ex.Message);
            }
        }

        public int GetQuotation(TextBox txtaddress, TextBox txtAttention)
        {

            try
            {
                this.SQL = "select * from tblCustomers where EnglishName = @QuotedName;";

                Database.cmd = new SqlCommand(this.SQL, Database.con);
                Database.cmd.Parameters.AddWithValue("@EnglishName", QuotedName);
                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                foreach (DataRow r in Database.tbl.Rows)
                {
                    // cboQuotation.Text = r["QuotedName"].ToString();
                    txtaddress.Text = r["Address"].ToString();
                    txtAttention.Text = r["AttentionTo"].ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
            return id;
        }
        public override void create(DataGridView dg)
        {

            try
            {
                this.SQL = "insert into Quotation (QuotedName,Address,Attention,Desscription,Date,Validity,QuotationId,Unit,Rate,Remark,IsSuccess) values (@QuotedName,@Address,@Attention, @Desscription,@Date,@Validity,@QuotationId,@Unit,@Rate,@Remark,@IsSuccess);select SCOPE_IDENTITY(); ";
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                Database.cmd.Parameters.AddWithValue("@QuotedName", QuotedName);
                Database.cmd.Parameters.AddWithValue("@Address", this.Address);
                Database.cmd.Parameters.AddWithValue("@Attention", this.Attention);
                Database.cmd.Parameters.AddWithValue("@Desscription", this.Desscription);
                Database.cmd.Parameters.AddWithValue("@Date", this.Date);
                Database.cmd.Parameters.AddWithValue("@Validity", this.Validity);
                Database.cmd.Parameters.AddWithValue("@QuotationId", this.QuotationId);
                Database.cmd.Parameters.AddWithValue("@Unit", this.Unit);
                Database.cmd.Parameters.AddWithValue("@Rate", this.Rate);
                Database.cmd.Parameters.AddWithValue("@Remark", this.ReMark);
                Database.cmd.Parameters.AddWithValue("@IsSuccess", false);
                id = (int)Convert.ToInt64(Database.cmd.ExecuteScalar());


                if (RowIeftive > 0)
                {
                    MessageBox.Show("Create Quotation ");
                }
               object[] rows = { id, this.Attention, this.Desscription, this.Rate, this.Unit, this.ReMark,
                    this.Address, this.Attention, this.QuotationId, this.Date, this.Validity, QuotedName };
                dg.Rows.Add(rows);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void loadData(DataGridView dg)
        {

            try
            {
                this.SQL = " select * from Quotation;";
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                id = (int)Convert.ToInt64(Database.cmd.ExecuteScalar());
                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                foreach (DataRow r in Database.tbl.Rows)
                {
                    object[] rows = { r["id"], r["Attention"], r["Desscription"], r["Rate"], r["Unit"], r["Remark"], r["Address"], r["Attention"], r["QuotationId"], r["Date"],r["Validity"], r["QuotedName"] };
                    dg.Rows.Add(rows);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void TranferData(DataGridView dg, TextBox txtAttenTion, ComboBox cboDsService, TextBox txtRate, TextBox txtunit, TextBox txtRemark, TextBox txtAddress, TextBox txtAttention, TextBox txtquotationId, ComboBox cbovalidity, ComboBox cboquotationName)
        {
            try
            {
                this.dgv = dg.SelectedRows[0];
                cboDsService.Text = dgv.Cells[2].Value.ToString();
                txtRate.Text = dgv.Cells[3].Value.ToString();
                txtunit.Text = dgv.Cells[4].Value.ToString();
                txtRemark.Text = dgv.Cells[5].Value.ToString();
                txtAttention.Text = dgv.Cells[7].Value.ToString();
                txtquotationId.Text = dgv.Cells[8].Value.ToString();
                cbovalidity.Text = dgv.Cells[10].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);

            }
        }
        public void PrintData(DataGridView dg)
        {
            Microsoft.Office.Interop.Excel.Application Xa = new
            Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook Wb;
            Microsoft.Office.Interop.Excel.Worksheet Ws;

            SqlTransaction sqlTransaction = null;
            try
            {
                sqlTransaction = Database.con.BeginTransaction();

                string sqlPrint = "select * from Quotation where QuotedName = @QuotedName and IsSuccess = 'false';";
                Database.cmd = new SqlCommand(sqlPrint, Database.con, sqlTransaction);
                Database.cmd.Parameters.AddWithValue("@QuotedName", QuotedName);
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                Database.cmd.ExecuteNonQuery();

                string pathFileReport = Application.StartupPath + @"\Report\Quotation_Report.xlsx";
                Wb = Xa.Workbooks.Open(pathFileReport, false, false, true);
                //get excel sheet
                Ws = Wb.Worksheets["Sheet1"];
                int row = 11;
                int i = 1;

                Ws.Cells[4, 2] = Database.tbl.Rows[0]["QuotedName"];
                Ws.Cells[5, 2] = Database.tbl.Rows[0]["Address"];
                Ws.Cells[6, 2] = Database.tbl.Rows[0]["Attention"];
                foreach (DataRow r in Database.tbl.Rows)
                {
                    Ws.Cells[row, 1] = i;
                    Ws.Cells[row, 2] = r["Attention"].ToString();
                    Ws.Cells[row, 3] = r["Desscription"].ToString();
                    Ws.Cells[row, 4] = r["Rate"].ToString();
                    Ws.Cells[row, 5] = r["Unit"].ToString();
                    Ws.Cells[row, 6] = r["Remark"].ToString();
                    i++;
                    row++;
                }

                //set hide row excel
                for (int j = 11; j <= 35; j++)
                {
                    string check = Convert.ToString(Ws.Cells[j, 2].Text);
                    if (check.Equals(""))
                    {
                        Ws.Rows[j].Hidden = true;
                    }


                }
                //autofit column in worksheet
                Ws.Columns.AutoFit();
                //show excel application
                Xa.Visible = true;
                //print preivew excel sheet
                // Ws.PrintPreview();
                //print out doc from worksheet
                int pageFrom = 1, pageTo = 1, noCopy = 2;
                Ws.PrintOutEx(pageFrom, pageTo, noCopy);

                // Wb.Close(false); //false mean close ingore save
                //quit application
                // Xa.Quit();
                //clear all excel object
                Ws = null; Wb = null; Xa = null;
                this.sqlUpdate = "update Quotation  set IsSuccess  = 'true' where QuotedName= @QuotedName ";
                Database.cmd = new SqlCommand(sqlPrint, Database.con, sqlTransaction);
                Database.cmd.Parameters.AddWithValue("@QuotedName", QuotedName);
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                Database.cmd.ExecuteNonQuery();

                sqlTransaction.Commit();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void Update(DataGridView dg)
        {
            try
            {
                this.dgv = dg.SelectedRows[0];
                Id = int.Parse(dgv.Cells[0].Value.ToString());
                this.SQL = "update Quotation set Address =@Address , Attention = @Attention, Desscription = @Desscription , Date = @Date,Validity = @Validity, QuotationId=@QuotationId,Unit = @Unit,Rate = @Rate,Remark =@Remark,QuotedName = @QuotedName where id= @Id";
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                Database.cmd.Parameters.AddWithValue("@QuotedName", QuotedName);
                Database.cmd.Parameters.AddWithValue("@Address", this.Address);
                Database.cmd.Parameters.AddWithValue("@Attention", this.Attention);
                Database.cmd.Parameters.AddWithValue("@Desscription", this.Desscription);
                Database.cmd.Parameters.AddWithValue("@Date", this.Date);
                Database.cmd.Parameters.AddWithValue("@Validity", this.Validity);
                Database.cmd.Parameters.AddWithValue("@QuotationId", this.QuotationId);
                Database.cmd.Parameters.AddWithValue("@Unit", this.Unit);
                Database.cmd.Parameters.AddWithValue("@Rate", this.Rate);
                Database.cmd.Parameters.AddWithValue("@Remark", this.ReMark);
                Database.cmd.Parameters.AddWithValue("@Id", Id);
                RowIeftive = Database.cmd.ExecuteNonQuery();
                if(RowIeftive > 0)
                {
                    MessageBox.Show("Update Sessuess!");
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
