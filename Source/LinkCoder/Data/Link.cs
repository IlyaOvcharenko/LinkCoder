using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Link
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string OriginalLink { get; set; }

        public DateTime CreateDateTime { get; set; }

        public int Visits { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
