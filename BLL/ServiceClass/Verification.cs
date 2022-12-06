//verification class deals with email verification request and returns whether the user is verified or not 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfaces;
using System.Net.Mail;
using Model;
using DAL.DALClasses;

namespace BLL.ServiceClass
{
    public class Verification : IVerification
    {
        private CustomerDAL _customerDAL = new CustomerDAL();

        // returns user verification status 
        public bool isVerified(UserModel user)
        {
            int userID = user.UserId;
            bool isVerified = _customerDAL.Verify(userID);
            return isVerified;
        }

        // send verification mail to user if not verified 
        public void verify(UserModel user)
        {
            try
            {
                MailMessage newMail = new MailMessage();
                // use the Gmail SMTP Host
                SmtpClient client = new SmtpClient("smtp.gmail.com");

                // Follow the RFS 5321 Email Standard
                newMail.From = new MailAddress("piyushnagpal1998@gmail.com", "Piyush Nagpal");

                newMail.To.Add(user.Email);// declare the email subject

                newMail.Subject = "Hello" + user.FirstName + "this is a verification mail from sport areana"; // use HTML for the email body

                newMail.IsBodyHtml = true; newMail.Body = "<h1> Here there will be the .net web api link to update the status field </h1>";

                // enable SSL for encryption across channels
                client.EnableSsl = true;
                // Port 465 for SSL communication
                client.Port = 465;
                // Provide authentication information with Gmail SMTP server to authenticate your sender account
                client.Credentials = new System.Net.NetworkCredential("piyushnagpal1998@gmail.com", "assasinscreed");

                client.Send(newMail); // Send the constructed mail
                Console.WriteLine("Email Sent");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error -" + ex);
            }
        }

    }
}




