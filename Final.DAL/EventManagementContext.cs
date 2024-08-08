using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Final.Models;

public partial class EventManagementContext : DbContext
{
    public EventManagementContext()
    {
    }

    public EventManagementContext(DbContextOptions<EventManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendee> Attendees { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HENRYBREUKELMAN\\SQLEXPRESS;Database=EventManagement;Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendee>(entity =>
        {
            entity.Property(e => e.AttendeeId).HasColumnName("AttendeeID");
            entity.Property(e => e.AttendeeEmail).HasMaxLength(100);
            entity.Property(e => e.AttendeeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.EventDiscription).HasColumnType("text");
            entity.Property(e => e.EventLocation).HasMaxLength(50);
            entity.Property(e => e.EventName).HasMaxLength(50);
            entity.Property(e => e.TicketPrice).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.Property(e => e.RegistrationId).HasColumnName("RegistrationID");
            entity.Property(e => e.AttendeeId).HasColumnName("AttendeeID");
            entity.Property(e => e.EventId).HasColumnName("EventID");

            entity.HasOne(d => d.Attendee).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.AttendeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Registrations_Attendees");

            entity.HasOne(d => d.Event).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Registrations_Events");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
