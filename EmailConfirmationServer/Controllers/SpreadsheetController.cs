using EmailConfirmationService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Files"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    Debug.WriteLine("file saved ahhdha");

                    Spreadsheet spreadsheet = new Spreadsheet(path);
                    spreadsheet.getExcelFile();
                    EmailConfirmationService.EmailService emailService = new EmailConfirmationService.EmailService(spreadsheet);
                    var task = emailService.sendConfirmationEmails();
                    Debug.WriteLine("waiting on emails");
                    task.Wait();
                    Debug.WriteLine("emails done");

                    ViewBag.Message = "File uploaded successfully";
                    
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View("Upload");
        }
    }
}