///   N A M E S P A C E   ///
namespace EventManager.RESTConApp.Models;

public class Attendee : EventManager.RESTConApp.Models.ModelObject, Common.Contracts.IAttendee
{
      public string FirstName { get; set; } = string.Empty;
      public string LastName { get; set; } = string.Empty;
      public string Email { get; set; } = string.Empty;
      public int EventId { get; set; }

      public override string ToString( ) => string.Concat(
#if DEBUG
            $"Event-Id    : {EventId}\n".Colored( "debug" ) ,
            $"Attendee-Id : {this.Id}\n".Colored( "debug" ) ,
#endif
            $"Name  : {FirstName} {LastName}\n" ,
            $"Email : {Email}\n" );
}
