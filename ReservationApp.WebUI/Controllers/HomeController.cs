using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReservationApp.WebUI.Models;
using ReservationApp.Core.Entities;
using ReservationApp.Core.Repository;
using ReservationApp.Core.Interface;
using ReservationApp.Core;

namespace ReservationApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReservationRepository _reservationRepository = null;
        private readonly ITableRepository _tableRepository = null;
        private readonly CommonAction _commonAction = null;

        public HomeController(ILogger<HomeController> logger, IReservationRepository reservationRepository, ITableRepository tableRepository)
        {
            _logger = logger;
            _reservationRepository = reservationRepository;
            _tableRepository = tableRepository;
            _commonAction = new CommonAction();
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SuccessInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeReservation(Reservation reservation)
        {
            var sonuc = _reservationRepository.ReservationControl(reservation);

            if (sonuc == -1)
            {
                ViewData["UyarıMesaji"] = "Üzgünüz, uygun masa bulunamadı";
                return View("Error");
            }
            else
            {
                reservation.TableNumber = Convert.ToInt32(sonuc);
                _reservationRepository.Insert(reservation);
                //mail çağrısı
                var mailIcerik = "Sayın " + reservation.CustomerName + ", " + reservation.ReservationDate + " tarihinde " + 
                    reservation.TableNumber + " nolu masa için " + reservation.NumberOfGuests + " kişilik rezervasyonunuz yapılmıştır.";
                _commonAction.SendMail("Masa Rezervasyonu hk.", mailIcerik, reservation.Email);

                ViewData["BilgiMesaji"] = mailIcerik;

                return View("SuccessInfo");
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
