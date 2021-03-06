﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarStore.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Serial number")]
        public string SerialNumber { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }

        public CarType CarType { get; set; }

        [Display(Name = "Car type")]
        public byte? CarTypeId { get; set; }

        public Showroom Showroom { get; set; }

        [Display(Name = "Showroom")]
        public int? ShowroomId { get; set; }
    }
}