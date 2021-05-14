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

       

        public static bool IsEmail(string email)
        {
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            return Regex.IsMatch(email, pattern);
        }
    }
}
