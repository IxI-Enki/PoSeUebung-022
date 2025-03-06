///   U S I N G S   ///
global using AppSettings = EventManager.Common.Modules.Configuration.AppSettings;
global using IContext = EventManager.Logic.Contracts.IContext;
global using Factory = EventManager.Logic.DataContext.Factory;

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
            Console.Write( "Your choice: " );
            input = Console.ReadLine( )!;
            return input;
      }

      private static void PrintHeader( ) => Console.Write(
                                                            string.Concat(
                                                                  new string( ' ' , 6 ) ,
                                                                  "Event Manager\n" ,
                                                                  new string( '=' , 25 ) ) );

      private static int PrintMenu( )
      {
#if DEBUG
            Console.Write( $"\n{nameof( InitDatabase ),-20}....0" );
#endif
            int idx = 1;
            Console.Write( $"\n{nameof( PrintEvents ),-20}....{idx++}" );
            Console.Write( $"\n{nameof( QueryEvents ),-20}....{idx++}" );
            Console.Write( $"\n{nameof( AddEvent ),-20}....{idx++}" );
            Console.Write( $"\n{nameof( DeleteEvent ),-20}....{idx++}" );

            Console.Write( string.Concat( "\n\nExit" , new string( '.' , 20 ) , "x\n" ) );
            return idx;
      }

      private static void RunChoice( IContext context , int choice )
      {
            switch(choice)
            {
                  case 0:
                        InitDatabase( );
                        Console.Write( "\nContinue with Enter..." );
                        Console.ReadLine( );
                        break;
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
                  default:
                        break;
            }
      }

#if DEBUG
      static void InitDatabase( ) => Factory.InitDatabase( );
#endif
      #endregion

      #region __E V E N T S__
      static void PrintEvents( IContext c ) { }
      static void QueryEvents( IContext c ) { }
      static void AddEvent( IContext c ) { }
      static void DeleteEvent( IContext c ) { }
      #endregion
}