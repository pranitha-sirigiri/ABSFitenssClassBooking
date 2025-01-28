using System.Text.Json.Serialization;

namespace ABCFitnessClassBooking.Models
{
    public class BookingDetailsModel : IModel
    {
        [JsonIgnore]
        public Guid? Id { get; set; }
        [JsonIgnore]
        public Guid ClassId { get; set; }
        public string ClassName { get; set; } = string.Empty;

        public string MemberName { get; set; }

        public DateOnly BookingDate { get; set; }

        [JsonIgnore]
        public Guid? DailyClassId { get; set; }
        public TimeOnly ClassStartTime { get; set; }

    }
}
