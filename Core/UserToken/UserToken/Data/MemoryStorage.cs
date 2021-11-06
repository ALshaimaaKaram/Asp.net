using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserToken.Models;

namespace UserToken.Data
{
    public class MemoryStorage
    {
        public List<User> Users { get; set; }
        public MemoryStorage()
        {
            Users = new List<User>()
            {
                new User{ID = 1, UserName="Alshaimaa", Password="123" },
                new User{ID = 2, UserName="Muhammed", Password="123" }
            };
        }
    }
}
