///   N A M E S P A C E   ///
namespace EventManager.WebApi.Controllers;

[Route( "api/[controller]" )]
[ApiController]
public class LocationController : GenericController<TLocation , Location>
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
      /// Retrieves the appropriate <see cref="DbSet{Location}"/> from the given context for the location type.
      /// </summary>
      ///
      /// <param name="context">
      /// The context from which to retrieve the DbSet.
      /// </param>
      ///
      /// <returns>
      /// A <see cref="DbSet{Location}"/> for the operations.
      /// </returns>
      protected override DbSet<Location> GetDbSet( IContext context ) => context.DbSetLocation;

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