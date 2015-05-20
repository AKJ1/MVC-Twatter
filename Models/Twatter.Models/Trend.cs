using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twatter.Models
{
    public class Trend
    {
        [Key]
        public Guid Id { get; set; }
        public string Phrase { get; set; }
        public ICollection<DateTime> Mentions { get; set; }
        public ICollection<User> MentionedBy { get; set; }
    }
}
