using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class PickUp
    {

        [Key]

        public int Id { get; set; }

        public string WeekDay { get; set; }

        

    }
}