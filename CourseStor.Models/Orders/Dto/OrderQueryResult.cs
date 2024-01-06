using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Orders.Dto
{
    public class OrderQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CreateOrder { get; set; }
    }
}
