///   N A M E S P A C E   ///
namespace EventManager.WebApi.Models;


/// <summary>
/// Represents a model for a location, inheriting from <see cref="ModelObject"/>
///   to include an identifier and implementing <see cref="IGenre"/> for location-specific properties and behaviors.
/// </summary>
///
/// <remarks>
/// This class is designed to encapsulate location-related data and operations,
///   providing a concrete implementation of a location model
///   that can be used in data transfer and business logic.
/// </remarks>
public class ModelLocation :
        ModelObject,  // Provides the base class functionality, including the Id property for identification.
        ILocation        // An interface that defines location-specific properties like Name.
{
      #region ___P R O P E R T I E S___ 
      public string Name { get; set; } = string.Empty;
      public string Address { get; set; } = string.Empty;
      #endregion


      #region ___M E T H O D S___ 

      /// <summary>
      /// Copies properties from another location object,
      ///   including the base properties from <see cref="ModelObject"/>.
      /// </summary>
      ///
      /// <param name="other">
      /// Another location object that implements <see cref="IGenre"/> from which to copy properties.
      /// </param>
      ///
      /// <exception cref="ArgumentNullException">
      /// Thrown if the <paramref name="other"/> parameter is null.
      /// </exception>
      ///
      /// <remarks>
      /// This method overrides the base class's CopyProperties to include location-specific properties like Name,
      ///   allowing for a complete transfer of state from one location object to this instance.
      /// It first calls the base method to copy the Id,
      ///   then adds the Name property.
      /// </remarks>
      public virtual void CopyProperties( ILocation other )
      {
            // Call the base class method to copy the Id property
            base.CopyProperties( other );

            Name = other.Name;
            Address = other.Address;
      }


      /// <summary>
      /// Creates a new instance of <see cref="ModelLocation"/>
      ///   and copies properties from an existing location.
      /// </summary>
      ///
      /// <param name="location">
      /// The location object from which to copy properties.
      /// Must implement <see cref="ILocation"/>.
      /// </param>
      ///
      /// <returns>
      /// A new <see cref="ModelLocation"/> instance with properties copied from the provided location.
      /// </returns>
      ///
      /// <exception cref="ArgumentNullException">
      /// Thrown if the <paramref name="location"/> parameter is null.
      /// </exception>
      ///
      /// <remarks>
      /// This static factory method provides a convenient way to instantiate a new ModelGenre object
      ///   based on an existing location,
      ///   encapsulating the creation and initialization logic.
      /// It ensures that the new object starts with the same state as the provided location,
      ///   which can be useful for cloning or data transformation scenarios.
      /// </remarks>
      public static ModelLocation Create( ILocation location )
      {
            // Ensure the location parameter is not null before proceeding
            ArgumentNullException.ThrowIfNull( location , nameof( location ) );

            // Create a new instance of ModelGenre
            var result = new ModelLocation( );

            // Copy properties from the provided location to the new instance
            result.CopyProperties( location );

            return result;
      }

      #endregion
}
