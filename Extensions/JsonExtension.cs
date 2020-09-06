using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestFramework.Extensions
{
    public static class JsonExtension
    {
        public static string GetString(this JObject json, string key)
        {
            var value = string.Empty;

            try
            {
                value = json[key].ToString();
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"No value found for key: {key} in json: {json}. {e.Message}");
                Assert.Fail($"No value found for key: {key} in json: {json}. {e.Message}");
            }

            return value;
        }

        public static int GetInt(this JObject json, string key)
        {
            var value = 0;

            try
            {
                var stringValue = json[key].ToString();

                try
                {
                    value = int.Parse(stringValue);
                }
                catch (Exception e)
                {
                    MyLogger.Log.Error($"Unable to parse value to int: {stringValue}. {e.Message}");
                }
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"No value found for key: {key} in json: {json}. {e.Message}");
                Assert.Fail($"No value found for key: {key} in json: {json}. {e.Message}");
            }

            return value;
        }

        public static long GetLong(this JObject json, string key)
        {
            var value = 0L;

            try
            {
                var stringValue = json[key].ToString();

                try
                {
                    value = long.Parse(stringValue);
                }
                catch (Exception e)
                {
                    MyLogger.Log.Error($"Unable to parse value to long: {stringValue}. {e.Message}");
                }
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"No value found for key: {key} in json: {json}. {e.Message}");
                Assert.Fail($"No value found for key: {key} in json: {json}. {e.Message}");
            }

            return value;
        }

        public static double GetDouble(this JObject json, string key)
        {
            var value = 0d;

            try
            {
                var stringValue = json[key].ToString();

                try
                {
                    value = double.Parse(stringValue);
                }
                catch (Exception e)
                {
                    MyLogger.Log.Error($"Unable to parse value to double: {stringValue}. {e.Message}");
                }
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"No value found for key: {key} in json: {json}. {e.Message}");
                Assert.Fail($"No value found for key: {key} in json: {json}. {e.Message}");
            }

            return value;
        }

        public static decimal GetDecimal(this JObject json, string key)
        {
            var value = 0m;

            try
            {
                var stringValue = json[key].ToString();

                try
                {
                    value = decimal.Parse(stringValue);
                }
                catch (Exception e)
                {
                    MyLogger.Log.Error($"Unable to parse value to decimal: {stringValue}. {e.Message}");
                }
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"No value found for key: {key} in json: {json}. {e.Message}");
                Assert.Fail($"No value found for key: {key} in json: {json}. {e.Message}");
            }

            return value;
        }

        public static bool GetBoolean(this JObject json, string key)
        {
            var value = false;

            try
            {
                var stringValue = json[key].ToString();

                try
                {
                    value = bool.Parse(stringValue);
                }
                catch (Exception e)
                {
                    MyLogger.Log.Error($"Unable to parse value to bool: {stringValue}. {e.Message}");
                }
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"No value found for key: {key} in json: {json}. {e.Message}");
                Assert.Fail($"No value found for key: {key} in json: {json}. {e.Message}");
            }

            return value;
        }

        public static DateTime GetDateTime(this JObject json, string key)
        {
            var value = new DateTime();

            try
            {
                var stringValue = json[key].ToString();

                try
                {
                    value = DateTime.Parse(stringValue);
                }
                catch (Exception e)
                {
                    MyLogger.Log.Error($"Unable to parse value to date/time: {stringValue}. {e.Message}");
                }
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"No value found for key: {key} in json: {json}. {e.Message}");
                Assert.Fail($"No value found for key: {key} in json: {json}. {e.Message}");
            }

            return value;
        }
    }
}
