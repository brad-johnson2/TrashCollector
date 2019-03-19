using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class Employee
    {

        [Key]

        public int EmployeeId { get; set; }

        public string Name { get; set; }
        
        public int EmpZip { get; set; }



        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}