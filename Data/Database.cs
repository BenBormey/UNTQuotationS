using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNT_quotation.Data
{
    internal class Database
    {
        public static SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-KAJJLGQ\BORMEYBEN; Initial Catalog=QutationImformationHome; User ID = sa; Password=123;Integrated Security=True;TrustServerCertificate=true;Trusted_Connection=false");
        public static SqlCommand cmd;
        public static SqlDataAdapter da;
        public static DataTable tbl;
        public static void connetion()
        {
            try
            {

                if (con.State != ConnectionState.Open)
                {

                    con.Open();

                }

            }
            catch (Exception e)
            {

                MessageBox.Show("Error:" + e.Message);

            }
        }
    }
}
