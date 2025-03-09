using EventManager.Logic.Extensions;

///   N A M E S P A C E   ///
namespace EventManager.Logic.Entities;

[Table( "Attendees" )]
[Index( nameof( Email ) , IsUnique = true )]
public class Attendee : EntityObject, IAttendee
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

      public override string ToString( ) => string.Concat(
#if DEBUG
            $"Event-Id    : {EventId}\n".ForegroundColor( "240,120,40" ) ,
            $"Attendee-Id : {this.Id}\n".ForegroundColor( "240,120,40" ) ,
#endif
            $"Name  : {FirstName} {LastName}\n" ,
            $"Email : {Email}\n" );
}