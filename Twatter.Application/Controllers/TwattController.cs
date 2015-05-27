using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Twatter.Application.Models;
using Twatter.Data.UnitOfWork;
using Twatter.Models;

namespace Twatter.Application.Controllers
{
    public class TwattController : Controller
    {
        TwatterData data = new TwatterData();
        // GET: Twatt/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: Twatt/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(TwattPostModel model)
        {
            //return Json(model);
            try
            {
                bool isReply = model.IsReply != null && (bool) model.IsReply;
                Twatt twatt = new Twatt()
                {
                    Content = model.Text,
                    Poster = data.UserRepository.GetById(User.Identity.GetUserId()),
                    IsReply = isReply,
                    ReplyTo = data.TwattRepository.GetById(model.TwattId)
                };
                data.TwattRepository.Create(twatt);
                if (isReply)
                {
                    var replyToId = model.TwattId;
                    Twatt updateTwatt = data.TwattRepository.Get(t => t.Id == replyToId).First();
                    updateTwatt.Replies.Add(twatt);
                    data.TwattRepository.Update(updateTwatt);
                }
                data.Save();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
                
            }
            catch
            {
                throw;
            }
        }

        // DELETE : Twatt//5
        [Authorize]
        public ActionResult Delete(int id)
        {
            
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}
