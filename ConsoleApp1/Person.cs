using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Person
    {
        //******************
        //****Properties****
        //******************
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailStMartins { get; set; }

        public string EmailOutlook { get; set; }
   }
}



        /*
         * User should be able to:
                Read and write from an Excel File

    We need to take Ann's spreadsheet and pull only the Name and two email addressess. 
    Then we need to generate a list of that info. 
    Then we need to send a preformatted email to each address. 
    The email needs to contain a confirmation link that the recipient can click. 
    The confirmation link needs to update the spreadsheet to indicate the email has been confirmed. 
         
         * Person Class
                Properties:
                    Row
                    Firstname
                    Lastname
                    email st martins
                    email outlook

                Methods:

         * Email service Class
                Properties:
                    spreadsheet

                Methods:
                    send
                    confirmation

         * Spreadsheet Class
                Properties:
                    file path
                    list of people

                Methods:
                    read data
                    write data
         * UI Class
                Properties:
                    Tarzan?

        * Main Class
                Methods:
                    Make it run

    */
               
 