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
        void Create(DataGridView dg);
        void UpdateById(DataGridView dg);
        void DeleteById(DataGridView dg);
        void LoadingData(DataGridView dg);
        void PrintReprot(DataGridView dg);    
        void ExportToExcel(DataGridView dg);


    }
}
