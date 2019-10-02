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
    class EmailService
    {
        private string APIKey = "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";

        public EmailService(Spreadsheet sheet)
        {
            Sheet = sheet;
        }
        public Spreadsheet Sheet { get; set; }
        public async Task<Response> SendConfirmationEmail()
        {
            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("kimberly.castro13@outlook.com", "Kimberly Castro"));

            var recipients = new List<EmailAddress>
            {
                new EmailAddress("zachary.michaels@outlook.com", "Zach Michaels"),
                new EmailAddress("zachary.michaels@stmartin.edu", "Zach Michaels")
            };
            msg.AddTos(recipients);

            msg.SetSubject("Scaffold Testing");
            msg.AddContent(MimeType.Text, "Please confirm your email.");


            var client = new SendGridClient(APIKey);
            Response response = await client.SendEmailAsync(msg);
            return response;

        }

        public void OnEmailConfirmation(String email)
        {

        }
    }
}
