using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMA
{
    public class Utility
    {
        public static void TextBox_KeyPress_Filte_Positive_Number_Only(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        public static void TextBox_KeyPress_Filte_Number_Only(object sender, KeyPressEventArgs e)
        {
            var Minus = (char)45;
            if (e.KeyChar == Minus && (sender as TextBox).Text.Length == 0)
            {
                e.Handled = false;
            }
            else
            {
                const char Delete = (char)8;
                e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
            }
        }
    }
}
