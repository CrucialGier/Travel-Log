using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    [Table("Places")]
    public class Place
    {
        public Place()
        {
            this.Experiences = new HashSet<Experience>();
        }

        [Key]
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
    }
}
