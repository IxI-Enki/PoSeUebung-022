///   N A M E S P A C E   /// 
namespace EventManager.Common.Modules.Configuration;

public class AppSettings( ) : ISettings
{
      #region __F I E L D S__
      private static readonly AppSettings _instance = new( );
      private static readonly IConfigurationRoot _configurationRoot;
      #endregion

      #region __P R O P E R T Y__
      public static AppSettings Instance => _instance;
      #endregion

      #region __C O N S T R U C T O R S__
      static AppSettings( )
      {
            var environmentName
                  = Environment.GetEnvironmentVariable( "ASPCORE_ENVIRONMENT" );

            var builder
                  = new ConfigurationBuilder( )
                        .AddJsonFile( "appsettings.json" ,
                                      optional: false ,
                                      reloadOnChange: true )
                        .AddJsonFile( $"appsettings.{environmentName ?? "Development"}.json" ,
                                      optional: true )
                        .AddEnvironmentVariables( );

            _configurationRoot
                  = builder.Build( );
      }
      #endregion

      #region __M E T H O D__
      public string? this[ string key ] => _configurationRoot[ key ];
      #endregion
}