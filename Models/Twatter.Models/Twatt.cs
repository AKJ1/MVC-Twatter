﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twatter.Models
{
    public class Twatt
    {
        [MaxLength(140)]
        [Required]
        public string Content { get; set; }
        public DateTime TwattDate { get; set; }
        [ForeignKey("Id")]
        public User Poster { get; set; }
        public ICollection<Twatt> Replies { get; set; }
        public ICollection<Twatt> ReTwatts { get; set; }
        public bool IsReply { get; set; }
        public bool IsRetwatt { get; set; }
    }
}