using Final.BLL;
using Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers {
	public class RegistrationController : Controller {
		private readonly RegistrationService _registrationService;
		private readonly EventService _eventService;
		private readonly AttendeeService _attendeeService;
		public RegistrationController(
			RegistrationService registrationService, EventService eventService, AttendeeService attendeeService
			) {
			_registrationService = registrationService;
			_eventService = eventService;
			_attendeeService = attendeeService;
		}
		public IActionResult Index() {
			List<Registration> registrations = _registrationService.GetRegistrations();
			return View(registrations);
		}

		[HttpGet]
		public IActionResult Create() {
			var events = _eventService.GetEvents() ?? new List<Event>();
			var attendees = _attendeeService.GetAttendees() ?? new List<Attendee>();
			var combineView = new RegistrationViewModel {
				Events = events,
				Attendees = attendees
			};
			return View(combineView);
		}

		[HttpPost]
		public IActionResult Create(RegistrationViewModel registration) {
			if (ModelState.IsValid) {
				Registration newRegistration = new Registration {
					EventId = registration.EventId,
					AttendeeId = registration.AttendeeId,
					RegistrationDate = DateOnly.FromDateTime(DateTime.Now)
				};
				_registrationService.AddRegistration(newRegistration);
				return RedirectToAction("Index");
			}
			return View(registration);
		}

		public IActionResult Delete(int id) {
			var registration = _registrationService.GetRegistrationId(id);

			if (registration != null) {
				return View(registration);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult ConfirmDelete(int RegistrationId) {
			var registration = _registrationService.GetRegistrationId(RegistrationId);

			if (registration != null) {
				_registrationService.DeleteRegistration(RegistrationId);
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
	}
}