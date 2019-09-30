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
    class EmailService
    {
        public EmailService(Spreadsheet sheet)
        {
            Sheet = sheet;
        }
        public Spreadsheet Sheet { get; set; }
        public void SendConfirmationEmail()
        {

        }

        public void OnEmailConfirmation(String email)
        {

        }
    }
}
