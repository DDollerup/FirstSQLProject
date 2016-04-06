using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstSQLProject.Factory;
using FirstSQLProject.Models.BaseModel;

namespace FirstSQLProject.Controllers
{
    public class HomeController : Controller
    {
        MembersFac membersFac = new MembersFac();

        // GET: Home
        public ActionResult Index()
        {
            List<Members> allMembers = membersFac.GetAll();
            return View(allMembers);
        }

        public ActionResult ShowMember(int id)
        {
            Members member = membersFac.Get(id);
            return View(member);
        }
    }
}