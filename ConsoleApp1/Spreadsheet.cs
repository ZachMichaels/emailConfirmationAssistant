﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ConsoleApp1
{
    class Spreadsheet
    {
        public List<Person> Students { get; set; }

        public string FilePath { get; set; }

        public Excel.Range range { get; set; }
        public Spreadsheet(string filepath)
        {
            FilePath = filepath;
            Students = new List<Person>();
        }
        public Excel.Worksheet worksheet { get; set; }

        public Excel.Workbook workbook { get; set; }

        public Excel.Application app { get; set; }

        public void openSheet()
        {
            app = new Excel.Application();
            workbook = app.Workbooks.Open(FilePath);
            worksheet = workbook.Sheets[1];
            range = worksheet.UsedRange;

        }

        public void closeSheet()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(worksheet);
            workbook.Close();
            Marshal.ReleaseComObject(workbook);

            app.Quit();
            Marshal.ReleaseComObject(app);
        }

        public void SaveAndCloseSheet()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(worksheet);

            workbook.Save();
            workbook.Close();
            Marshal.ReleaseComObject(workbook);

            app.Quit();
            Marshal.ReleaseComObject(app);
        }

        public void getExcelFile()
        {
            try
            {
                openSheet();

                int rowCount = worksheet.Rows.Count;
                int colCount = worksheet.Columns.Count;

                getStudents(range);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                closeSheet();
            }
            

        }
        public Person getStudents(Excel.Range worksheet)
        {
            int rowCount = worksheet.Rows.Count;

            for (int row = 2; row <= rowCount; row++)
            {
                Person person = getPerson(worksheet, row);
                //Console.WriteLine(person);
                Students.Add(person);
          
            }
            return null;
        }
        public Person getPerson(Excel.Range worksheet, int row)
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

        // this function updates the excel file and changes cell to green after an email confirm takes place
        public void ConfirmEmail(String email)
        {
            try
            {
                openSheet();
                Excel.Range range = FindEmailCell(email);
                ChangeCellColor(range, Excel.XlRgbColor.rgbLightGreen);
                string filepath = "lol";
            }
            catch
            {
                Console.WriteLine("Your program sucks bro");
            }
            finally
            {
               SaveAndCloseSheet();
            }
            
        }

        // this function finds the correct email to update in the spreadsheet
        public Excel.Range FindEmailCell(String email)
        {
            int column = 0;

            if (email.Contains("@outlook.com"))
            {
              
                column = range.Cells.EntireRow.Find("Outlook").Column;

            }
            else
            {
                column = range.Cells.EntireRow.Find("StMartin").Column;
            }

            int rowCount = range.Rows.Count;


            Excel.Range cell = null;
            for (int row = 2; row <= rowCount; row++)
            {
                if (email.Equals(range.Cells[row, column].Value))
                {
                    cell = range.Cells[row, column];
                    break;
                }
            }
            return cell;
        }

        public void ChangeCellColor(Excel.Range range, Excel.XlRgbColor color)
        {
            range.Interior.Color = color;
        }
       
    }
}
