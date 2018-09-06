using System.ComponentModel.DataAnnotations;


namespace Dakal.Models
{
    public abstract class Entity
    {
        [Key]
        public uint Id { get; set; }
    }
}
