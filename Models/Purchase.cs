using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int TicketId { get; set; }

        public int Payment { get; set; }
    }
}
