///   N A M E S P A C E   ///
namespace EventManager.Common.Contracts;

public interface IAttendee : IIdentifiable
{
      string FirstName { get; set; }
      string LastName { get; set; }
      string Email { get; set; }
      int EventId { get; set; }

      void CopyProperties( IAttendee a )
      {
            ArgumentNullException.ThrowIfNullOrEmpty( nameof( a ) );

            FirstName = a.FirstName;
            LastName = a.LastName;
            Email = a.Email;

            EventId = a.EventId;
      }
}