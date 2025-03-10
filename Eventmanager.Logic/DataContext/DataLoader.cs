using System.Reflection;

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
                        EventId = int.Parse( a[ 0 ] ) ,
                        FirstName = a[ 1 ] ,
                        LastName = a[ 2 ] ,
                        Email = a[ 3 ]
                  } ) );

            return res;
      }

      /// <summary>
      /// Nested class for handling credential loading from a CSV file.
      /// </summary>
      ///
      /// <remarks>
      /// This class uses a singleton pattern to manage credential loading,
      ///   ensuring that only one instance is used for loading credentials across the application.
      /// </remarks>
      public class CredentialLoader
      {

            #region ___C O N S T R U C T O R___ 

            private CredentialLoader( ) => _path = Path.GetDirectoryName( Assembly.GetExecutingAssembly( ).Location )!;

            #endregion


            #region ___F I E L D S___ 

            private static readonly Lazy<CredentialLoader> _instance = new( ( ) => new CredentialLoader( ) );

            private readonly string _path;

            #endregion


            #region ___P R O P E R T Y___ 

            public static CredentialLoader Instance => _instance.Value;

            #endregion


            #region ___P U B L I C   M E T H O D___ 

            /// <summary>
            /// Loads user credentials from a CSV file.
            /// </summary>
            ///
            /// <returns>
            /// The first <see cref="UserCredentials"/> object found in the CSV, or null if no valid entry exists.
            /// </returns>
            ///
            /// <exception cref="FileNotFoundException">
            /// Thrown if the credential file does not exist.
            /// </exception>
            /// <exception cref="IOException">
            /// Thrown if an I/O error occurs while reading the file.
            /// </exception>
            public UserCredentials? LoadCredentials( )
            {
                  var user = new List<UserCredentials>( );

                  user.AddRange(
                                File.ReadAllLines( Path.Combine( _path , "Connections" , "credentials.csv" ) )
                                    .Skip( 1 )
                                    .Select( l => l.Split( ';' ) )
                                    .Select( u => new UserCredentials
                                    {
                                          Username = u[ 0 ] ,
                                          Password = u[ 1 ] ,
                                          Role = u[ 2 ]
                                    } ) );
                  return user.FirstOrDefault( );
            }

            #endregion


            #region E M B E D D E D   C L A S S

            /// <summary>
            /// Represents user credentials with username, password, and role.
            /// </summary>
            public class UserCredentials
            {
                  public string Username { get; set; } = string.Empty;

                  public string Password { get; set; } = string.Empty;

                  public string Role { get; set; } = string.Empty;
            }

            #endregion
      }
}