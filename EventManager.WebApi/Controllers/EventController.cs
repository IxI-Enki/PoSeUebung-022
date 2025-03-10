using EventManager.Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

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
            /// Retrieves the appropriate <see cref="DbSet{Event}"/> from the given context for the event type.
            /// </summary>
            ///
            /// <param name="context">
            /// The context from which to retrieve the DbSet.
            /// </param>
            ///
            /// <returns>
            /// A <see cref="DbSet{Event}"/> for the operations.
            /// </returns>
            protected override DbSet<Event> GetDbSet( IContext context ) => context.DbSetEvent ;


            /// <summary>
            /// Converts an event to its model representation.
            /// </summary>
            ///
            /// <param name="event">
            /// The event to convert.
            /// </param>
            ///
            /// <returns>
            /// A new instance of <typeparamref name="TEvent"/> representing the event.
            /// </returns>
            protected override TEvent ToModel( Event @event )
            {
                  // Create a new instance of the model
                  var result = new TEvent( );

                  // Copy properties from the genre entity to the model
                  result.CopyProperties( @event );

                  return result;
            }

            #endregion
      }
}
