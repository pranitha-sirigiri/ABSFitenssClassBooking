using ABCFitnessClassBooking.Interfaces;
using ABCFitnessClassBooking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABCFitnessClassBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassBookingController : ControllerBase
    {
        private readonly IClassesService _classesService;
        private readonly IClassBookingService _classBookingService;
        public ClassBookingController(IClassesService classesService, IClassBookingService classBookingService) 
        {
            _classesService = classesService ?? throw new ArgumentNullException(nameof(classesService));
            _classBookingService = classBookingService ?? throw new ArgumentNullException(nameof(classBookingService));
        }
        [HttpPost("Class")]
        public IActionResult AddClass([FromBody] ClassDetailsDto classDetails)
        {
            ;
            return Ok(_classesService.AddClass(classDetails));
        }

        [HttpGet("Details")]
        public IActionResult GetAllClassesDetails()
        {
            return Ok(_classesService.GetClassDetails());
        }

        [HttpPost("Booking")]
        public IActionResult CreateBooking([FromBody] BookingDetailsDto model)
        {
            return Ok(_classBookingService.Create(model));
        }


        [HttpGet("Bookings")]
        public IActionResult GetBookings([FromQuery] string? memberName, [FromQuery] DateOnly? startDate , [FromQuery] DateOnly? endDate) 
        {
            return Ok(_classBookingService.Search(memberName, startDate, endDate));
        }

    }
}
