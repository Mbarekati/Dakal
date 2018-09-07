using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakal.Models
{
    public class User : Entity
    {
        internal User() { }
        public User(string username, string appPackageName, uint age, Gender gender, long firmId)
        {
            Username = username;
            FirmPackageName = appPackageName;
            Age = age;
            Gender = gender;
            FirmId = firmId;
        }

        public string Username { get; set; }

        public Firm Firm { get; set; }

        [ForeignKey("Firm")]
        public long FirmId { get; set; }

        public string FirmPackageName { get; set; }

        public uint Age
        {
            get; set;
        }

        public Gender Gender { get; set; }

    }
}
