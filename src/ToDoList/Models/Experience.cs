using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    [Table("Experiences")]
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        public string Description { get; set; }
        [ForeignKey("FK_Experiences_Places")]
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }
        [ForeignKey("FK_Items_Places")]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
