using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstSQLProject.Factory;
using FirstSQLProject.Models.BaseModel;
using FirstSQLProject.Models.ViewModels;

namespace FirstSQLProject.Controllers
{
    public class HomeController : Controller
    {
        MembersFac membersFac = new MembersFac();
        GuildFac guildFac = new GuildFac();

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
        /// <summary>
        /// Returns a View that clarifies a member with guild data
        /// </summary>
        /// <param name="id">Member ID</param>
        /// <returns></returns>
        public ActionResult ShowDetailedMember(int id)
        {
            Members member = membersFac.Get(id);
            Guild guild = guildFac.Get(member.GuildID);

            MemberWithGuild mwg = new MemberWithGuild();
            mwg.Member = member;
            mwg.Guild = guild;

            return View(mwg);
        }

        // id is GuildID
        public ActionResult MembersWithGuild(int id)
        {
            Guild guild = guildFac.Get(id);
            List<Members> membersWithGuild = membersFac.GetAllByGuildID(guild.ID);

            ListOfMembersWithGuild lmg = new ListOfMembersWithGuild();
            lmg.Guild = guild;
            lmg.Members = membersWithGuild;

            return View(lmg);
        }


        public ActionResult AddGuild()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGuildSubmit(Guild guild)
        {
            guildFac.Add(guild);
            return RedirectToAction("Index");
        }

        public ActionResult AddMemberWithGuild()
        {
            ViewBag.Guilds = guildFac.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult AddMemberWithGuildSubmit(Members member)
        {
            membersFac.Add(member);
            return RedirectToAction("Index");
        }
    }
}