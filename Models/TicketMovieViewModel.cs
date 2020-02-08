using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class TicketMovieViewModel
    {
        public List<Ticket> Tickets { get; set; }

        public SelectList Movies { get; set; }
    }
}
