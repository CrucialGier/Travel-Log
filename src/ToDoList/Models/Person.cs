using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    [Table("Persons")]
    public class Person
    {
        public Person()
        {
            this.Experiences = new HashSet<Experience>();
        }

        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
    }
}
