namespace ABCFitnessClassBooking.Models
{
    public class DailyClassesDetailsModel : IModel
    {
        public Guid? Id { get; set; }
        public Guid ClassId {get; set;}
        public DateOnly Date {  get; set;}
        public int RemainingSlots { get; set;}


    }
}
