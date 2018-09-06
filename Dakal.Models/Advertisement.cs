using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dakal.Models
{
    public class Advertisement : Entity
    {
        public string FilePath { get; set; }
        [ForeignKey("Firm")]
        public uint OwnerId { get; set; }
        public AdType AdType { get; set; }
    }
}
