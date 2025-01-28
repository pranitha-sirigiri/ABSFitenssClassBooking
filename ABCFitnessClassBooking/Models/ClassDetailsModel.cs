using System.ComponentModel.DataAnnotations;

namespace ABCFitnessClassBooking.Models
{
    public class ClassDetailsModel : IModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public TimeOnly StartTime {  get; set; }
        public TimeOnly Duration { get; set; }
        public int Capacity { get; set; }
        public List<DailyClassesDetailsModel> DailyClasses { get; set; }

    }
}
