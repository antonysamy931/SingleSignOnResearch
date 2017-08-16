using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CSVfiletest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = new FileInfo("SampleCSV.csv").Directory.FullName;
            DataTable obj = CSVFileReader.ConvertCSVtoDataTable("C:\\Users\\andrews_m\\Documents\\Visual Studio 2012\\Projects\\SingleSignOnImplementation\\CSVfiletest\\SampleCSV.csv");
            var data = (from o in obj.AsEnumerable()
                     where o.Field<string>("Name") == "Antony"
                     select o).FirstOrDefault();
        }
    }
}
