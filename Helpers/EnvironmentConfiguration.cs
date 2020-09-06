using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using NLog.Internal;
using System;

namespace MSTestFramework.Helpers
{
    public class EnvironmentConfiguration
    {
        public static string GetValue(string key)
        {
            var values = GetConfigValues();
            return values[key].ToString();
        }

        private static JObject GetConfigValues()
        {
            JObject values = null;

            try
            {
                var envConfigContents = JsonHelper.LoadJson($"{System.Configuration.ConfigurationManager.AppSettings["Environment"]}.json", "Configurations");
                values = JObject.Parse(envConfigContents.ToString());
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to get environment configuration value. {e.Message}");
                Assert.Fail($"Failed to get environment configuration value. {e.Message}");
            }

            return values;
        }
    }
}
