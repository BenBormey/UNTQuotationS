using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNT_Quotation.Models
{
    internal class User
    {
        public int Id { get; set; }
        public static int CreateBy { get; set; } = 1;
        public static int UpdateBy { get; set; } = 2;
    }
}
