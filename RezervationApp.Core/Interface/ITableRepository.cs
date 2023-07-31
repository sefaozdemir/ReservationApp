using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationApp.Core.Entities;

namespace ReservationApp.Core.Interface
{
    public interface ITableRepository
    {
        IEnumerable<Table> GetAll();
    }
}
