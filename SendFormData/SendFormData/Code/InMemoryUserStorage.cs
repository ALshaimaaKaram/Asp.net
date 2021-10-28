using SendFormData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendFormData.Code
{
    public class InMemoryUserStorage
    {
        public static List<User> Users { get; set; }

        static InMemoryUserStorage()
        {
            Users = new List<User>()
            {
                new User(){ ID = 1, UserName = "muhammed", Password = "123456789" },
                new User(){ ID = 2, UserName = "alshaimaa", Password = "123456789" },
                new User(){ ID = 3, UserName = "rofida", Password = "123456789" }
            };
        }
    }
}