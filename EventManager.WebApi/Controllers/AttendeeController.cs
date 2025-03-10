using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManager.WebApi.Controllers
{
      [Route( "api/[controller]" )]
      [ApiController]
      public class EventController : GenericController<TEvent,Event>
      {
            #region ___O V E R R I D E S___ 

            /// <summary>
            /// Provides the database context for operations.
            /// </summary>
            ///
            /// <returns>
            /// An instance of <see cref="IContext"/>.
            /// </returns>
            protected override IContext GetContext( ) => Factory.CreateContext( );


            /// <summary>
            /// Retrieves the appropriate <see cref="DbSet{Artist}"/> from the given context for the artist type.
            /// </summary>
            ///
            /// <param name="context">
            /// The context from which to retrieve the DbSet.
            /// </param>
            ///
            /// <returns>
            /// A <see cref="DbSet{Artist}"/> for the operations.
            /// </returns>
            protected override DbSet<Event> GetDbSet( IContext context ) => context.EventSet;


            /// <summary>
            /// Converts an artist to its model representation.
            /// </summary>
            ///
            /// <param name="artist">
            /// The artist to convert.
            /// </param>
            ///
            /// <returns>
            /// A new instance of <typeparamref name="TArtist"/> representing the artist.
            /// </returns>
            protected override TEvent ToModel( Event artist )
            {
                  // Create a new instance of the model
                  var result = new TEvent( );

                  // Copy properties from the genre entity to the model
                  result.CopyProperties( artist );

                  return result;
            }

            #endregion
      }
}
