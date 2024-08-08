using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL {
	public class AttendeeDAL {
		private readonly EventManagementContext _context;

		public AttendeeDAL(EventManagementContext context) {
			_context = context;
		}

		public List<Attendee> GetAttendees() {
			return _context.Attendees.ToList();
		}

		public void AddAttendee(Attendee attendee) {
			_context.Attendees.Add(attendee);
			_context.SaveChanges();
		}

		public Attendee GetAttendeeId(int id) {
			return _context.Attendees.Find(id);
		}

		public void UpdateAttendee(Attendee updatedAttendee) {
			_context.Attendees.Update(updatedAttendee);
			_context.SaveChanges();
		}

		public void DeleteAttendee(int id) {
			var attendee = _context.Attendees.Find(id);
			if (attendee != null) {
				_context.Attendees.Remove(attendee);
				_context.SaveChanges();
			}
		}
	}
}
