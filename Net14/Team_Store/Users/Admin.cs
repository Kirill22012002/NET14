﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Store.Users.Admin
{
    public class Admin : IBaseUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public string IDUser { get; set; }

       

    }
}
