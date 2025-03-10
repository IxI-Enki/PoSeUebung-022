///   N A M E S P A C E   ///
namespace EventManager.Logic.Entities;

public abstract class EntityObject : IIdentifiable
{

      [System.ComponentModel.DataAnnotations.Key]
      public int Id { get; set; }

      #region ___M E T H O D___ 

      /// <summary>
      /// Copies the properties from another identifiable object to this entity.
      /// </summary>
      ///
      /// <param name="other">
      /// The other identifiable object from which to copy properties.
      /// </param>
      ///
      /// <exception cref="ArgumentNullException">
      /// Thrown when the <paramref name="other"/> parameter is null.
      /// </exception>
      ///
      /// <remarks>
      /// This method copies only the identifier,
      ///   assuming that other properties should be managed by derived classes.
      /// It's designed to be overridden by subclasses to include additional property copying if needed.
      /// </remarks>
      public void CopyProperties( IIdentifiable other )
      {
            // Check if the other object is null to prevent null reference exceptions
            ArgumentNullException.ThrowIfNullOrEmpty( nameof( other ) );

            // Copy the Id from the other object to this instance
            Id = other.Id;
      }

      #endregion
}