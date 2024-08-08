using Final.DAL;
using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BLL {
	public class RegistrationService {
		private RegistrationDAL _registrationDAL;

		public RegistrationService(RegistrationDAL registrationDAL) {
			_registrationDAL = registrationDAL;
		}

		public List<Registration> GetRegistrations() {
			return _registrationDAL.GetRegistrations();
		}

		public void AddRegistration(Registration registration) {
			_registrationDAL.AddRegistration(registration);
		}

		public Registration GetRegistrationId(int id) {
			return _registrationDAL.GetRegistrationId(id);
		}
		public void DeleteRegistration(int id) {
			_registrationDAL.DeleteRegistration(id);
		}
	}
}
