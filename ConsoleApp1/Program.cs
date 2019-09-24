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
                Excel.Range worksheet = xlWorksheet.UsedRange;
                int rowCount = worksheet.Rows.Count;
                int colCount = worksheet.Columns.Count;

                Person Kim = getPeople(worksheet);
               


                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(xlWorksheet);

                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                Console.ReadLine();
            }

            public static Person getPerson(Excel.Range worksheet, int row)
            {                         

                Person person = new Person();

                int FirstColumn = worksheet.Cells.EntireRow.Find("FirstName").Column;
                int LastColumn = worksheet.Cells.EntireRow.Find("LastName").Column;
                int OutlookColumn = worksheet.Cells.EntireRow.Find("Outlook").Column;
                int StMartinColumn = worksheet.Cells.EntireRow.Find("StMartin").Column;

                            

                    person.FirstName = worksheet.Cells[row, FirstColumn].Value;
                    person.LastName = worksheet.Cells[row, LastColumn].Value;
                    person.EmailOutlook = worksheet.Cells[row, OutlookColumn].Value;
                    person.EmailStMartins = worksheet.Cells[row, StMartinColumn].Value;
              
                return person;
            }

            public static Person getPeople(Excel.Range worksheet)
            {
                int rowCount = worksheet.Rows.Count;
               
                for (int row = 2; row <= rowCount; row++)
                {
                    Person person = getPerson(worksheet, row);
                    Console.WriteLine(person);
                }
                return null;
            }


        }

    }
}
