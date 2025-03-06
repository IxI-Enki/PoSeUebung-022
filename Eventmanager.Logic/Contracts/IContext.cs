///   N A M E S P A C E   ///
namespace EventManager.Logic.Contracts;

public interface IContext : IDisposable
{
      DbSet<Entities.Event> EventSet { get; }
      DbSet<Entities.Location> LocationSet { get; }
      DbSet<Entities.Attendee> AttendeeSet { get; }

      int SaveChanges( );
}