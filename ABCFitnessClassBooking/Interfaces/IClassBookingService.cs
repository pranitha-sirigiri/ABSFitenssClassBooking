using ABCFitnessClassBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABCFitnessClassBooking.Interfaces
{
    public interface IClassBookingService
    {
        Result<BookingDetailsModel> Create(BookingDetailsDto model);
        List<BookingDetailsModel> Search(string? memberName, DateOnly? startDate, DateOnly? endDate);
    }
}
