///   U S I N G S   ///
global using AppSettings = EventManager.Common.Modules.Configuration.AppSettings;
global using IContext = EventManager.Logic.Contracts.IContext;
global using Factory = EventManager.Logic.DataContext.Factory;
global using Microsoft.EntityFrameworkCore;
global using System.Linq.Dynamic.Core;
global using EventManager.Logic.Extensions;

///   N A M E S P A C E   ///
namespace Eventmanager.ConApp;

internal class Program
{
      #region __F I E L D S__
      private static AppSettings _appSettings = AppSettings.Instance;
      #endregion

      #region __M A I N   M E T H O D S__
      static void Main( )
      {
            string input = string.Empty;

            using IContext context = Factory.CreateContext( );

            while(!input.Equals( "x" , StringComparison.CurrentCultureIgnoreCase ))
            {
                  Console.Clear( );

                  PrintHeader( );

                  PrintMenu( );

                  input = GetUserInput( );

                  if(Int32.TryParse( input , out int choice ))

                        RunChoice( context , choice );
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

      private static void RunChoice( IContext context , int choice )
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
                        PrintEvents( context );
                        Console.Write( "\nContinue with Enter..." );
                        Console.ReadLine( );
                        break;
                  case 2:
                        QueryEvents( context );
                        Console.Write( "\nContinue with Enter..." );
                        Console.ReadLine( );
                        break;
                  case 3:
                        AddEvent( context );
                        break;
                  case 4:
                        DeleteEvent( context );
                        break;
                  // Locations
                  case 5:
                        PrintLocations( context );
                        Console.Write( "\nContinue with Enter..." );
                        Console.ReadLine( );
                        break;
                  case 6:
                        QueryLocations( context );
                        Console.Write( "\nContinue with Enter..." );
                        Console.ReadLine( );
                        break;
                  case 7:
                        AddLocation( context );
                        break;
                  case 8:
                        DeleteLocation( context );
                        break;
                  // Attendees
                  case 9:
                        PrintAttendees( context );
                        Console.Write( "\nContinue with Enter..." );
                        Console.ReadLine( );
                        break;
                  case 10:
                        QueryAttendees( context );
                        Console.Write( "\nContinue with Enter..." );
                        Console.ReadLine( );
                        break;
                  case 11:
                        AddAttendee( context );
                        break;
                  case 12:
                        DeleteAttendee( context );
                        break;

                  case 13:
#if DEBUG

                        OverrideDatabase( context );
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

#if DEBUG
      static void InitDatabase( ) => Factory.InitDatabase( );
      private static void OverrideDatabase( IContext c ) => Console.Write( "\nCsv-Database Overridden - doesnt't work right now!\n" );
#endif
      #endregion

      #region __E V E N T S__
      private static void PrintEvents( IContext c )
      {
            Console.Write( "\nAll Events\n" );

            foreach(var e in c.EventSet
                             .QuerySet.AsNoTracking( ))

                  Console.Write( $"\n{e}\n" );
      }
      private static void QueryEvents( IContext c )
      {
            Console.Write( "\nQuery Events\nquery: " );

            var query = Console.ReadLine( )!;

            try
            {
                  foreach(var eve in c.EventSet
                                     .QuerySet.AsNoTracking( )
                                              .Where( query ))

                        Console.Write( $"\n{eve}\n" );
            }
            catch(Exception ex) { Console.Write( $"\n{ex.Message}\n" ); }
      }
      private static EventManager.Logic.Entities.Event? AddEvent( IContext c )
      {
            Console.Write( "\nAdd Event\nTitle:\n  " );
            var eve = new EventManager.Logic.Entities.Event( );
            eve.Title = Console.ReadLine( )!;
            Console.Write( "\nDescription:\n  " );
            eve.Description = Console.ReadLine( )!;
            Console.WriteLine( "\nDate:\n  " );
            eve.Date = DateTime.Parse( Console.ReadLine( )! );

            Console.WriteLine( "\nLocation Name:\n  " );
            var count = 0;
            var locName = Console.ReadLine( )!;
            var loc = c.LocationSet.QuerySet.AsNoTracking( )!.FirstOrDefault( x => x.Name == locName );


            if(eve != null && eve.Title != string.Empty)
            {
                  while(loc == null && count < 3)
                  {
                        count++;
                        Console.WriteLine( "\nLocation Name:\n  " );

                        locName = Console.ReadLine( )!;
                        loc = c.LocationSet.QuerySet.AsNoTracking( )!.FirstOrDefault( x => x.Name == locName );
                  }
                  try
                  {
                        if(loc != null)
                              eve.LocationId = loc.Id;
                        else if(loc == null)
                              eve.LocationId = AddLocation( c )!.Id;

                        c.EventSet.Add( eve );
                        c.SaveChanges( );
                  }
                  catch(Exception ex)
                  {
                        eve = null;
                        Console.Write( $"\n{ex.Message}\nContinue with Enter..." );
                        Console.ReadLine( );
                  }
            }
            return eve;
      }
      private static void DeleteEvent( IContext c )
      {
            Console.Write( "\nDelete Events\nTitle: " );

            var title = Console.ReadLine( )!;
            var entity = c.EventSet
                          .QuerySet.AsNoTracking( )
                                   .FirstOrDefault( e => e.Title == title );

            if(entity != null)
            {
                  try
                  {
                        c.EventSet.Remove( entity.Id );
                        c.SaveChanges( );
                  }
                  catch(Exception ex)
                  {
                        Console.Write( $"\n{ex.Message}\nContinue with Enter..." );
                        Console.ReadLine( );
                  }
            }
      }
      #endregion

      #region __L O C A T I O N S__
      private static void DeleteLocation( IContext c )
      {
            Console.Write( "\nDelete Location\nName: " );

            var name = Console.ReadLine( )!;
            var entity = c.LocationSet
                          .QuerySet.AsNoTracking( )
                                   .FirstOrDefault( l => l.Name == name );

            if(entity != null)
            {
                  try
                  {
                        c.EventSet.Remove( entity.Id );
                        c.SaveChanges( );
                  }
                  catch(Exception ex)
                  {
                        Console.Write( $"\n{ex.Message}\nContinue with Enter..." );
                        Console.ReadLine( );
                  }
            }
      }
      private static EventManager.Logic.Entities.Location? AddLocation( IContext c )
      {
            Console.Write( "\nAdd Location\nName:\n  " );
            var loc = new EventManager.Logic.Entities.Location( );
            loc.Name = Console.ReadLine( )!;
            Console.Write( "\nAddress:\n  " );
            loc.Address = Console.ReadLine( )!;

            if(loc != null && loc.Name != string.Empty)
            {
                  try
                  {
                        c.LocationSet.Add( loc );
                        c.SaveChanges( );
                  }
                  catch(Exception ex)
                  {
                        loc = null;
                        Console.Write( $"\n{ex.Message}\nContinue with Enter..." );
                        Console.ReadLine( );
                  }
            }
            return loc;
      }
      private static void QueryLocations( IContext c )
      {
            Console.Write( "\nQuery Locations\nquery: " );

            var query = Console.ReadLine( )!;

            try
            {
                  foreach(var l in c.LocationSet
                                   .QuerySet.AsNoTracking( )
                                            .Where( query ))

                        Console.Write( $"\n{l}\n" );
            }
            catch(Exception ex) { Console.Write( $"\n{ex.Message}\n" ); }
      }
      private static void PrintLocations( IContext c )
      {
            Console.Write( "\nAll Locations\n" );

            foreach(var l in c.LocationSet
                             .QuerySet.AsNoTracking( ))

                  Console.Write( $"\n{l}\n" );
      }
      #endregion

      #region __A T T E N D E E S__
      private static void DeleteAttendee( IContext c )
      {
            Console.Write( "\nDelete Attendee\nEmail: " );

            var email = Console.ReadLine( )!;
            var entity = c.AttendeeSet
                          .QuerySet.AsNoTracking( )
                                   .FirstOrDefault( a => a.Email == email );

            if(entity != null)
            {
                  try
                  {
                        c.EventSet.Remove( entity.Id );
                        c.SaveChanges( );
                  }
                  catch(Exception ex)
                  {
                        Console.Write( $"\n{ex.Message}\nContinue with Enter..." );
                        Console.ReadLine( );
                  }
            }
      }
      private static void AddAttendee( IContext c )
      {
            Console.Write( "\nAdd Attendee\nEmail:\n  " );
            var att = new EventManager.Logic.Entities.Attendee( );
            att.Email = Console.ReadLine( )!;
            Console.Write( "\nFirstname:\n  " );
            att.FirstName = Console.ReadLine( )!;
            Console.WriteLine( "\nLastname:\n  " );
            att.LastName = Console.ReadLine( )!;

            Console.WriteLine( "\nEvent Title:\n  " );
            var count = 0;
            var eveTitle = Console.ReadLine( )!;
            var eve = c.EventSet.QuerySet.AsNoTracking( )!.FirstOrDefault( x => x.Title == eveTitle );

            if(att != null && att.Email != string.Empty)
            {
                  while(eve == null && count < 3)
                  {
                        count++;
                        Console.WriteLine( "\nEvent Title:\n  " );

                        eveTitle = Console.ReadLine( )!;
                        eve = c.EventSet.QuerySet.AsNoTracking( )!.FirstOrDefault( x => x.Title == eveTitle );
                  }
                  try
                  {
                        if(eve != null)
                              att.EventId = eve.Id;
                        else if(eve == null)
                              att.EventId = AddEvent( c )!.Id;

                        c.AttendeeSet.Add( att );
                        c.SaveChanges( );
                  }
                  catch(Exception ex)
                  {
                        att = null;
                        Console.Write( $"\n{ex.Message}\nContinue with Enter..." );
                        Console.ReadLine( );
                  }
            }
      }
      private static void QueryAttendees( IContext c )
      {
            Console.Write( "\nQuery Attendees\nquery: " );

            var query = Console.ReadLine( )!;

            try
            {
                  foreach(var a in c.AttendeeSet
                                   .QuerySet.AsNoTracking( )
                                            .Where( query ))

                        Console.Write( $"\n{a}\n" );
            }
            catch(Exception ex) { Console.Write( $"\n{ex.Message}\n" ); }
      }
      private static void PrintAttendees( IContext c )
      {
            Console.Write( "\nAll Attendees\n" );

            foreach(var a in c.AttendeeSet
                             .QuerySet.AsNoTracking( ))

                  Console.Write( $"\n{a}\n" );
      }
      #endregion
}