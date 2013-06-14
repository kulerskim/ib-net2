using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeablogClear.Models
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        [Required]
        public String Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }

        [Required]
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
}