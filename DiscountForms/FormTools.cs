using System.Text.RegularExpressions;

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
            ;
        }
    }
}