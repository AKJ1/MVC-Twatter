using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twatter.Models
{
    public class Twatt
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(140)]
        [Required]
        public string Content { get; set; }
        public DateTime TwattDate { get; set; }
        
        
        public string PosterId { get; set; }

        [Required]
        [ForeignKey("PosterId")]
        public User Poster { get; set; }
        public virtual Twatt Reply { get; set; }
        public virtual Twatt ReTwatt { get; set; }
        [InverseProperty("Reply")]
        public virtual ICollection<Twatt> Replies { get; set; }
        [InverseProperty("ReTwatt")]
        public virtual ICollection<Twatt> ReTwatts { get; set; }
        public bool IsReply { get; set; }
        [ForeignKey("ReplyToId")]
        public Twatt ReplyTo { get; set; }
        public int? ReplyToId { get; set; }
        public bool IsRetwatt { get; set; }
    }
}