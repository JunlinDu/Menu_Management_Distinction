using System;
using System.Collections.Generic;

namespace MenuManagement
{

    //<summary>
    // An Authentication class the check the username and password.
    // Only Authenticated people can login into the system.
    // </summary>
    public static class Authentication
    {
        //Mapping username and password as pairs.
        public static Dictionary<String, String> KeyAndVlauePairs= new Dictionary<String, String>();
        public static void RegisterAuthentication(String userName, String passWord)
        {
            KeyAndVlauePairs[userName] = passWord;
        }

        //Check if the username and the password matches each other.
        public static AuthenticationResult Identify(String userName, String password)
        {
            foreach(String key in KeyAndVlauePairs.Keys)
            {
                if(userName == key)
                {
                    if (KeyAndVlauePairs[userName].Equals(password))
                        return AuthenticationResult.nameNPasswordCorrect;
                    else
                        return AuthenticationResult.passwordIncorrect;
                }
            }
            return AuthenticationResult.userNameIncorrect;
        }
    }
}