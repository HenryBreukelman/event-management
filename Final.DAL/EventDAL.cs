using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL {
	public class EventDAL {
		private readonly EventManagementContext _context;

		public EventDAL(EventManagementContext context) {
			_context = context;
		}

		public List<Event> GetEvents() {
			return _context.Events.ToList();
		}

		public void AddEvent(Event newEvent) {
			_context.Events.Add(newEvent);
			_context.SaveChanges();
		}

		public Event GetEventId(int id) {
			return _context.Events.Find(id);
		}

		public void UpdateEvent(Event updatedEvent) {
			_context.Events.Update(updatedEvent);
			_context.SaveChanges();
		}

		public void DeleteEvent(int id) {
			var oldEvent = _context.Events.Find(id);
			if (oldEvent != null) {
				_context.Events.Remove(oldEvent);
				_context.SaveChanges();
			}
		}
	}
}
