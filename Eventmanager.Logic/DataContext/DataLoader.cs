///   N A M E S P A C E   ///
namespace EventManager.Logic.DataContext;

public static class DataLoader
{
      public static List<Event> LoadEventsFromCsv( string path )
      {
            var res = new List<Event>( );
            //int id = 1;   No need to explicit insert the identifier   ❌
            res.AddRange(
                  File.ReadAllLines( path )
                      .Skip( 1 )
                      .Select( l => l.Split( ';' ) )
                      .Select( e => new Event
                      {
                            //Id = id++ ,  No need to explicit insert the identifier   ❌
                            Title = e[ 0 ] ,
                            Description = e[ 1 ] ,
                            Date = DateTime.Parse( e[ 2 ] ) ,
                            LocationId = int.Parse( e[ 3 ] )
                      } ) );

            return res;
      }

      public static List<Location> LoadLocationsFromCsv( string path )
      {
            var res = new List<Location>( );

            res.AddRange(
                  File.ReadAllLines( path )
                  .Skip( 1 )
                  .Select( l => l.Split( ";" ) )
                  .Select( loc => new Location
                  {
                        Name = loc[ 0 ] ,
                        Address = loc[ 1 ]
                  } ) );

            return res;
      }

      public static List<Attendee> LoadAttendeesFromCsv( string path )
      {
            var res = new List<Attendee>( );

            res.AddRange(
                  File.ReadAllLines( path )
                  .Skip( 1 )
                  .Select( l => l.Split( ';' ) )
                  .Select( a => new Attendee
                  {
                        EventId = int.Parse( a[ 0 ] ),
                        FirstName = a[ 1 ] ,
                        LastName = a[ 2 ] ,
                        Email = a[ 3 ]
                  } ) );

            return res;
      }
}