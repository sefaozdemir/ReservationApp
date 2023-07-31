using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationApp.Core.Entities;
using ReservationApp.Core.Interface;

namespace ReservationApp.Core.Repository
{
    public class TableRepository : ITableRepository
    {
        private readonly ReservationContext _context;

        public TableRepository()
        {
            _context = new ReservationContext();
        }

        public IEnumerable<Table> GetAll()
        {
            return _context.Table.ToList();
        }
    }
}
