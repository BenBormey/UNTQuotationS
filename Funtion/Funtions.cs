using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNT_quotation.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace UNT_Quotation.Funtion
{
    internal class Funtions
    {
        public static int startBox(params TextBox[] textBoxes)
        {
            foreach (TextBox box in textBoxes)
            {
                if (box.Text.Equals("") || box.Text==null)
                {
                    box.Focus();
                    return 0;
                }
            }
            return 1;
        }
        public static void ClearBox(params TextBox[] textBoxes)
        {
            foreach (TextBox box in textBoxes)
            {
                box.Clear();
            }


        }
        public static string Sql { get; set; }
        public static int CheckDouplicatedItem(string sql,TextBox txtItemName,string message)
        {
            try
            {
                Sql =sql;
                Database.cmd = new SqlCommand(Sql, Database.con);
                Database.cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text.Trim());
                Database.cmd.ExecuteNonQuery();
                Database.da = new SqlDataAdapter(Database.cmd);
                Database.tbl = new System.Data.DataTable();
                Database.da.Fill(Database.tbl);
                if (Database.tbl.Rows.Count > 0)
                {
                    MessageBox.Show($"{message} has been already!");
                    txtItemName.Focus();
                    return 1;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error check douplicate item:{ex}");
            }
            return 0;
        }
        //public static int CheckDouplicatedItem(string sql,Object ItemName, string message)
        //{
        //    try
        //    {
        //        Sql = sql;
        //        Database.cmd = new SqlCommand(Sql, Database.con);
        //        Database.cmd.Parameters.AddWithValue("@ItemName", ItemName);
        //        Database.cmd.ExecuteNonQuery();
        //        Database.da = new SqlDataAdapter(Database.cmd);
        //        Database.tbl = new System.Data.DataTable();
        //        Database.da.Fill(Database.tbl);
        //        if (Database.tbl.Rows.Count > 0)
        //        {
        //            MessageBox.Show($"{message} has been already!");
        //            return 1;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error check douplicate item:{ex}");
        //    }
        //    return 0;
        //}
    }
}
