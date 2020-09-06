using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace MSTestFramework.Helpers
{
    public class DataRandomizer
    {
        public enum DataType
        {
            AlphaLower,
            AlphaUpper,
            AlphaLowerUpper,
            Numeric,
            AlphaLowerNumeric,
            AlphaUpperNumeric,
            AlphaLowerUpperNumeric
        }

        private const string Numeric = "1234567890";
        private const string Alpha = "abcdefghijklmnopqrstuvwxyz";
        private static readonly Random Random = new Random();

        public static string CreateString(DataType type, int stringLength)
        {
            var value = string.Empty;

            switch (type)
            {
                case DataType.AlphaLower:
                    value = new string(Enumerable.Repeat(Alpha.ToLower(), stringLength).Select(s => s[Random.Next(s.Length)]).ToArray());
                    break;
                case DataType.AlphaUpper:
                    value = new string(Enumerable.Repeat(Alpha.ToUpper(), stringLength).Select(s => s[Random.Next(s.Length)]).ToArray());
                    break;
                case DataType.AlphaLowerUpper:
                    value = new string(Enumerable.Repeat(Alpha.ToLower() + Alpha.ToUpper(), stringLength).Select(s => s[Random.Next(s.Length)]).ToArray());
                    break;
                case DataType.AlphaLowerNumeric:
                    value = new string(Enumerable.Repeat(Alpha.ToLower() + Numeric, stringLength).Select(s => s[Random.Next(s.Length)]).ToArray());
                    break;
                case DataType.AlphaUpperNumeric:
                    value = new string(Enumerable.Repeat(Alpha.ToUpper() + Numeric, stringLength).Select(s => s[Random.Next(s.Length)]).ToArray());
                    break;
                case DataType.AlphaLowerUpperNumeric:
                    value = new string(Enumerable.Repeat(Alpha.ToLower() + Alpha.ToUpper() + Numeric, stringLength).Select(s => s[Random.Next(s.Length)]).ToArray());
                    break;
                case DataType.Numeric:
                    value = new string(Enumerable.Repeat(Numeric, stringLength).Select(s => s[Random.Next(s.Length)]).ToArray());
                    break;
            }

            return value;
        }

        public static int CreateInt(int length)
        {
            if (length > 9)
            {
                return 0;
            }

            var number = string.Empty;

            for (var x = 1; x <= length; x++)
            {
                number += Random.Next(0, 9).ToString();
            }

            if (number.StartsWith("0"))
            {
                number = number.Remove(0, 1);
                number += "0";
            }

            return int.Parse(number);
        }
    }
}
