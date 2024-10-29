using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNT_quotation.Data;
using UNT_Quotation.Models;

namespace UNTQuotation.Models
{
    internal class Quotation :Action
    {
        public long Id { get; set; }
        public DateTime QuotationDate { get; set; }
        public string Validity { get; set; }
        public string QuotationId { get; set; }
        public int Unit { get; set; }
        public double Rate { get; set; }
        public string Remark { get; set; }
        public string SQL { get; set; }
        public string SqlQuotationDetail { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string sqlUpdate { get; set; }
        public DataGridViewRow dgv { get; set; }
        public double Amount()
        {
            return this.Unit * this.Rate;
        }
        public double TotalAmount(DataGridView dgQuotation) {
            double sum = 0;
            foreach (DataGridViewRow dgv in dgQuotation.Rows)
            {
                sum += Convert.ToDouble(dgv.Cells[10].Value.ToString());
            }
            return sum;

        }
        public void SetCustomer(ComboBox cboCustomerName)
        {
            try
            {
                this.SQL = "select EnglishName from tblCustomers";
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                cboCustomerName.Items.Clear();
                foreach (DataRow r in Database.tbl.Rows)
                {
                    cboCustomerName.Items.Add(r["EnglishName"].ToString());

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erorr laoding customer:" + ex.Message);
            }
        }
        public int GetCustomerAddress(ComboBox cboCustomerName,[Optional] TextBox txtaddress, [Optional] TextBox txtAttention)
        {
            int id = 0;
            try
            {
                this.SQL = "select * from tblCustomers where EnglishName =@EnglishName";
                Customer customer = new Customer();
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                customer.EnglishName = cboCustomerName.Text;
                Database.cmd.Parameters.AddWithValue("@EnglishName", customer.EnglishName);
                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                if(Database.tbl.Rows.Count > 0)
                {
                    txtaddress.Text = Database.tbl.Rows[0]["Address"].ToString();
                    txtAttention.Text = Database.tbl.Rows[0]["AttentionTo"].ToString();
                    id = Convert.ToInt32(Database.tbl.Rows[0]["Id"].ToString());
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error get CustomerId:" + ex.Message);
            }
            return id;
        }
        public void SetService(ComboBox cboService)
        {
            try
            {
                this.SQL = "SELECT ServiceName FROM tblService";
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                cboService.Items.Clear();
                foreach (DataRow r in Database.tbl.Rows)
                {
                    cboService.Items.Add(r["ServiceName"].ToString());

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erorr:" + ex.Message);
            }
        }
        public int GetServiceId(ComboBox cboServiceName)
        {
            int id = 0;
            try
            {
                this.SQL = "select ServiceId,ServiceName from tblService where ServiceName=@ServiceName";
                Service serivce = new Service();
                Database.cmd = new SqlCommand(this.SQL, Database.con);
                 serivce.ServiceName = cboServiceName.Text;
                Database.cmd.Parameters.AddWithValue("@ServiceName", serivce.ServiceName);
                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                if (Database.tbl.Rows.Count > 0)
                {
                    id = Convert.ToInt32(Database.tbl.Rows[0]["ServiceId"].ToString());
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error get ServiceId:" + ex.Message);
            }
            return id;
        }
        public void AddQuotationItem(DataGridView dgQuotation,TextBox txtQuotationId,ComboBox cboCustomerName,ComboBox cboService)
        {
            this.CustomerId = this.GetCustomerAddress(cboCustomerName);
            Object[] row = {1,this.CustomerId};
            dgQuotation.Rows.Add(row);
        }
        public void CommitQuationData(DataGridView dgQuotation)
        {
            SqlTransaction sqlTransaction = null;
            try
            {
                if (dgQuotation.Rows.Count==0)
                {
                    return;
                }
                DataGridViewRow DGV = new DataGridViewRow();
                DGV=dgQuotation.SelectedRows[0];
                this.QuotationId = DGV.Cells[1].Value.ToString();
                this.CustomerId = Convert.ToInt32(DGV.Cells[2].Value.ToString());
                this.QuotationDate = Convert.ToDateTime(DGV.Cells[3].Value.ToString());
                sqlTransaction = Database.con.BeginTransaction();
                this.SQL = "INSERT INTO tblQuotation(Id,UserId,CustomerId,QuotationDate,TotalAmount) VALUES(@Id,@UserId,@CustomerId,@QuotationDate,@TotalAmount)";
                Database.cmd = new SqlCommand(this.SQL, Database.con,sqlTransaction);

                Database.cmd.Parameters.AddWithValue("@Id", this.QuotationId);
                Database.cmd.Parameters.AddWithValue("@UserId", User.CreateBy);
                Database.cmd.Parameters.AddWithValue("@CustomerId", this.CustomerId);
                Database.cmd.Parameters.AddWithValue("@QuotationDate", this.QuotationDate);
                Database.cmd.Parameters.AddWithValue("@TotalAmount", this.TotalAmount(dgQuotation));
                Database.cmd.ExecuteScalar();
                foreach (DataGridViewRow dgv in dgQuotation.Rows)
                {
                    this.ServiceId = Convert.ToInt16(dgv.Cells[4].Value.ToString());
                    this.Validity = dgv.Cells[5].Value.ToString();
                    this.Unit = Convert.ToInt32(dgv.Cells[7].Value.ToString());
                    this.Rate = Convert.ToDouble(dgv.Cells[8].Value.ToString());
                    this.Remark =dgv.Cells[9].Value.ToString();
                    this.SqlQuotationDetail = "insert into tblQuotationDetail(QuotationId,[Referents Code],ServiceId,Validity,Unit,Rate,Remark,Amount)values(@QuotationId,@ReferentsCode,@ServiceId,@Validity,@Unit,@Rate,@Remark,@Amount)";
                    Database.cmd = new SqlCommand(this.SqlQuotationDetail, Database.con, sqlTransaction);
                    Database.cmd.Parameters.AddWithValue("@QuotationId",this.QuotationId);
                    Database.cmd.Parameters.AddWithValue("@ReferentsCode",0);
                    Database.cmd.Parameters.AddWithValue("@ServiceId", this.ServiceId);
                    Database.cmd.Parameters.AddWithValue("@Validity", this.Validity);
                    Database.cmd.Parameters.AddWithValue("@Unit", this.Unit);
                    Database.cmd.Parameters.AddWithValue("@Rate", this.Rate);
                    Database.cmd.Parameters.AddWithValue("@Remark", this.Remark);
                    Database.cmd.Parameters.AddWithValue("@Amount", this.Amount());
                    Database.cmd.ExecuteNonQuery();

                }
                sqlTransaction.Commit();
                MessageBox.Show("Create quotation successfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error commit quotation data:" + ex.Message);
                sqlTransaction.Rollback();
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
        public  override void ExportToExcel(DataGridView dg)
        {
            Microsoft.Office.Interop.Excel.Application Xa = new
            Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook Wb;
            Microsoft.Office.Interop.Excel.Worksheet Ws;
            if (dg.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow DGV = new DataGridViewRow();
            DGV = dg.SelectedRows[0];
            this.QuotationId = DGV.Cells[1].Value.ToString();
            try
            {
                this.SQL = "select * from view_quotation_report where QuotationId=@QuotationId";
                Database.cmd = new SqlCommand(SQL, Database.con);
                Database.cmd.Parameters.AddWithValue("@QuotationId", this.QuotationId);
                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new DataTable();
                Database.da.Fill(Database.tbl);
                string pathFileReport = Application.StartupPath + @"\reports\quotation_report.xlsx";
                Wb = Xa.Workbooks.Open(pathFileReport, false, false, true);
                //get excel sheet
                Ws = Wb.Worksheets["Sheet1"];
                int row = 19;
                int i = 1;
                Ws.Cells[6, 6] = Database.tbl.Rows[0]["QuotationId"];
                Ws.Cells[6, 8] = Database.tbl.Rows[0]["QuotationDate"];
                Ws.Cells[8, 6] = Database.tbl.Rows[0]["CustomerId"];
                foreach (DataRow r in Database.tbl.Rows)
                {
                    Ws.Cells[row, 1] = i;
                    Ws.Cells[row, 2] = r["ServiceName"].ToString(); 
                    Ws.Cells[row, 6] = r["Unit"].ToString();
                    Ws.Cells[row, 7] = r["Rate"].ToString();
                    Ws.Cells[row, 8] = r["Amount"].ToString();
                    i++;
                    row++;
                }

                //set hide row excel
                //for (int j = 11; j <= 35; j++)
                //{
                //    string check = Convert.ToString(Ws.Cells[j, 2].Text);
                //    if (check.Equals(""))
                //    {
                //        Ws.Rows[j].Hidden = true;
                //    }


                //}
                //autofit column in worksheet
                Ws.Columns.AutoFit();
                //show excel application
                Xa.Visible = true;
                //print preivew excel sheet
                // Ws.PrintPreview();
                //print out doc from worksheet
                //int pageFrom = 1, pageTo = 1, noCopy = 2;
                //Ws.PrintOutEx(pageFrom, pageTo, noCopy);

                // Wb.Close(false); //false mean close ingore save
                //quit application
                // Xa.Quit();
                //clear all excel object
                Ws = null; Wb = null; Xa = null;
                dg.Rows.Clear();
                 
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error print report to excel:{e.Message}");
            }
        }
        //public void PrintData(DataGridView dg)
        //{
        //    Microsoft.Office.Interop.Excel.Application Xa = new
        //    Microsoft.Office.Interop.Excel.Application();
        //    Microsoft.Office.Interop.Excel.Workbook Wb;
        //    Microsoft.Office.Interop.Excel.Worksheet Ws;

        //    SqlTransaction sqlTransaction = null;
        //    try
        //    {
        //        sqlTransaction = Database.con.BeginTransaction();

        //        string sqlPrint = "select * from Quotation where QuotedName = @QuotedName and IsSuccess = 'false';";
        //        Database.cmd = new SqlCommand(sqlPrint, Database.con, sqlTransaction);
        //        Database.cmd.Parameters.AddWithValue("@QuotedName", QuotedName);
        //        Database.da = new SqlDataAdapter(Database.cmd);
        //        Database.tbl = new DataTable();
        //        Database.da.Fill(Database.tbl);
        //        Database.cmd.ExecuteNonQuery();

        //        string pathFileReport = Application.StartupPath + @"\Report\Quotation_Report.xlsx";
        //        Wb = Xa.Workbooks.Open(pathFileReport, false, false, true);
        //        //get excel sheet
        //        Ws = Wb.Worksheets["Sheet1"];
        //        int row = 11;
        //        int i = 1;

        //        Ws.Cells[4, 2] = Database.tbl.Rows[0]["QuotedName"];
        //        Ws.Cells[5, 2] = Database.tbl.Rows[0]["Address"];
        //        Ws.Cells[6, 2] = Database.tbl.Rows[0]["Attention"];
        //        foreach (DataRow r in Database.tbl.Rows)
        //        {
        //            Ws.Cells[row, 1] = i;
        //            Ws.Cells[row, 2] = r["Attention"].ToString();
        //            Ws.Cells[row, 3] = r["Desscription"].ToString();
        //            Ws.Cells[row, 4] = r["Rate"].ToString();
        //            Ws.Cells[row, 5] = r["Unit"].ToString();
        //            Ws.Cells[row, 6] = r["Remark"].ToString();
        //            i++;
        //            row++;
        //        }

        //        //set hide row excel
        //        for (int j = 11; j <= 35; j++)
        //        {
        //            string check = Convert.ToString(Ws.Cells[j, 2].Text);
        //            if (check.Equals(""))
        //            {
        //                Ws.Rows[j].Hidden = true;
        //            }


        //        }
        //        //autofit column in worksheet
        //        Ws.Columns.AutoFit();
        //        //show excel application
        //        Xa.Visible = true;
        //        //print preivew excel sheet
        //        // Ws.PrintPreview();
        //        //print out doc from worksheet
        //        int pageFrom = 1, pageTo = 1, noCopy = 2;
        //        Ws.PrintOutEx(pageFrom, pageTo, noCopy);

        //        // Wb.Close(false); //false mean close ingore save
        //        //quit application
        //        // Xa.Quit();
        //        //clear all excel object
        //        Ws = null; Wb = null; Xa = null;
        //        this.sqlUpdate = "update Quotation  set IsSuccess  = 'true' where QuotedName= @QuotedName ";
        //        Database.cmd = new SqlCommand(sqlPrint, Database.con, sqlTransaction);
        //        Database.cmd.Parameters.AddWithValue("@QuotedName", QuotedName);
        //        Database.da = new SqlDataAdapter(Database.cmd);
        //        Database.tbl = new DataTable();
        //        Database.da.Fill(Database.tbl);
        //        Database.cmd.ExecuteNonQuery();

        //        sqlTransaction.Commit();

        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //}
        //public void Update(DataGridView dg)
        //{
        //    try
        //    {
        //        this.dgv = dg.SelectedRows[0];
        //        Id = int.Parse(dgv.Cells[0].Value.ToString());
        //        this.SQL = "update Quotation set Address =@Address , Attention = @Attention, Desscription = @Desscription , Date = @Date,Validity = @Validity, QuotationId=@QuotationId,Unit = @Unit,Rate = @Rate,Remark =@Remark,QuotedName = @QuotedName where id= @Id";
        //        Database.cmd = new SqlCommand(this.SQL, Database.con);
        //        Database.cmd.Parameters.AddWithValue("@QuotedName", QuotedName);
        //        Database.cmd.Parameters.AddWithValue("@Address", this.Address);
        //        Database.cmd.Parameters.AddWithValue("@Attention", this.Attention);
        //        Database.cmd.Parameters.AddWithValue("@Desscription", this.Desscription);
        //        Database.cmd.Parameters.AddWithValue("@Date", this.Date);
        //        Database.cmd.Parameters.AddWithValue("@Validity", this.Validity);
        //        Database.cmd.Parameters.AddWithValue("@QuotationId", this.QuotationId);
        //        Database.cmd.Parameters.AddWithValue("@Unit", this.Unit);
        //        Database.cmd.Parameters.AddWithValue("@Rate", this.Rate);
        //        Database.cmd.Parameters.AddWithValue("@Remark", this.Remark);
        //        Database.cmd.Parameters.AddWithValue("@Id", Id);
        //        RowIeftive = Database.cmd.ExecuteNonQuery();
        //        if(RowIeftive > 0)
        //        {
        //            MessageBox.Show("Update Sessuess!");

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //}
    }
}
