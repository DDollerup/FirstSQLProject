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

        public ActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMemberSubmit(Members member)
        {
            membersFac.Add(member);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateMember(int id)
        {
            Members memberToUpdate = membersFac.Get(id);
            return View(memberToUpdate);
        }

        [HttpPost]
        public ActionResult UpdateMemberSubmit(Members member)
        {
            membersFac.Update(member);

            return RedirectToAction("Index");
        }


        public ActionResult DeleteMemberSubmit(int id)
        {
            membersFac.Delete(id);

            return RedirectToAction("Index");
        }
    }
}