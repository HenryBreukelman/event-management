using Final.BLL;
using Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers {
	public class AttendeeController : Controller {
		private readonly AttendeeService _attendeeService;
		public AttendeeController(AttendeeService attendeeService) {
			_attendeeService = attendeeService;
		}
		public IActionResult Index() {
			List<Attendee> attendees = _attendeeService.GetAttendees();
			return View(attendees);
		}

		[HttpGet]
		public IActionResult Create() {
			return View();
		}

		[HttpPost]
		public IActionResult Create(AttendeeViewModel attendee) {
			if (ModelState.IsValid) {
				Attendee newAttendee = new Attendee {
					AttendeeName = attendee.AttendeeName,
					AttendeeAge = attendee.AttendeeAge,
					AttendeeEmail = attendee.AttendeeEmail,
				};
				_attendeeService.AddAttendee(newAttendee);
				return RedirectToAction("Index");
			}
			return View(attendee);
		}

		[HttpGet]
		public IActionResult Update(int id) {
			var attendeeToEdit = _attendeeService.GetAttendeeId(id);
			if (attendeeToEdit != null) {
				return View(attendeeToEdit);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Update(Attendee updatedAttendee) {
			if (ModelState.IsValid) {
				_attendeeService.UpdateAttendee(updatedAttendee);
				return RedirectToAction("Index");
			}
			return View(updatedAttendee);
		}

		public IActionResult Delete(int id) {
			var attendee = _attendeeService.GetAttendeeId(id);

			if (attendee != null) {
				return View(attendee);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult ConfirmDelete(int AttendeeId) {
			var attendee = _attendeeService.GetAttendeeId(AttendeeId);

			if (attendee != null) {
				_attendeeService.DeleteAttendee(AttendeeId);
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
	}
}
