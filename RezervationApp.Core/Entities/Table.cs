using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationApp.Core.Entities
{
    public class Table
    {
        [Key]
        public int Number { get; set; }
        public int Capacity { get; set; }
    }
}
