using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    static class DataReader
    {
        public static int[] ReadCsvData(string fileName)
        {
            string lineFromFile = File.ReadAllText(fileName);
            string[] contents = lineFromFile.Split(',');
            return Array.ConvertAll(contents, int.Parse);
        }
    }
}
