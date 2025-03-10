
///   N A M E S P A C E   ///
namespace EventManager.Logic.Contracts;

public interface IContext : IDisposable
{
      EntitySet<Entities.Event> EventSet { get; }
      EntitySet<Entities.Location> LocationSet { get; }
      EntitySet<Entities.Attendee> AttendeeSet { get; }

      DbSet<Event> DbSetEvent { get; set; }
      DbSet<Location> DbSetLocation { get; set; }
      DbSet<Attendee> DbSetAttendee { get; set; }

      int SaveChanges( );
}