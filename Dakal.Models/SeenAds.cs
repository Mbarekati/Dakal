using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakal.Models
{
    public class SeenAds : Entity
    {
        [ForeignKey("Advertisement")]
        public long AdId { get; set; }

        public Advertisement Advertisement { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }

        public User User { get; set; }

        public bool UserCompletedAction { get; set; }
    }
}
