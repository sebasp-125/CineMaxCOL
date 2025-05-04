using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineMaxCOL_BILL.Service
{
    public class SendEmails
    {
        //This is a fuction but send emails.
        public async Task<bool> SendEmail(string to , string sentence){
            try{
                return true;
            }catch{
                return false;
            }
        }

        //This is a verification email.
        //Explication here: CineMaxCOL send a email to user´s email, 
        public async Task<bool> VerificationEmail(string email){
            try{
                return true;
            }catch{
                return false;
            } 
        }
    }
}