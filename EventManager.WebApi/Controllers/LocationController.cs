using EventManager.Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManager.WebApi.Controllers
{
      [Route( "api/[controller]" )]
      [ApiController]
      public class LocationController : GenericController<TLocation , Location>
      {
            protected override IContext GetContext( ) => Factory.CreateContext( );

            protected override DbSet<Location>? GetDbSet( IContext context ) => context.DbSetLocation;

            #region ___O V E R R I D E S___ 

            /// <summary>
            /// Converts an location to its model representation.
            /// </summary>
            ///
            /// <param name="location">
            /// The location to convert.
            /// </param>
            ///
            /// <returns>
            /// A new instance of <typeparamref name="TArtist"/> representing the location.
            /// </returns>
            protected override TLocation ToModel( Location location )
            {
                  // Create a new instance of the model
                  var result = new TLocation( );

                  // Copy properties from the genre entity to the model
                  result.CopyProperties( location );

                  return result;
            }

            #endregion
      }
}
