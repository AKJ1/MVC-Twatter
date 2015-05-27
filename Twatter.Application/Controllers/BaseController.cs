using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twatter.Data.UnitOfWork;

namespace Twatter.Application.Controllers
{
    public class BaseController : Controller
    {
        public TwatterData Data;

        public BaseController()
        {
            this.Data = new TwatterData();
        }
    }
}