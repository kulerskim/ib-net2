﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdeablogClear.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public String Language { get; set; }

    }
}