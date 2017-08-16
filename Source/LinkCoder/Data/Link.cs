using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Link
    {
        public Guid Id { get; set; }

        public string OriginalLink { get; set; }

        public DateTime CreateDateTime { get; set; }

        public int Visits { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
