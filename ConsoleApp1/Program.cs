using System;
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
    class Program
    {
        public static void Main (string[] args)
        {
            //string path = @"H:\Test\YourWorkbook4.xlsx";

            //Calls the constructor.
           //Spreadsheet spreadsheet = new Spreadsheet(path);

            //spreadsheet.getExcelFile();

            //foreach (var person in spreadsheet.Students)
            //{
            //    Console.WriteLine(person);
            //}

            //spreadsheet.ConfirmEmail("tarzan.castro@outlook.com");
            sendemail();
           

        }

        static async void sendemail()
        {
            string path = @"H:\Test\YourWorkbook4.xlsx";
            Spreadsheet spreadsheet = new Spreadsheet(path);
            EmailService emailService = new EmailService(spreadsheet);

            emailService.SendConfirmationEmail().Wait();
        }

    }
}
