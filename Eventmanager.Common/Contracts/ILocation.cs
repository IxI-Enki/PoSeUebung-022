///   N A M E S P A C E   ///
namespace EventManager.Common.Contracts;

public interface ILocation : IIdentifiable
{
     string Name { get; set; }
      string Address { get; set; }

      void CopyProperties(ILocation location )
      {
            ArgumentNullException.ThrowIfNullOrEmpty( nameof( location ) );

            Name = location.Name;
            Address = location.Address;
      }
}