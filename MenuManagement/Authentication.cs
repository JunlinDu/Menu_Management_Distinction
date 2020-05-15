using System;
using System.Collections.Generic;

namespace MenuManagement
{
    public static class Authentication
    {
        public static Dictionary<String, String> KeyAndVlauePairs= new Dictionary<String, String>();
        public static void RegisterAuthentication(String userName, String passWord)
        {
            KeyAndVlauePairs[userName] = passWord;
        }

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