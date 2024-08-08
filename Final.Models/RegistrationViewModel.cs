
using System.ComponentModel.DataAnnotations;

namespace Final.Models {
	public class RegistrationViewModel {

		[Required(ErrorMessage = "Event ID is needed")]
		public int EventId { get; set; }

		[Required(ErrorMessage = "Attendee ID is needed")]
		public int AttendeeId { get; set; }

		public List<Event> Events { get; set; } = new List<Event>();
		public List<Attendee> Attendees { get; set; } = new List<Attendee>();
	}
}
