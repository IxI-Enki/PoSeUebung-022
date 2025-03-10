///   N A M E S P A C E   ///
namespace EventManager.WebApi.Models;


/// <summary>
/// Represents a model for a attendee, inheriting from <see cref="ModelObject"/>
///   to include an identifier and implementing <see cref="IGenre"/> for attendee-specific properties and behaviors.
/// </summary>
///
/// <remarks>
/// This class is designed to encapsulate attendee-related data and operations,
///   providing a concrete implementation of a attendee model
///   that can be used in data transfer and business logic.
/// </remarks>
public class ModelAttendee :
        ModelObject,  // Provides the base class functionality, including the Id property for identification.
        IAttendee        // An interface that defines attendee-specific properties like Name.
{
      #region ___P R O P E R T I E S___ 
      public string FirstName { get; set; } = string.Empty;
      public string LastName { get; set; } = string.Empty;
      public string Email { get; set; } = string.Empty;
      public int EventId { get; set; }
      #endregion


      #region ___M E T H O D S___ 

      /// <summary>
      /// Copies properties from another attendee object,
      ///   including the base properties from <see cref="ModelObject"/>.
      /// </summary>
      ///
      /// <param name="other">
      /// Another attendee object that implements <see cref="IGenre"/> from which to copy properties.
      /// </param>
      ///
      /// <exception cref="ArgumentNullException">
      /// Thrown if the <paramref name="other"/> parameter is null.
      /// </exception>
      ///
      /// <remarks>
      /// This method overrides the base class's CopyProperties to include attendee-specific properties like Name,
      ///   allowing for a complete transfer of state from one attendee object to this instance.
      /// It first calls the base method to copy the Id,
      ///   then adds the Name property.
      /// </remarks>
      public virtual void CopyProperties( IAttendee other )
      {
            // Call the base class method to copy the Id property
            base.CopyProperties( other );

            // Copy the Name property from the provided attendee object
            FirstName = other.FirstName; 
            LastName = other.LastName;
            Email = other.Email;
            EventId = other.EventId;
      }


      /// <summary>
      /// Creates a new instance of <see cref="ModelAttendee"/>
      ///   and copies properties from an existing attendee.
      /// </summary>
      ///
      /// <param name="attendee">
      /// The attendee object from which to copy properties.
      /// Must implement <see cref="IAttendee"/>.
      /// </param>
      ///
      /// <returns>
      /// A new <see cref="ModelAttendee"/> instance with properties copied from the provided attendee.
      /// </returns>
      ///
      /// <exception cref="ArgumentNullException">
      /// Thrown if the <paramref name="attendee"/> parameter is null.
      /// </exception>
      ///
      /// <remarks>
      /// This static factory method provides a convenient way to instantiate a new ModelGenre object
      ///   based on an existing attendee,
      ///   encapsulating the creation and initialization logic.
      /// It ensures that the new object starts with the same state as the provided attendee,
      ///   which can be useful for cloning or data transformation scenarios.
      /// </remarks>
      public static ModelAttendee Create( IAttendee attendee )
      {
            // Ensure the attendee parameter is not null before proceeding
            ArgumentNullException.ThrowIfNull( attendee , nameof( attendee ) );

            // Create a new instance of ModelGenre
            var result = new ModelAttendee( );

            // Copy properties from the provided attendee to the new instance
            result.CopyProperties( attendee );

            return result;
      }

      #endregion
}
