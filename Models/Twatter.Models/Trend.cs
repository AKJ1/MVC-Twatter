using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twatter.Models
{
    class Trend
    {
        public string Phrase { get; set; }
        public ICollection<DateTime> Mentions { get; set; }
        public ICollection<User> MentionedBy { get; set; }
    }
}
