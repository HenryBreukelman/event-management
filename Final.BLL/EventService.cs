using Final.DAL;
using Final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BLL {
	public class EventService {
		private EventDAL _newEventDAL;

		public EventService(EventDAL newEventDAL) {
			_newEventDAL = newEventDAL;
		}

		public List<Event> GetEvents() {
			return _newEventDAL.GetEvents();
		}

		public void AddEvent(Event newEvent) {
			_newEventDAL.AddEvent(newEvent);
		}

		public Event GetEventId(int id) {
			return _newEventDAL.GetEventId(id);
		}

		public void UpdateEvent(Event updatedEvent) {
			_newEventDAL.UpdateEvent(updatedEvent);
		}

		public void DeleteEvent(int id) {
			_newEventDAL.DeleteEvent(id);
		}
	}
}
