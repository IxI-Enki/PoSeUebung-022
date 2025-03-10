///   N A M E S P A C E   ///
namespace EventManager.Logic.Entities;

[Table( "Locations" )]
[Index( nameof( Name ) , IsUnique = true )]
public class Location : EntityObject, ILocation
{
      [Required]
      [MaxLength( 256 )]
      public string Name { get; set; } = string.Empty;

      [Required]
      [MaxLength( 512 )]
      public string Address { get; set; } = string.Empty;

      public override string ToString( ) => string.Concat(
#if DEBUG
            $"Location-Id : {this.Id}\n".Colored( "debug" ) ,
#endif
            $"Name    : {Name}\n" ,
            $"Address : {Address}" );
}