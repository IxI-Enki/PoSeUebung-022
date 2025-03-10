global using EntityObject = EventManager.Logic.Entities.EntityObject;
global using IContext = EventManager.Logic.Contracts.IContext;
global using IIdentifiable = EventManager.Common.Contracts.IIdentifiable;
global using Factory = EventManager.Logic.DataContext.Factory;
global using CredLoader = EventManager.Logic.DataContext.DataLoader.CredentialLoader;



global using IEvent = EventManager.Common.Contracts.IEvent;
global using ILocation = EventManager.Common.Contracts.ILocation;
global using IAttendee = EventManager.Common.Contracts.IAttendee;

//   - WebAPI   
//
global using EventManager.WebApi;
global using EventManager.WebApi.Models;
global using EventManager.WebApi.Contracts;
global using EventManager.WebApi.Controllers;
global using TEvent = EventManager.WebApi.Models.ModelEvent;
global using TLocation = EventManager.WebApi.Models.ModelLocation;
global using TAttendee = EventManager.WebApi.Models.ModelAttendee;

//
global using ModelObject = EventManager.WebApi.Models.ModelObject;

///   S Y S T E M   ///
global using System.Linq.Dynamic.Core;
global using System.Text.Json;
global using System.Web;

///   A S P   N E T   ///
global using Microsoft.AspNetCore;
global using Microsoft.AspNetCore.Mvc;


///   E N T I T Y   F R A M E W O R K   ///
global using Microsoft.EntityFrameworkCore;


///   N A M E S P A C E   ///
namespace EventManager.WebApi;
public static class USINGS
{
      public static readonly int MAX_COUNT = 500;
}