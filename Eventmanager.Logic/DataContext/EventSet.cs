///   N A M E S P A C E   /// 
namespace EventManager.Logic.DataContext;

internal sealed class EventSet( DbContext context , DbSet<Event> dbSet ) : EntitySet<Event>( context , dbSet )
{
      protected override void CopyProperties( Event target , Event source ) => (target as IEvent).CopyProperties( source );
}