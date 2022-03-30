using lab4.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers
{
    public class PortsController : Controller
    {
        private readonly IPortInfoService _portInfoService;

        public PortsController(IPortInfoService portInfoService)
        {
            _portInfoService = portInfoService;
        }

        [HttpGet]
        public IActionResult InfoPorts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetInfoPorts()
        {
            var result = _portInfoService.GetActiveTcpConnections();
            return View(result);
        }

        [HttpGet]
        public IActionResult GetInfoActiveTCPListeners()
        {
            ViewData["Title"] = "Активные прослушиватели TCP";
            ViewData["MiniTitle"] = "Список активных прослушивателей TCP";
            ViewData["ErrorTitle"] = ViewData["MiniTitle"];


            var result = _portInfoService.GetActiveTcpListeners();
            return View("GetInfoActiveListeners", result);
        }

        [HttpGet]
        public IActionResult GetInfoActiveUDPListeners()
        {
            ViewData["Title"] = "Активные прослушиватели UDP";
            ViewData["MiniTitle"] = "Список активных прослушивателей UDP";
            ViewData["ErrorTitle"] = ViewData["MiniTitle"];

            var result = _portInfoService.GetActiveUdpListeners();
            return View("GetInfoActiveListeners", result);
        }
    }
}
