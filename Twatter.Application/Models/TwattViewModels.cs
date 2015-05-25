using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twatter.Models;

namespace Twatter.Application.Models
{
    public class TwattPostModel
    {
        public string Text;
        public int? TwattId;
        public bool? isReply;
    }

    public class TwattModel
    {
        public TwattPostModel PostModel;
        public TwattViewModel ViewModel;

    }
    public class TwattViewModel
    {
        public TwattViewModel(List<Twatt> twatts)
        {
           this.Twatts = twatts; 
        }
        public TwattViewModel()
        {
            this.Twatts = new List<Twatt>();
        }
        public List<Twatt> Twatts;
    }
}