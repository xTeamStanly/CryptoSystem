using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library {
    public static class GUI {
        public static Color pastel_red = Color.FromArgb(255, 105, 97);
        public static Color pastel_green = Color.FromArgb(119, 221, 119);

        public static void SetColor(Control control, bool enabled) {
            if (control != null) {
                if (enabled == true) {
                    control.BackColor = pastel_green;
                    control.ForeColor = Color.Black;
                } else {
                    control.BackColor = pastel_red;
                    control.ForeColor = Color.White;
                }
            }
        }

        public static void SwapText(TextBox first, TextBox second) {
            if (first == null || second == null) { return; }

            string temp = first.Text;
            first.Text = second.Text;
            second.Text = temp;
        }

        public static void ShowError(string message) {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowInformation(string title, string message) {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
