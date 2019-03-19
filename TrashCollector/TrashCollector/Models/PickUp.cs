using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class PickUp
    {

        [Key]

        public int Id { get; set; }

        public string WeekDay { get; set; }


        [ForeignKey("CustomerId")]

        public int CustomerId { get; set; }
    }
}