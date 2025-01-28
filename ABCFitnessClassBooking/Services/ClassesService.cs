using ABCFitnessClassBooking.Interfaces;
using ABCFitnessClassBooking.Models;
using ABCFitnessClassBooking.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ABCFitnessClassBooking.Services
{
    public class ClassesService : IClassesService
    {
        //private readonly DataObject _dataObject;
        private readonly IRepository<ClassDetailsModel> _repository;
        //private readonly IDailyClassBookingService _dailyClassBookingService;
        public ClassesService(IRepository<ClassDetailsModel> repository) 
        {
            //_dataObject = dataObject ?? throw new ArgumentException(nameof(dataObject));

            _repository = repository ?? throw new ArgumentException(nameof(repository));
            //_dailyClassBookingService  = dailyClassBookingService ?? throw new ArgumentNullException(nameof(dailyClassBookingService));
        }
        public Result<ClassDetailsModel> AddClass(ClassDetailsDto classDetailsModel)
        {
            if (classDetailsModel.EndDate < DateOnly.FromDateTime(DateTime.Now)) 
            {
                return Result<ClassDetailsModel>.Failure("Please select a future end date");
            }
            else if(classDetailsModel.StartDate> classDetailsModel.EndDate)
            {
                return Result<ClassDetailsModel>.Failure("Start Date cannot be greater than End Date");
            }
            else if(classDetailsModel.Capacity < 1)
            {
                return Result<ClassDetailsModel>.Failure("Capacity should at leat be 1.");
            }
            var newCreateModel = new ClassDetailsModel
            {
                Name = classDetailsModel.Name,
                StartDate = classDetailsModel.StartDate,
                EndDate = classDetailsModel.EndDate,
                Capacity = classDetailsModel.Capacity,
                StartTime = classDetailsModel.StartTime,
                Duration = classDetailsModel.Duration

            };
            var newClassDetails = _repository.AddDetails(newCreateModel);
            var dailyClasses = new List<DailyClassesDetailsModel>();

            for (DateOnly day = classDetailsModel.StartDate; day <= classDetailsModel.EndDate; day =day.AddDays(1))
            {
                dailyClasses.Add(new DailyClassesDetailsModel
                {
                    Id = Guid.NewGuid(),
                    ClassId = newClassDetails.Id.Value,
                    Date = day,
                    RemainingSlots = classDetailsModel.Capacity
                });
            }
            newClassDetails.DailyClasses = dailyClasses;
            return Result<ClassDetailsModel>.Success(newClassDetails);
            
        }

        public List<ClassDetailsModel> GetClassDetails()
        {
            return _repository.GetAllDetails();
        }

        public ClassDetailsModel GetClassDetailsById(Guid classId)
        {
            return _repository.GetDetails(classId);
           
        }


    }
}
