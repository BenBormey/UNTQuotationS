using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNTQuotation.Models
{
    internal class Action : IAction
    {
        public virtual void Create(DataGridView dg)
        {
          
        }

        public virtual void DeleteById(DataGridView dg)
        {
            throw new NotImplementedException();
        }

        public virtual void ExportToExcel(DataGridView dg)
        {
            throw new NotImplementedException();
        }

        public  virtual void LoadingData(DataGridView dg)
        {
            throw new NotImplementedException();
        }

        public virtual void PrintReprot(DataGridView dg)
        {
            throw new NotImplementedException();
        }


        public virtual void UpdateById(DataGridView dg)
        {
            throw new NotImplementedException();
        }

        public virtual void ExportToExcel()
        {
            throw new NotImplementedException();
        }
    }
}
