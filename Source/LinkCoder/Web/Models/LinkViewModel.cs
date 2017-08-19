using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class LinkViewModel
    {
        [Required]
        [Url]
        public string OriginalLink { get; set; }

        public Guid UserId { get; set; }
    }
}