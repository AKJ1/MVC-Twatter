using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twatter.Models;

namespace Twatter.Application.Models
{
    public class TwattPostModel
    {
        public string Text { get; set; }
        public int? TwattId { get; set; }
        public bool? IsReply { get; set; }

    }

    public class TwattModel
    {
        public TwattPostModel PostModel;
        public TwattViewModel ViewModel;

        public TwattModel()
        {
            this.PostModel = new TwattPostModel();
            this.ViewModel = new TwattViewModel();
        }

    }
    public class TwattViewModel
    {
        public List<Twatt> Twatts { get; set; }
    }
}