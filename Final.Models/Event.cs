using System;
using System.Collections.Generic;

namespace Final.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public string? EventDiscription { get; set; }

    public DateTime EventDate { get; set; }

    public string EventLocation { get; set; } = null!;

    public decimal? TicketPrice { get; set; }

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
