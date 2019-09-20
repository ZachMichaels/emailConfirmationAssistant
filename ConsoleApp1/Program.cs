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
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"H:\Test\YourWorkbook.xlsx");
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;
                //Console.WriteLine(xlRange.Columns);
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                Person Kim = new Person();


                for (int r = 1; r <= rowCount; r++)
                {
                    for (int c = 1; c <= colCount; c++)
                    {
                        //if (r == 1)
                            //Console.Write("\r\n");
                        //if (xlRange.Cells[r, c] != null && xlRange.Cells[r, c].Value2 != null)
                            Console.WriteLine(xlRange.Cells[r, c].Value2.ToString() + "\t");
                    }
                }

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
        }

    }
}
