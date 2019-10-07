using EmailConfirmationService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmailConfirmationServer.Controllers
{
    public class SpreadsheetController : Controller
    {
        // GET: Spreadsheet
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Files"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);                    
                    Spreadsheet spreadsheet = new Spreadsheet(path);
                    //spreadsheet.getExcelFile();
                    var testEmails = new List<Person>()
                    {
                        new Person(){FirstName= "Isaac", LastName = "Flores",
                            EmailOutlook ="isaac.flores2@outlook.com", EmailStMartins = "isaac.flores@stmartin.edu"},
                        new Person(){FirstName= "Isaac", LastName = "Flores",
                            EmailOutlook ="isaac.a.flores2@gmail.com", EmailStMartins = "izmac0072@gmail.com"}
                    };
                    spreadsheet.Persons.AddRange(testEmails);

                    EmailConfirmationService.EmailService emailService = new EmailConfirmationService.EmailService(spreadsheet);
                    await emailService.sendConfirmationEmails();                                                           
                    ViewBag.Message = "File uploaded successfully";

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View("Upload");
        }
    }
}