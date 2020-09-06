using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestFramework.Helpers
{
    public class JsonHelper
    {
        public static JObject LoadJson(string filename, params string[] filePathFolders)
        {
            var jsonFilePath = string.Empty;

            try
            {
                if (filePathFolders.Length > 0)
                {
                    foreach (var item in filePathFolders)
                    {
                        jsonFilePath += $"{item}\\";
                    }

                    jsonFilePath += $"{filename}";
                    MyLogger.Log.Debug($"Created json data file path: {jsonFilePath}.");
                }
                else
                {
                    jsonFilePath = $"Json\\{filename}";
                    MyLogger.Log.Debug($"Created json data file path: {jsonFilePath}.");
                }
            } catch (Exception e)
            {
                if (filePathFolders.Length > 0)
                {
                    MyLogger.Log.Error($"Failed to retrieve json data with path: {jsonFilePath}. {e.Message}");
                    Assert.Fail($"Failed to retrieve json data with path: {jsonFilePath}. {e.Message}");
                } else
                {
                    MyLogger.Log.Error($"Failed to retrieve json data from file: {filename}. {e.Message}");
                    Assert.Fail($"Failed to retrieve json data from file: {filename}. {e.Message}");
                }
            }

            JObject data = null;

            try
            {
                data = JObject.Parse(File.ReadAllText(jsonFilePath));
                MyLogger.Log.Debug($"Retrieved json data: {data}");
            } catch (Exception e)
            {
                if (e.Message.Contains("Could not find a part of the path"))
                {
                    MyLogger.Log.Error($"Failed to find file with path: {jsonFilePath}. Make sure the file's 'Output Directory' is set to 'Copy always'. {e.Message}");
                    Assert.Fail($"Failed to find file with path: {jsonFilePath}. Make sure the file's 'Output Directory' is set to 'Copy always'. {e.Message}");
                } else
                {
                    MyLogger.Log.Error($"Failed to parse json data from path: {jsonFilePath}. {e.Message}");
                    Assert.Fail($"Failed to parse json data from path: {jsonFilePath}. {e.Message}");
                }
            }

            return data;
        }
    }
}
