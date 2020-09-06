using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSTestFramework.Helpers
{
    public class FileHelper
    {
        public static string RetrieveFileContents(string fileName, params string[] folderPath)
        {
            var fileContents = string.Empty;
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}\\";
            var sb = new StringBuilder();

            try
            {
                sb.Append(path);

                foreach (var folder in folderPath)
                {
                    sb.Append($"{folder}\\");
                }

                sb.Append(fileName);

                using (var r = File.OpenText(sb.ToString()))
                {
                    fileContents = r.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Unable to retrieve file contents from file: {fileName} and path: {path}. {e.Message}");
                Assert.Fail($"Unable to retrieve file contents from file: {fileName} and path: {path}. {e.Message}");
            }

            return fileContents;
        }

        public static void WaitForFileDownload(string filename, string downloadFilePath = "", int maxTimeoutInSeconds = 30)
        {
            var exists = false;

            try
            {
                downloadFilePath = string.IsNullOrEmpty(downloadFilePath) ? $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\downloads" : downloadFilePath;

                for (var x = 0; x <= maxTimeoutInSeconds; x++)
                {
                    if (!File.Exists($"{downloadFilePath}\\{filename}"))
                    {
                        Thread.Sleep(1000);
                    } else
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    MyLogger.Log.Error($"File: {filename} failed to download to path: {downloadFilePath} within the specified time limit: {maxTimeoutInSeconds} seconds.");
                    Assert.Fail($"File: {filename} failed to download to path: {downloadFilePath} within the specified time limit: {maxTimeoutInSeconds} seconds.");
                }
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Exception while trying to download file: {filename} to path: {downloadFilePath}. {e.Message}");
                Assert.Fail($"Exception while trying to download file: {filename} to path: {downloadFilePath}. {e.Message}");
            }
        }

        public static void DeleteFile(string filePath, string filename)
        {
            try
            {
                if (File.Exists($"{filePath}\\{filename}"))
                {
                    File.Delete($"{filePath}\\{filename}");
                    MyLogger.Log.Debug($"Deleted file: {filename} from path: {filePath}.");
                } else
                {
                    MyLogger.Log.Debug($"File: {filename} not found using path: {filePath}.");
                }
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to delete file: {filename} using path: {filePath}. {e.Message}");
                Assert.Fail($"Failed to delete file: {filename} using path: {filePath}. {e.Message}");
            }
        }
    }
}
