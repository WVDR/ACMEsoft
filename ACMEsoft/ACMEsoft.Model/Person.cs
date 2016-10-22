using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEsoft.Model
{

    [Table("Person")]
    public class Person : AuditableEntity<long>
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }

        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }       
    }
}
