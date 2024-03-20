﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp
{
    internal class Admin
    {
        private string username;
        private string password;
    
          public Admin(string username, string password)
          {
                this.username = username;
                this.password = password;
          }
    
          public string Username
          {
                get { return username; }
                set { username = value; }
          }
    
          public string Password
          {
                get { return password; }
                set { password = value; }
          }
    }
}
