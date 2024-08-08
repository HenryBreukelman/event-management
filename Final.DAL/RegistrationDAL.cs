using Final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL {
	public class RegistrationDAL {
		private readonly EventManagementContext _context;

		public RegistrationDAL(EventManagementContext context) {
			_context = context;
		}

		public List<Registration> GetRegistrations() {
			return _context.Registrations.Include(n => n.Event).ToList();
		}

		public void AddRegistration(Registration registration) {
			_context.Registrations.Add(registration);
			_context.SaveChanges();
		}

		public Registration GetRegistrationId(int id) {
			return _context.Registrations.Find(id);
		}

		public void DeleteRegistration(int id) {
			var registration = _context.Registrations.Find(id);
			if (registration != null) {
				_context.Registrations.Remove(registration);
				_context.SaveChanges();
			}
		}
	}
}
