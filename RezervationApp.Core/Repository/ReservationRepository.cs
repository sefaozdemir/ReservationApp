using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationApp.Core.Entities;
using ReservationApp.Core.Interface;

namespace ReservationApp.Core.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationContext _context;
        private readonly ITableRepository _tableRepository = null;

        public ReservationRepository(ITableRepository tableRepository)
        {
            _context = new ReservationContext();
            _tableRepository = tableRepository;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservation.ToList();
        }

        public void Insert(Reservation reservation)
        {
            _context.Reservation.Add(reservation);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public decimal ReservationControl(Reservation reservation)
        {
            var guestNumber = reservation.NumberOfGuests;
            var kullanilabilecekMasalar = _tableRepository.GetAll().Where(x => x.Capacity >= guestNumber).ToList();
            var rezervasyonluMasalar = GetAll().Where(x => x.ReservationDate == reservation.ReservationDate).ToList();

            foreach (var row in kullanilabilecekMasalar)
            {
                if (rezervasyonluMasalar.Where(x => x.TableNumber == row.Number).Count() == 0)
                {
                    return row.Number;
                }
            }

            return -1;
        }
    }
}
