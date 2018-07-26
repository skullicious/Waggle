using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waggle.cmn
{
    public static class StringHandler
    {

        //add a library of string handlers

            //extension method
        public static string InsertSpaces(this string source)
        {
            string result = string.Empty;

            if (!String.IsNullOrWhiteSpace(source))
            {
                foreach (char letter in source)
                {
                    if (char.IsUpper(letter))
                    {
                        result = result.Trim();
                        result += " ";
                    }
                    result += letter;
                }
                result = result.Trim();
            }
                return result;
        }

      // method to check string length

        public static string CheckStringLength(string source)
        {
            string result = null;

            if (source.Length < 3 || source.Length > 20)
            {
                result = "Data entry must be between 3 and 20 characters";
                return result;
            }

            return result;
           
        }



    }
}
