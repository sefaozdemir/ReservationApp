using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RezervationApp.Core.Entities;

namespace RezervationApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Reservation Form { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Form = new Reservation
            {
                CustomerName = "sefa",
                Id = 1,
                ReservationDate = Convert.ToDateTime("12.05.2023"),
                TableNumber = 1,
                NumberOfGuests = 5
            };
        }

        public IActionResult OnPost(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //var a = Form;

            return Page();
        }
    
    }
}
