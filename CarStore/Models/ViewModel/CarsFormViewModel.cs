using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarStore.Models.ViewModel
{
    public class CarsFormViewModel
    {
        public Car Car { get; set; }
        public List<CarType> CarType { get; set; }
    }
}