using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class Customers
    {

        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

       

    }
}