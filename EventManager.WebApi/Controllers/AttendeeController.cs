///   N A M E S P A C E   ///
namespace EventManager.WebApi.Controllers;

[Route( "api/[controller]" )]
[ApiController]
public class AttendeeController : GenericController<TAttendee , Attendee>
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
      /// Retrieves the appropriate <see cref="DbSet{Attendee}"/> from the given context for the attendee type.
      /// </summary>
      ///
      /// <param name="context">
      /// The context from which to retrieve the DbSet.
      /// </param>
      ///
      /// <returns>
      /// A <see cref="DbSet{Attendee}"/> for the operations.
      /// </returns>
      protected override DbSet<Attendee> GetDbSet( IContext context ) => context.DbSetAttendee;

      /// <summary>
      /// Converts an attendee to its model representation.
      /// </summary>
      ///
      /// <param name="attendee">
      /// The attendee to convert.
      /// </param>
      ///
      /// <returns>
      /// A new instance of <typeparamref name="TAttendee"/> representing the attendee.
      /// </returns>
      protected override TAttendee ToModel( Attendee attendee )
      {
            // Create a new instance of the model
            var result = new TAttendee( );
            // Copy properties from the genre entity to the model
            result.CopyProperties( attendee );
            return result;
      }

      #endregion
}