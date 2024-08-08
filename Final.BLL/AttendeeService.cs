using Final.DAL;
using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BLL {
	public class AttendeeService {
		private AttendeeDAL _attendeeDAL;

		public AttendeeService(AttendeeDAL attendeeDAL) {
			_attendeeDAL = attendeeDAL;
		}

		public List<Attendee> GetAttendees() {
			return _attendeeDAL.GetAttendees();
		}

		public void AddAttendee(Attendee attendee) {
			_attendeeDAL.AddAttendee(attendee);
		}

		public Attendee GetAttendeeId(int id) {
			return _attendeeDAL.GetAttendeeId(id);
		}

		public void UpdateAttendee(Attendee updatedAttendee) {
			_attendeeDAL.UpdateAttendee(updatedAttendee);
		}
		public void DeleteAttendee(int id) {
			_attendeeDAL.DeleteAttendee(id);
		}
	}
}
