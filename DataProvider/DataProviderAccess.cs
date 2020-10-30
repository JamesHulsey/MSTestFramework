using MSTestFramework.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestFramework.DataProvider
{
    public class DataProviderAccess
    {
        /// <summary>
        /// Retrieves the test data from the json file as a JObject. Looks for the test data file under the folder "TestData" by default.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static JObject GetData(string filename)
        {
            JObject data;

            try
            {
                data = JsonHelper.LoadJson(filename, "TestData");
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to get test data from file: {filename}. {e.Message}");
                throw e;
            }

            return data;
        }
    }
}
