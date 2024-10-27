using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNT_Quotation.Funtion
{
    internal class Funtions
    {
        public static int startBox(params TextBox[] textBoxes)
        {
            foreach (TextBox box in textBoxes)
            {
                if (box.Text.Equals("") || box.Text == "")
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
    }
}
