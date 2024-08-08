
using System.ComponentModel.DataAnnotations;

namespace Final.Models {
	public class EventViewModel {

		[Required(ErrorMessage = "Name is needed")]
		public string EventName { get; set; }

		public string EventDiscription { get; set; }

		[Required(ErrorMessage = "Date is needed")]
		[DataType(DataType.Date)]
		public DateTime EventDate { get; set; }

		[Required(ErrorMessage = "Location is needed")]
		public string EventLocation { get; set; }

		[Required(ErrorMessage = "Ticket Price is needed")]
		public int TicketPrice { get; set; }
	}
}
