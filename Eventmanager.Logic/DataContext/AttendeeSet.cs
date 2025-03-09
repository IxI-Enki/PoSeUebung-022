///   N A M E S P A C E   ///
namespace EventManager.Logic.DataContext;

internal sealed class AttendeeSet( DbContext context , DbSet<Attendee> dbSet ) : EntitySet<Attendee>( context , dbSet )
{
      protected override void CopyProperties( Attendee target , Attendee source ) => (target as IAttendee).CopyProperties( source );
}