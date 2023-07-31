using System;
using ReservationApp.Core.Entities;
using ReservationApp.Core.Interface;
using ReservationApp.Core.Repository;
using ReservationApp.WebUI.Controllers;
using Xunit;

namespace ReservationApp.UnitTest
{
    public class ReservationTest
    {

        private readonly IReservationRepository _reservationRepository = null;

        public ReservationTest(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [Fact]
        public void Test1()
        {
            var reservation = new Reservation
            {
                CustomerName = "Sefa Özdemir",
                Email = "isefaozdemir@hotmail.com",
                ReservationDate = Convert.ToDateTime("2023-09-05 00:00:00"),
                NumberOfGuests = 5
            };

            var sonuc = _reservationRepository.ReservationControl(reservation);

            if (sonuc == -1)
            {
                Console.WriteLine("Üzgünüz, uygun masa bulunamadı");
            }
            else
            {
                reservation.TableNumber = Convert.ToInt32(sonuc);
                _reservationRepository.Insert(reservation);

                Console.WriteLine("Rezervasyon başarılı bir şekilde kaydedilmiştir.");
            }
        }
    }
}
