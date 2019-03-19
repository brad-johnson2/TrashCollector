using System;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class Customer
    {

        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        public int AccountBalance { get; set; }

        public DateTime SuspendStart { get; set; }

        public DateTime SuspendEnd { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int CustZip { get; set; }







    }
}