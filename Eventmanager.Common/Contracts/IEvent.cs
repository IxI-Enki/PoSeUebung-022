///   N A M E S P A C E   ///
namespace EventManager.Common.Contracts;

public interface IEvent : IIdentifiable
{
      string Title { get; set; }

      string Description { get; set; }

      DateTime Date { get; set; }

      int LocationId { get; set; }

      void CopyProperties( IEvent e )
      {
            ArgumentNullException.ThrowIfNullOrEmpty( nameof( e ) );

            Id = e.Id;
            Date = e.Date;
            Title = e.Title;
            Description = e.Description;

            LocationId = e.LocationId;
      }
}