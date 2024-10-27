using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNTQuotation.Models
{
    public  interface IAction
    {
        void create(DataGridView dg);
        void Update(DataGridView dg);
        void Price(DataGridView dg);    
        void ExportExcel(DataGridView dg);


    }
}
