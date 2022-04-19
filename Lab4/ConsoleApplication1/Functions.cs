using System.Text.RegularExpressions;
using static System.Text.RegularExpressions.Regex;

namespace ConsoleApplication1
{
    public class Functions
    {
        public static bool isValid(string date)
        {
            // Regex regex1 = new Regex(@"^\d{4}(-|\/|\.)(0?[1-9]|1[012])\1(0[1-9]|[12][0-9]|3[01])(\s*)");
            Regex regex2 = new Regex(@"^(0[1-9]|[12][0-9]|3[01])\.(0?[1-9]|1[012])\.\d{4}(\s*)");
            // Regex regex3 = new Regex(@"^(0?[1-9]|1[012])(-|\/|\.)(0[1-9]|[12][0-9]|3[01])(\s*)");
            Regex regex4 = new Regex(@"^(0[1-9]|[12][0-9]|3[01])\.(0?[1-9]|1[012])(\s*)");

            if ( regex2.IsMatch(date) || regex4.IsMatch(date)) return true;
            
            return false;
        }
    }
}