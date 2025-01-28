using ABCFitnessClassBooking.Interfaces;
using ABCFitnessClassBooking.Models;
using ABCFitnessClassBooking.Repository;

namespace ABCFitnessClassBooking.Services
{
    public class ClassBookingService : IClassBookingService
    {
        private readonly IRepository<BookingDetailsModel> _repository;
        private readonly IClassesService _classesService;
        public ClassBookingService(IRepository<BookingDetailsModel> repository, IClassesService classesService) 
        { 
            _repository = repository?? throw new ArgumentNullException(nameof(repository));
            _classesService = classesService ?? throw new ArgumentNullException(nameof(classesService));
        }
        public Result<BookingDetailsModel> Create(BookingDetailsDto model)
        {
            var classDetails = _classesService.GetClassDetailsById(model.ClassId);
            var dailyClass = classDetails?.DailyClasses.FirstOrDefault(c => c.Date == model.ParticipationDate);
            if (dailyClass == null )
            {
                return Result<BookingDetailsModel>.Failure("No class exists");
            }
            else if (dailyClass.RemainingSlots == 0)
            {
                return Result<BookingDetailsModel>.Failure("Class is full");
            }

            var bookingDetails =_repository.AddDetails(new BookingDetailsModel
            {
                Id = Guid.NewGuid(),
                ClassId = dailyClass.ClassId,
                ClassName = classDetails.Name,
                MemberName = model.MemberName,
                BookingDate = model.ParticipationDate,
                DailyClassId = dailyClass.Id,
                ClassStartTime = classDetails.StartTime

            });
            dailyClass.RemainingSlots--;

            return Result<BookingDetailsModel>.Success(bookingDetails);
        }


        public List<BookingDetailsModel> Search(string? memberName, DateOnly? startDate, DateOnly? endDate)
        {
            return _repository.GetAllDetails().Where(b => (string.IsNullOrEmpty(memberName) || b.MemberName == memberName) &&
                    (!startDate.HasValue || b.BookingDate >= startDate.Value) &&
                    (!endDate.HasValue || b.BookingDate <= endDate.Value)).ToList();

        }
    }
}
