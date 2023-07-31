using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationApp.Core.Entities;

namespace ReservationApp.Core.Interface
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();

        void Insert(Reservation reservation);
        void Save();

        decimal ReservationControl(Reservation reservation);
    }
}
