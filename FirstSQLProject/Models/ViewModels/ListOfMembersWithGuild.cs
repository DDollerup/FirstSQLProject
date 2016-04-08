using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstSQLProject.Models.BaseModel;

namespace FirstSQLProject.Models.ViewModels
{
    public class ListOfMembersWithGuild
    {
        public List<Members> Members { get; set; }
        public Guild Guild { get; set; }
    }
}