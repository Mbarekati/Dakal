using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dakal.Models
{
    public class Firm : Entity
    {
        [StringLength(450)]
        [Index(IsUnique = true)]
        //used when the firm is 
        public string PackageName { get; set; }
        public string ApiAddress { get; set; }
        public string Name { get; set; }

    }
}
