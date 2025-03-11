///   U S I N G S   ///
global using AppSettings = EventManager.Common.Modules.Configuration.AppSettings;
global using IContext = EventManager.Logic.Contracts.IContext;
global using Factory = EventManager.Logic.DataContext.Factory;
global using EventManager.Logic.Extensions;
global using EventManager.Common.Contracts;

///   N A M E S P A C E   ///
namespace Eventmanager.RESTConApp;

internal class Program
{
      #region ___F I E L D S___ 
      private static string API_BASE_URL = "https://localhost:7074/api/";
      private static AppSettings _appSettings = AppSettings.Instance;
      #endregion

      #region ___C O N S T R U C T O R___       
      static Program( ) => API_BASE_URL = _appSettings[ "Server:BASE_URL" ] ?? API_BASE_URL;
      #endregion

      #region __M A I N   M E T H O D S__
      static void Main( )
      {
            string input = string.Empty;

            while(!input.Equals( "x" , StringComparison.CurrentCultureIgnoreCase ))
            {
                  Console.Clear( );

                  PrintHeader( );

                  PrintMenu( );

                  input = GetUserInput( );

                  if(Int32.TryParse( input , out int choice ))

                        RunChoice( choice );
            }
      }

      private static string GetUserInput( )
      {
            string input;
            Console.Write( "  Your choice          : " );
            input = Console.ReadLine( )!;
            return input;
      }

      private static void PrintHeader( )
            => Console.Write( string.Concat( new string( ' ' , 6 ) ,
                                            "Event Manager".ForegroundColor( "40,122,77" )
#if DEBUG
                                            , " - ".Colored( "debug" )
                                            , "debug".ColorXonY( "black" , "240,120,40" )
#endif
                                            ) );

      private static int PrintMenu( )
      {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write( $"\n{new string( '═' , Console.WindowWidth ).ForegroundColor( "40,122,77" )}" );
            string
                  debug = "240,120,40",
                  grey = "40,40,40",
                  white = "255,255,255",
                  eC = "4,12,24",
                  lC = "4,22,14",
                  aC = "24,12,4";
            int idx = 1;
#if DEBUG
            Console.Write( "\n  " + $"{nameof( InitDatabase ),-20}....0".ColorXonY( "black" , debug ) );
            Console.Write( $"\n {new string( '┄' , Console.WindowWidth - 2 ),-25}".ForegroundColor( "60,30,30" ) );
#endif
            Console.Write(
                  string.Concat(
                        "\n  " , $"{nameof( PrintEvents /*   */),-20}....{idx++}".ColorXonY( white , eC ) ,
                        "\n  " , $"{nameof( QueryEvents /*   */),-20}....{idx++}".ColorXonY( white , eC ) ,
                        "\n  " , $"{nameof( AddEvent /*      */),-20}....{idx++}".ColorXonY( white , eC ) ,
                        "\n  " , $"{nameof( DeleteEvent /*   */),-20}....{idx++}".ColorXonY( white , eC ) ,
                          $"\n {new string( '┄' , Console.WindowWidth - 2 ),-25}".ForegroundColor( grey ) ,
                        "\n  " , $"{nameof( PrintLocations /**/),-20}....{idx++}".ColorXonY( white , lC ) ,
                        "\n  " , $"{nameof( QueryLocations /**/),-20}....{idx++}".ColorXonY( white , lC ) ,
                        "\n  " , $"{nameof( AddLocation /*   */),-20}....{idx++}".ColorXonY( white , lC ) ,
                        "\n  " , $"{nameof( DeleteLocation /**/),-20}....{idx++}".ColorXonY( white , lC ) ,
                          $"\n {new string( '┄' , Console.WindowWidth - 2 ),-25}".ForegroundColor( grey ) ,
                        "\n  " , $"{nameof( PrintAttendees /**/),-20}....{idx++}".ColorXonY( white , aC ) ,
                        "\n  " , $"{nameof( QueryAttendees /* */),-20}...{idx++}".ColorXonY( white , aC ) ,
                        "\n  " , $"{nameof( AddAttendee /*    */),-20}...{idx++}".ColorXonY( white , aC ) ,
                        "\n  " , $"{nameof( DeleteAttendee /* */),-20}...{idx++}".ColorXonY( white , aC ) ,
                          $"\n {new string( '┄' , Console.WindowWidth - 2 ),-25}".ForegroundColor( grey ) ,
#if DEBUG
                        "\n  " , $"{nameof( OverrideDatabase ),-20}...{idx++}".ColorXonY( "black" , debug ) ,
                          $"\n {new string( '┄' , Console.WindowWidth - 2 ),-25}".ForegroundColor( "60,30,30" ) ,
#endif
                        string.Concat( "\n  Exit" , new string( '.' , 20 ) , "x\n" )
                        )
                  );
            return idx;
      }

