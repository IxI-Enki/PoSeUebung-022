///   N A M E S P A C E   ///
namespace EventManager.Logic.Entities;

public abstract class EntityObject : IIdentifiable
{

      [System.ComponentModel.DataAnnotations.Key]
      public int Id { get; set; }
}