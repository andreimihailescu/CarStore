using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarStore.Models.ViewModel
{
    public class ManagerCarsViewModel
    {
        public Showroom Showroom { get; set; }

        public List<Car> Cars { get; set; }
    }
}