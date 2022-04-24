using System;
using System.IO;
using System.Linq;

namespace IntegerOrdering.Services
{
    public class FileService : IFileService
    {
        private string _filePath;
        public FileService()
        {
            _filePath = @"Results\";
        }

        public bool WriteFile(int[] data)
        {
            try
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(_filePath, $"Results_{Guid.NewGuid()}.txt")))
                {
                    foreach (int i in data)
                    {
                        outputFile.Write($"{i} ");
                    };
                };
                return true;
            }
            catch
            {
                throw;
            }
        }

        public string GetLatestResults()
        {
            string result = "No results currently available";
            var directoryInfo = new DirectoryInfo(_filePath);
            var latestFile = directoryInfo.GetFiles("*.txt").OrderByDescending(f => f.LastWriteTime).FirstOrDefault();
            
            try
            {
                var retval = latestFile.FullName;
                using (StreamReader reader = new StreamReader(retval))
                {
                    result = $"Results of latest run: {reader.ReadToEnd()}";
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
