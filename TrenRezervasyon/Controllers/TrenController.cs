using Microsoft.AspNetCore.Mvc;
using TrenRezervasyon.Model.ViewModel;
using TrenRezervasyon.Services;

namespace TrenRezervasyon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrenController : Controller
    {
        private readonly IRezervasyonService _rezervasyonService;

        public TrenController(IRezervasyonService rezervasyonService)
        {
            _rezervasyonService = rezervasyonService;
        }
        [HttpPost]
        public IActionResult Rezervasyon(RequestVM request)
        {
            var response = _rezervasyonService.Rezervasyon(request);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
    }
}
