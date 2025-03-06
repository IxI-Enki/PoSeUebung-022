///   N A M E S P A C E   ///
namespace EventManager.Logic.DataContext;

public static class DataLoader
{
      public static List<Event> LoadEventsFromCsv( string path )
      {
            var res = new List<Event>( );
            int id = 1;
            res.AddRange(
                  File.ReadAllLines( path )
                      .Skip( 1 )
                      .Select( l => l.Split( ';' ) )
                      .Select( e => new Event
                      {
                            Id = id++ ,
                            Title = e[ 0 ] ,
                            Description = e[ 1 ] ,
                            Date = DateTime.Parse( e[ 2 ] ) ,
                            LocationId = int.Parse( e[ 3 ] )
                      } ) );
            return res;
      }
}