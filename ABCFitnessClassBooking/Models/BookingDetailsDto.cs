namespace ABCFitnessClassBooking.Models
{
    public class BookingDetailsDto
    {
        public Guid ClassId { get; set; }
        public string MemberName { get; set; }
        public DateOnly ParticipationDate { get; set; }
    }
}
