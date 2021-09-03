using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;
namespace IMDB
{
        public class Validate
        {
            public bool NameValidate(string name)
            {
                if (!Regex.Match(name, @"^[\p{L}\p{M}' \.\-]+$").Success)
                {
                    Console.WriteLine("Invalid name");
                    return false;
                }
                return true;
            }
            public bool DobValidate(string d, out DateTime dob)
            {
                DateTimeFormatInfo info = new DateTimeFormatInfo();
                info.ShortDatePattern = "dd/MM/yyyy";
                bool aman = DateTime.TryParse(d, info, DateTimeStyles.None, out dob);
                return aman;

            }
            public bool ActorList(string[] actors)
            {
                foreach (var item in actors)
                {
                    if (string.IsNullOrWhiteSpace(item))
                    {
                        return false;
                    }
                    else if(!int.TryParse(item, out int n))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
}
