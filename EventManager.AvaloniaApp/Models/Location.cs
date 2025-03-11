///   N A M E S P A C E   ///
namespace EventManager.RESTConApp.Models;

public class Location : EventManager.RESTConApp.Models.ModelObject, Common.Contracts.ILocation
{
      public string Name { get; set; } = string.Empty;
      public string Address { get; set; } = string.Empty;

      public override string ToString( ) => string.Concat(
#if DEBUG
            $"Location-Id : {this.Id}\n".Colored( "debug" ) ,
#endif
            $"Name    : {Name}\n" ,
            $"Address : {Address}" );
}