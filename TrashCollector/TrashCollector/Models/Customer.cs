﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class Customer
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Balance Due")]
        public int AccountBalance { get; set; }


        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime SuspendStart { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime SuspendEnd { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public int CustZip { get; set; }





        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }







    }
}