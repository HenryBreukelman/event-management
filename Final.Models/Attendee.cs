using System;
using System.Collections.Generic;

namespace Final.Models;

public partial class Attendee
{
    public int AttendeeId { get; set; }

    public string AttendeeName { get; set; } = null!;

    public int? AttendeeAge { get; set; }

    public string? AttendeeEmail { get; set; }

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
