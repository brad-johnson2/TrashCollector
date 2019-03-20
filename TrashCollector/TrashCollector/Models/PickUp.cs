using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class PickUp
    {

        [Key]

        public int Id { get; set; }

        [Display(Name = "Pick Up Day (i.e. Monday)")]
        public string WeekDay { get; set; }


        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        
    }
}