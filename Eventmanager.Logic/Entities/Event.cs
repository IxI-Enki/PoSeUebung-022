///   N A M E S P A C E   ///
namespace EventManager.Logic.Entities;

[Table( "Events" )]
[Index( nameof( Title ) , IsUnique = true )]
public class Event : EntityObject, IEvent
{
      [Required]
      [MaxLength( 256 )]
      public string Title { get; set; } = string.Empty;

      [MaxLength( 1024 )]
      public string Description { get; set; } = string.Empty;

      [Required]
      public DateTime Date { get; set; }

      [Required]
      public int LocationId { get; set; }

      public override string ToString( ) => string.Concat(
#if DEBUG
            $"Event-Id    : {this.Id}\n".Colored( "debug" ) ,
            $"Location-Id : {LocationId}\n".Colored( "debug" ) ,
#endif 
            $"Event-Title : {Title}\n" ,
            $"Description : {Description}\n",
            $"Date        : {Date}\n" );
}