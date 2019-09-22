using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main (string[] args)
        {
            Read_From_Excel.getExcelFile();
        }
        public class Read_From_Excel
        {
            public static void getExcelFile()
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"H:\Test\YourWorkbook2.xlsx");
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                Person Kim = getPerson(xlRange);
                Console.WriteLine(Kim);


                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                Console.ReadLine();
            }

            public static Person getPerson(Excel.Range xlRange)
            {
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                Person Kim = new Person();

                int FirstColumn = xlRange.Cells.EntireRow.Find("FirstName").Column;
                int LastColumn = xlRange.Cells.EntireRow.Find("LastName").Column;
                int OutlookColumn = xlRange.Cells.EntireRow.Find("Outlook").Column;
                int StMartinColumn = xlRange.Cells.EntireRow.Find("StMartin").Column;

                for (int r = 1; r <= rowCount; r++)
                {

                    Kim.FirstName = xlRange.Cells[r, FirstColumn].Value;
                    Kim.LastName = xlRange.Cells[r, LastColumn].Value;
                    Kim.EmailOutlook = xlRange.Cells[r, OutlookColumn].Value;
                    Kim.EmailStMartins = xlRange.Cells[r, StMartinColumn].Value;
                }
                return Kim;
            }

            public static Person getPeople(Excel.Range xlRange)
            {
                //forloop
                //getPerson()
                return null;
            }


        }

    }
}
