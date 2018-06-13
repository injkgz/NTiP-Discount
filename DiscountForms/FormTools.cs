using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DiscountForms
{
    internal class FormTools
    {
        /// <summary>
        ///     Метод проверки введёного в TextBox значения
        ///     на корректность для Convert.ToDouble
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool CheckStringForDouble(string text)
        {
            if (text == null)
            {
                return true;
            }

            return Regex.IsMatch(text, @"^([0-9]*|[0-9]*[,][0-9]*)$");
        }

        /// <summary>
        ///     Проверка ввода корректного Double в TextBox
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="e"></param>
        public static void TextBoxCheck(TextBox textBox, CancelEventArgs e)
        {
            if (textBox.Text != "")
            {
                e.Cancel = !CheckStringForDouble(textBox.Text);
                if (e.Cancel)
                {
                    textBox.ForeColor = Color.Red;
                }
                else
                {
                    textBox.ForeColor = Color.Black;
                }
            }
        }
    }
}