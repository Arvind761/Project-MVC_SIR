using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullMVC_crud.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Mobile { get; set; }
        public int Age { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public int City { get; set; }

    }
}