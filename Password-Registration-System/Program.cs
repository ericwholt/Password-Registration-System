using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Password_Registration_System
{
    class Program
    {
        public static List<string> emailList = new List<string>();
        public static List<string> passwordList = new List<string>();
        static void Main(string[] args)
        {

            Console.WriteLine("Assert True: " + RegisterUser("eric@email.com", "Abcd1234"));
            //Console.WriteLine("Assert False-No @: " + RegisterUser("ericemail.com", "Abcd1234"));
            //Console.WriteLine("Assert False-No Period: " + RegisterUser("eric@emailcom", "Abcd1234"));
            //Console.WriteLine("Asert False-Symbol in name: " + RegisterUser("eric#@email.com", "Abcd1234"));
            //Console.WriteLine("Assert False-Symbol in domain: " + RegisterUser("eric@ema@il.com", "Abcd1234"));
            //Console.WriteLine("Assert False-Number in ending: "+RegisterUser("eric@email.c1om", "Abcd1234"));
            //Console.WriteLine("Assert False-Symbol in ending: "+RegisterUser("eric@email.co#m", "Abcd1234"));
            //Console.WriteLine("Assert False-ending to short: "+RegisterUser("eric@email.c", "Abcd1234"));
            //Console.WriteLine("Password Tests");
            Console.WriteLine(RegisterUser("sandra@email.com", "1234Abcd"));
            //Console.WriteLine(RegisterUser("sandra@email.com", "Abcd1234@"));
            //Console.WriteLine(RegisterUser("sandra@email.com", "abcd1234"));
            //Console.WriteLine(RegisterUser("sandra@email.com", "Abcde"));
            //Console.WriteLine(RegisterUser("sandra@email.com", "12345"));
            //Console.WriteLine(RegisterUser("sandra@email.com", "Ab34"));
            //Console.WriteLine(RegisterUser("sandra@email.com", "$%#$"));
            Console.WriteLine("Assert True: "+login("sandra@email.com", "1234Abcd"));
            Console.WriteLine("Assert True: "+login("sandra@email.com", "Abcd1234"));
            Console.WriteLine("Assert True: "+login("eric@email.com", "1234Abcd"));
            Console.WriteLine("Assert True: "+login("eric@email.com", "Abcd1234"));
            Console.WriteLine("Assert False: " + login("eric@gmail.com", "Abcd234"));
            Console.WriteLine("Assert False: "+ login("eric@gmail.co", "Abcd1234"));
            Console.WriteLine("Assert False: " + login("sandra@emai.com", "Abcd1234"));
            Console.WriteLine("Assert False: " + login("sandra@email.com", "Abd1234"));
        }

        public static bool RegisterUser(string email, string password)
        {
            bool emailvalidated = false;
            bool passwordValidated = false;

            /*
             *  Validate email
                A name with 1 or more letters or numbers
                A @ after the name 
                A Domain with 1 or more letters or numbers
                A period after the domain
                An ending with 2-3 characters 
                If an incorrect email is input, throw an exception detailing specifically why it is invalid. (IE no @ after the name).
                Catch the exception and print out the message detailing the error. Lastly return a false. 
             */


            try
            {
                string exMessage = "Your email does not meet the following guidelines\n";
                bool emailAtSymbolTestPass = false;
                if (email.IndexOf('@') > 0)
                {
                    emailAtSymbolTestPass = true;
                }
                else
                {
                    exMessage += "Must have an @ symbol.\n";
                }

                bool emailPeriodSymbolTestPass = false;
                if (email.IndexOf('.') > 0)
                {
                    emailPeriodSymbolTestPass = true;
                }
                else
                {
                    exMessage += "Must have a period.\n";
                }

                bool emailNameTestPass = false;
                bool emailDomainCharTestPass = false;
                bool emailEndingLengthTestPass = false;
                bool emailEndingAlphaOnlyTestPass = false;
                if (email.IndexOf('@') > 0 && email.IndexOf('.') > 0)
                {
                    string name = email.Substring(0, email.IndexOf('@'));
                    if (Regex.IsMatch(name, @"^[a-zA-Z\d]+$"))
                    {
                        emailNameTestPass = true;
                    }
                    else
                    {
                        exMessage += "Name must be before the @ symbol and contain only letters and numbers.\n";
                    }
                    string domain = email.Substring(email.IndexOf('@') + 1, email.IndexOf('.') - (email.IndexOf('@') + 1));
                    if (Regex.IsMatch(domain, @"^[a-zA-Z\d]+$"))
                    {
                        emailDomainCharTestPass = true;
                    }
                    else
                    {
                        exMessage += "The domain section after @ and before . must contain only letters and digits.\n";
                    }
                    string ending = email.Substring(email.IndexOf('.') + 1);
                    if (ending.Length > 1 && ending.Length < 4)
                    {
                        emailEndingLengthTestPass = true;
                    }
                    else
                    {
                        exMessage += "The ending section after the . must be 2-3 characters.\n";
                    }
                    if (Regex.IsMatch(ending, @"^[a-zA-Z]+$"))
                    {
                        emailEndingAlphaOnlyTestPass = true;
                    }
                    else
                    {
                        exMessage += "The ending section after the . must contain only letters.\n";
                    }
                }

                if (emailAtSymbolTestPass && emailPeriodSymbolTestPass && emailNameTestPass && emailDomainCharTestPass && emailEndingLengthTestPass && emailEndingAlphaOnlyTestPass)
                {
                    emailvalidated = true;
                }
                else
                {
                    throw new Exception(exMessage);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            /*           
                The user should input a password with the following requirements: 
                    The password must be 5 or more characters long
                    The password must contain uppercase letters 
                    The password must contain at least one number
                If an incorrect password is input, throw an exception detailing specifically why it is invalid. 
                (IE too few characters or no uppercase char). Catch the exception and print out the message detailing the error. Lastly return a false. 
             */
            try
            {
                string exMessage = "Your password does not meet the following guidelines\n";
                bool passwordLengthTestPass = false;
                if (password.Length > 4)
                {
                    passwordLengthTestPass = true;
                }
                else
                {
                    exMessage += "Must have at least 5 characters.\n";
                }
                bool passwordUpperTestPass = false;
                if (password.Any(char.IsUpper))
                {
                    passwordUpperTestPass = true;
                }
                else
                {
                    exMessage += "Must have at least 1 uppercase letter.\n";
                }
                bool passwordDigitTestPass = false;
                if (password.Any(char.IsNumber))
                {
                    passwordDigitTestPass = true;
                }
                else
                {
                    exMessage += "Must have at least 1 number.";
                }

                if (passwordLengthTestPass && passwordUpperTestPass && passwordDigitTestPass)
                {
                    passwordValidated = true;
                }
                else
                {
                    throw new Exception(exMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (emailvalidated && passwordValidated)
            {
                emailList.Add(email);
                passwordList.Add(password);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool login(string email, string password)
        {
            if (emailList.Contains(email) && passwordList.Contains(password))
            {
                return true;
            }
            return false;
        }
    }
}
