using Final.BLL;
using Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Final.Controllers {
	public class EventController : Controller {
		private readonly EventService _eventService;
		public EventController(EventService eventService) {
			_eventService = eventService;
		}
		public IActionResult Index() {
			List<Event> events = _eventService.GetEvents();
			return View(events);
		}

		[HttpGet]
		public IActionResult Create() {
			return View();
		}

		[HttpPost]
		public IActionResult Create(EventViewModel createEvent) {
			if (ModelState.IsValid) {
				Event newEvent = new Event {
					EventName = createEvent.EventName,
					EventDiscription = createEvent.EventDiscription,
					EventDate = createEvent.EventDate,
					EventLocation = createEvent.EventLocation,
					TicketPrice = createEvent.TicketPrice
				};
				_eventService.AddEvent(newEvent);
				return RedirectToAction("Index");
			}
			return View(createEvent);
		}

		[HttpGet]
		public IActionResult Update(int id) {
			var eventToEdit = _eventService.GetEventId(id);
			if (eventToEdit != null) {
				return View(eventToEdit);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Update(Event updatedEvent) {
			if (ModelState.IsValid) {
				_eventService.UpdateEvent(updatedEvent);
				return RedirectToAction("Index");
			}
			return View(updatedEvent);
		}

		[HttpGet]
		public IActionResult Delete(int id) {
			var oldEvent = _eventService.GetEventId(id);

			if (oldEvent != null) {
				return View(oldEvent);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult ConfirmDelete(int EventId) {
			_eventService.DeleteEvent(EventId);
			return RedirectToAction("Index");
		}
	}
}
