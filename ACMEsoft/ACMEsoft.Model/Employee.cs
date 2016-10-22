using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEsoft.Model
{
    public class Employee : AuditableEntity<long>
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        public int PersonID { get; set; }

        [Required]
        [MaxLength(128)]
        public string EmployeeNumber { get; set; }        

        [Required]
        public DateTime EmployeeDate { get; set; }
                
        public DateTime TerminatedDate { get; set; }        

        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }
    }
}
