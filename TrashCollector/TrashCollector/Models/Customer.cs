﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class Customer
    {

        [Key]

        public int CustomerId { get; set; }

        public string Name { get; set; }

        public int AccountBalance { get; set; }

        public DateTime SuspendStart { get; set; }

        public DateTime SuspendEnd { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int CustZip { get; set; }


        
        

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }







    }
}