using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class LinkViewModel
    {
        public string OriginalLink { get; set; }

        public Guid UserId { get; set; }
    }
}