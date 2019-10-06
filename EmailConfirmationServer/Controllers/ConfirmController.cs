using EmailConfirmationService;
using System.Web.Hosting;
using System.Web.Mvc;

namespace EmailConfirmationServer.Controllers
{
    public class EmailController : Controller
    {
        // GET: Confirm
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Confirm (string id)
        {
            
            string path = HostingEnvironment.ApplicationPhysicalPath + "/Files/TestSheet.xlsx";

            //Calls the constructor.
            Spreadsheet spreadsheet = new Spreadsheet(path);

            spreadsheet.getExcelFile();

            spreadsheet.ConfirmEmail(id);

            return View();
        }
    }
}