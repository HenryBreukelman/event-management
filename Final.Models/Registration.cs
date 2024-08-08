using System;
using System.Collections.Generic;

namespace Final.Models;

public partial class Registration
{
    public int RegistrationId { get; set; }

    public int EventId { get; set; }

    public int AttendeeId { get; set; }

    public DateOnly RegistrationDate { get; set; }

    public virtual Attendee Attendee { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;
}
