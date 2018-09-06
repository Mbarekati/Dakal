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
        [Index("IX_UniqeUserContraint", 1, IsUnique = true)]
        public string Username { get; set; }
        public Firm Firm { get; set; }

        [Index("IX_UniqeUserContraint", 2, IsUnique = true)]
        [ForeignKey("Firm")]
        public string FirmPackageName { get; set; }
        public uint Age
        {
            get; set;
            //get
            //{
            //    return Age;
            //}
            //set
            //{
            //    if (value > 130 || value < 10)
            //        throw new ArgumentException("User Age must be between 10-130");
            //    else
            //        Age = value;
            //}
        }

        public Gender Gender { get; set; }
    }
}
