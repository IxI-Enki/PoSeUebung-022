///   N A M E S P A C E   ///
namespace EventManager.RESTConApp.Models;

public class Event : EventManager.RESTConApp.Models.ModelObject, Common.Contracts.IEvent
{
      public string Title { get; set; } = string.Empty;
      public string Description { get; set; } = string.Empty;
      public DateTime Date { get; set; }
      public int LocationId { get; set; }

      public override string ToString( ) => string.Concat(
#if DEBUG
            $"Event-Id    : {this.Id}\n".Colored( "debug" ) ,
            $"Location-Id : {LocationId}\n".Colored( "debug" ) ,
#endif 
            $"Event-Title : {Title}\n" ,
            $"Description : {Description}\n" ,
            $"Date        : {Date}\n" );
}
