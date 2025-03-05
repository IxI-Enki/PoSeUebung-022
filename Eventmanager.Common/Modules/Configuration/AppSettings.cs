///   N A M E S P A C E   /// 
namespace EventManager.Common.Modules.Configuration;

internal class AppSettings : ISettings
{
      #region FIELDS
      private static AppSettings _instance = new( );
      private static IConfigurationRoot _configurationRoot;
      #endregion

      #region PROPERTY
      public static AppSettings Instance => _instance;
      #endregion

      #region CONSTRUCTORS
      private AppSettings( ) { }
      static AppSettings( )
      {
            var environmentName = Environment.GetEnvironmentVariable( "ASPCORE_ENVIRONMENT" );

            var builder
                  = new ConfigurationBuilder( )
                        .AddJsonFile( "appsetting.json" , optional: false , reloadOnChange: true )
                        .AddJsonFile( $"appsetting.{environmentName ?? "Development"}.json" , optional: true )
                        .AddEnvironmentVariables( );

            _configurationRoot = builder.Build( );
      }
      #endregion

      #region METHOD
      public string? this[ string key ] => _configurationRoot[ key ];
      #endregion
}