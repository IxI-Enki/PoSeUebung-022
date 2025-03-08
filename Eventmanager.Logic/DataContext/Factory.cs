///   N A M E S P A C E   ///
namespace EventManager.Logic.DataContext;

public static class Factory
{
      public static IContext CreateContext( ) => new EventContext( );

#if DEBUG
      public static void CreateDatabase( )
      {
            var context = new EventContext( );

            context.Database.EnsureDeleted( );
            context.Database.EnsureCreated( );
      }

      public static void InitDatabase( )
      {
            var path = Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly( ).Location )!;
            var context = CreateContext( );
            CreateDatabase( );

            var events = DataLoader.LoadEventsFromCsv( Path.Combine( path , "Data" , "events.csv" ) );
            events.ToList( ).ForEach( e => context.EventSet.Add( e ) );
            context.SaveChanges( );

            var locations = DataLoader.LoadLocationsFromCsv( Path.Combine( path , "Data" , "locations.csv" ) );
            locations.ToList( ).ForEach( l => context.LocationSet.Add( l ) );
            context.SaveChanges( );

            var attendees = DataLoader.LoadAttendeesFromCsv( Path.Combine( path , "Data" , "attendees.csv" ) );
            attendees.ToList( ).ForEach( a => context.AttendeeSet.Add( a ) );
            context.SaveChanges( );
      }
#endif
}