      private static void RunChoice( int choice )
      {
            switch(choice)
            {
                  // Initiate
                  case 0:
#if DEBUG

                        InitDatabase( );
                        Console.Write( "\nContinue with Enter..." );
                        Console.ReadLine( );
#endif
                        break;
                  // Events
                  case 1:
                        PrintEvents( );
                        Console.Write( "\nContinue with Enter..." );
                        Console.ReadLine( );
                        break;
                  case 2:
                        QueryEvents( );
                        Console.Write( "\nContinue with Enter..." );
                        Console.ReadLine( );
                        break;
                  case 3:
                        AddEvent( );
                        break;
                  case 4:
                        DeleteEvent( );
                        break;
                  // Locations
                  case 5:
                        PrintLocations( );
                        Console.Write( "\nContinue with Enter..." );
                        Console.ReadLine( );
                        break;
                  case 6:
                        QueryLocations( );
                        Console.Write( "\nContinue with Enter..." );
                        Console.ReadLine( );
                        break;
                  case 7:
                        AddLocation( );
                        break;
                  case 8:
                        DeleteLocation( );
                        break;
                  // Attendees
                  case 9:
                        PrintAttendees( );
                        Console.Write( "\nContinue with Enter..." );
                        Console.ReadLine( );
                        break;
                  case 10:
                        QueryAttendees( );
                        Console.Write( "\nContinue with Enter..." );
                        Console.ReadLine( );
                        break;
                  case 11:
                        AddAttendee( );
                        break;
                  case 12:
                        DeleteAttendee( );
                        break;

                  case 13:
#if DEBUG

                        OverrideDatabase( );
                        Console.Write( "\nContinue with Enter..." );
                        Console.ReadLine( );
#endif
                        break;
                  case 14:
                        break;
                  case 15:
                        break;
                  case 16:
                        break;
                  default:
                        break;
            }
      }

      private static void PrintEvents( )
      {
            Console.Write( "\nAll Events\n" );


            foreach(var e in c.EventSet
                             .QuerySet.AsNoTracking( ))

                  Console.Write( $"\n{e}\n" );
      }

      private static void QueryEvents( )
      {
            throw new NotImplementedException( );
      }

      private static void AddEvent( )
      {
            throw new NotImplementedException( );
      }

      private static void DeleteEvent( )
      {
            throw new NotImplementedException( );
      }

      private static void PrintLocations( )
      {
            throw new NotImplementedException( );
      }

      private static void QueryLocations( )
      {
            throw new NotImplementedException( );
      }

      private static void AddLocation( )
      {
            throw new NotImplementedException( );
      }

      private static void DeleteLocation( )
      {
            throw new NotImplementedException( );
      }

      private static void PrintAttendees( )
      {
            throw new NotImplementedException( );
      }

      private static void QueryAttendees( )
      {
            throw new NotImplementedException( );
      }

      private static void AddAttendee( )
      {
            throw new NotImplementedException( );
      }

      private static void DeleteAttendee( )
      {
            throw new NotImplementedException( );
      }

      private static void OverrideDatabase( )
      {
            throw new NotImplementedException( );
      }

#if DEBUG
      static void InitDatabase( ) => Factory.InitDatabase( );
      private static void OverrideDatabase( IContext c ) => Console.Write( "\nCsv-Database Overridden - doesnt't work right now!\n" );
#endif
      #endregion

}