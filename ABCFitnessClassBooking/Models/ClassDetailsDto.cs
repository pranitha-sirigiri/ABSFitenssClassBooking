namespace ABCFitnessClassBooking.Models
{
    public class ClassDetailsDto
    {
        public string Name { get; set; }
        public DateOnly StartDate {  get; set; }
        public DateOnly EndDate { get; set; }
        public TimeOnly Duration { get; set; }
        public int Capacity { get; set; }

        public TimeOnly StartTime { get; set; }
    }
}
