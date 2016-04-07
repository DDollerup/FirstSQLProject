using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstSQLProject.Models.BaseModel;

namespace FirstSQLProject.Models.ViewModels
{
    public class MemberWithGuild
    {
        public Members Member { get; set; }
        public Guild Guild { get; set; }
    }
}