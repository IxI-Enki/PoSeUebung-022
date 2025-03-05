using Microsoft.EntityFrameworkCore;

      ///   N A M E S P A C E   ///
namespace EventManager.Logic.Contracts;

public interface IContext : IDisposable
{

      DbSet<Entities.Event> EventSet { get; }



      int SaveChanges( );
}