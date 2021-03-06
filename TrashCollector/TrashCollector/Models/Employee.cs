﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class Employee
    {

        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Zip Code Area")]
        public int EmpZip { get; set; }



        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}