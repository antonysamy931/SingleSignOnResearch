using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;

namespace MvcApplication2.Models
{
    public class CSVFileReader
    {
        public static DataTable ConvertCSVtoDataTable(string filePath)
        {
            DataTable dt = new DataTable();
            StreamReader sReader = new StreamReader(filePath);
            string[] headers = sReader.ReadLine().Split(',');
            foreach (var item in headers)
            {
                dt.Columns.Add(item);
            }
            while (!sReader.EndOfStream)
            {
                string[] rows = sReader.ReadLine().Split(',');
                DataRow dr = dt.NewRow();
                for (var i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}