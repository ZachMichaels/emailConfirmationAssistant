using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Newtonsoft.Json;

namespace EmailConfirmationServer.Models
{
    public class EmailService
    {
        private string APIKey = "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";

        public EmailService(Spreadsheet sheet)
        {
            Sheet = sheet;
        }

        public Spreadsheet Sheet { get; set; }

        public async Task sendConfirmationEmails()
        {
            var msg = new SendGridMessage();

           msg.SetFrom( new EmailAddress("test.email.from.app@stmartin.com", "MSSA"));

            var recipients = new List<EmailAddress>();

            var tasks = new List<Task>();
            foreach (Person person in Sheet.Persons)
            {   foreach (var email in person.Emails)
                {
                    await sendConfirmationEmail(email.EmailAddress, person.FirstName, person.Id);
                }                                 
            }            
        }

        public async Task<Response> sendConfirmationEmail(string email, string name, int id)
        {
            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("kimberly.castro13@outlook.com", "MSSA"));

            var recipients = new List<EmailAddress>();
            recipients.Add(new EmailAddress(email, name));
            msg.AddTos(recipients);
          
            msg.SetTemplateId("d-8dbd045f80d44095b9b193bbc594706c");

            var dynamicTemplateData = new UserInfo
            {
                Name = name,
                Email = email,
                Id = id
            };

            msg.SetTemplateData(dynamicTemplateData);

            var client = new SendGridClient(APIKey);
            Response response = await client.SendEmailAsync(msg);
            return response;
        }

        private class UserInfo
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }
        }

        public void ConfirmEmail(String email)
        {
            Sheet.ConfirmEmail(email);
        }
    }
}
