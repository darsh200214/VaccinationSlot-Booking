using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Business
{
    public class Utilities
    {
        public static string get_unique_string(int string_length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bit_count = (string_length * 6);
                var byte_count = ((bit_count + 7) / 8); // rounded up
                var bytes = new byte[byte_count];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
       
        public static int get_unique_number(int num_length)
        {
            string _numbers = "0123456789";
            Random random = new Random();
            StringBuilder builder = new StringBuilder(num_length);
            string numberAsString = "";
            for (var i = 0; i < num_length; i++)
            {
                builder.Append(_numbers[random.Next(0, _numbers.Length)]);
            }
            numberAsString = builder.ToString();
            return int.Parse(numberAsString);
        }
    }
}
