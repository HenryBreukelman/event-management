using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Models {
	public class AttendeeViewModel {

		[Required(ErrorMessage = "Name is needed")]
		public string AttendeeName { get; set; }

		public int AttendeeAge { get; set; }

		public string AttendeeEmail { get; set; }

	}
}
