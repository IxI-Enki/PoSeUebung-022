
///   N A M E S P A C E   ///
namespace EventManager.Common.Contracts;


public interface ISettings
{
      #region ___P R O P E R T Y___ 
      string? this[ string key ] { get; }
      #endregion  
}