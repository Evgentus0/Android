using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Laba3.BLL
{
    class FileWork
    {
        private string path;

        public FileWork(string path)
        {
            this.path = path;
        }

        public void WriteToFile(Dictionary<double, double> keyValues, double from, double to, double step)
        {
            string result = GenerateMessage(keyValues, from, to, step);
            File.WriteAllText(path, result);
        }

        private string GenerateMessage(Dictionary<double, double> keyValues, double from, double to, double step)
        {
            string result = string.Empty;
            result += $"From: {from}; To: {to}; Step: {step}{Environment.NewLine}";
            foreach (var element in keyValues)
            {
                result += $"{element.Key}: {element.Value}{Environment.NewLine}";
            }
            return result;
        }

        public string ReadFromFile()
        {
            bool doesExist = File.Exists(path);
            string result;
            if (doesExist)
            {
                result = File.ReadAllText(path);
            }
            else
            {
                throw new Exception("File does not exist");
            }
            return result;
        }
    }
}
