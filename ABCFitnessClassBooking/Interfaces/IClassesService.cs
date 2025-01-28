using ABCFitnessClassBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABCFitnessClassBooking.Interfaces
{
    public interface IClassesService
    {
        Result<ClassDetailsModel> AddClass(ClassDetailsDto ClassDetailsModel);
        List<ClassDetailsModel> GetClassDetails();
        ClassDetailsModel GetClassDetailsById(Guid classId);
    }
}
