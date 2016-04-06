using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstSQLProject.Models.BaseModel
{
    public class Members
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public int GuildID { get; set; }
    }
}