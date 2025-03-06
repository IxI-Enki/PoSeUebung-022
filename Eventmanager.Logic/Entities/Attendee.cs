///   N A M E S P A C E   ///
namespace EventManager.Logic.Entities;

[Table( "Attendees" )]
[Index( nameof( Email ) , IsUnique = true )]
public class Attendee : EntityObject, IAtendee
{
      [Required]
      [MaxLength( 64 )]
      public string FirstName { get; set; } = string.Empty;

      [Required]
      [MaxLength( 64 )]
      public string LastName { get; set; } = string.Empty;

      [Required]
      [MaxLength( 128 )]
      public string Email { get; set; } = string.Empty;

      [Required]
      public int EventId { get; set; }

      public override string ToString( ) => $"Attendee: {FirstName} {LastName}";
}