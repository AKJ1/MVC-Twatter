using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twatter.Models
{
    public class Twatt
    {
        public Twatt()
        {
            this.TwattDate = new DateTime();
            this.TwattDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(140)]
        [Required]
        public string Content { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime TwattDate { get; set; }
        public virtual ICollection<Twatt> Replies { get; set; }
        public virtual ICollection<Twatt> ReTwatts { get; set; }
        public bool IsReply { get; set; }
        public virtual Twatt ReplyTo { get; set; }
        [Required]
        public virtual User Poster { get; set; }
        public bool IsRetwatt { get; set; }
    }
}