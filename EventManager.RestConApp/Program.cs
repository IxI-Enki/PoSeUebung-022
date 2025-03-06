global using AppSettings = EventManager.Common.Modules.Configuration.AppSettings;

///   N A M E S P A C E   ///
namespace Eventmanager.ConApp;

internal class Program
{
      #region ___F I E L D S___ 
      private static string API_BASE_URL = "https://localhost:7074/api/";
      private static AppSettings _appSettings = AppSettings.Instance;
      #endregion

      #region ___C O N S T R U C T O R___       
      static Program( ) => API_BASE_URL = _appSettings[ "Server:BASE_URL" ] ?? API_BASE_URL;
      #endregion


      static void Main( )
      {
            string input = string.Empty;

            while(!input.Equals( "x" , StringComparison.CurrentCultureIgnoreCase ))
            {
                  int idx = 1;
            }
      }


}
