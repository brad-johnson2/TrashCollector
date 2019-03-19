using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class Employee
    {

        [Key]

        public int Id { get; set; }

        public string Name { get; set; }
        
        public int EmpZip { get; set; }

    }
}