///   N A M E S P A C E   ///
namespace EventManager.Common.Contracts;

public interface IAtendee : IIdentifiable
{
      string FirstName { get; set; }
      string LastName { get; set; }
      string Email { get; set; }
      int EventId { get; set; }

      void CopyProperties( IAtendee atendee )
      {
            ArgumentNullException.ThrowIfNullOrEmpty( nameof( atendee ) );

            FirstName = atendee.FirstName;
            LastName = atendee.LastName;
            Email = atendee.Email;

            EventId = atendee.EventId;
      }
}