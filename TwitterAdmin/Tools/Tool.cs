using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TwitterAdmin.Tools
{
    public class Tool
    {
        public static bool IsPseudo(string pseudo)
        {
            string pattern = @"^[a-zA-Z\s\-]+$";
            return Regex.IsMatch(pseudo, pattern);
        }

       

        public static bool IsEmail(string phone)
        {
            string pattern = @"^0([1-9]{1})(\.|\s|-)?((\d){2}(\.|\s|-)?){3}(\d{2})$";
            return Regex.IsMatch(phone, pattern);
        }
    }
}
