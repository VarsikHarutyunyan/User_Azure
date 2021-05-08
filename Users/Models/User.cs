using System;
using System.Collections.Generic;
using System.Text;

namespace Users.Models
{
    public class User
    {
        public string Name { get; internal set; }
        public string Password { get; internal set; }
        public int Id { get; internal set; }
    }
}
