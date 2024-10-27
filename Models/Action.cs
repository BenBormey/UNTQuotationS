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
        public virtual void create(DataGridView dg)
        {
          
        }

        public virtual void ExportExcel(DataGridView dg)
        {
            throw new NotImplementedException();
        }

        public virtual void Price(DataGridView dg)
        {
            throw new NotImplementedException();
        }


        public virtual void Update(DataGridView dg)
        {
            throw new NotImplementedException();
        }
    }
}
