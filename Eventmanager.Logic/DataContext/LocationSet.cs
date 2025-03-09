///   N A M E S P A C E   ///
namespace EventManager.Logic.DataContext;

internal sealed class LocationSet( DbContext context , DbSet<Location> dbSet ) : EntitySet<Location>( context , dbSet )
{
      protected override void CopyProperties( Location target , Location source ) => (target as ILocation).CopyProperties( source );
}