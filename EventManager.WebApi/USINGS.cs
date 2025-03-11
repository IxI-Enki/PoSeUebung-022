///   S Y S T E M   ///
global using System.Web;
global using System.Text.Json;
global using System.Linq.Dynamic.Core;

///   A S P   N E T   ///
global using Microsoft.AspNetCore;
global using Microsoft.AspNetCore.Mvc;

///   E N T I T Y   F R A M E W O R K   ///
global using Microsoft.EntityFrameworkCore;

///   E V E N T   M A N A G E R   ///
//   - Common   
global using IEvent = EventManager.Common.Contracts.IEvent;
global using ILocation = EventManager.Common.Contracts.ILocation;
global using IAttendee = EventManager.Common.Contracts.IAttendee;
global using IIdentifiable = EventManager.Common.Contracts.IIdentifiable;
//   - Logic   
global using EventManager.Logic.Entities;
global using Factory = EventManager.Logic.DataContext.Factory;
global using IContext = EventManager.Logic.Contracts.IContext;
global using CredLoader = EventManager.Logic.DataContext.DataLoader.CredentialLoader;
global using EntityObject = EventManager.Logic.Entities.EntityObject;
//   - WebApi   
global using EventManager.WebApi;
global using EventManager.WebApi.Models;
global using EventManager.WebApi.Contracts;
global using EventManager.WebApi.Controllers;
global using TEvent = EventManager.WebApi.Models.ModelEvent;
global using TLocation = EventManager.WebApi.Models.ModelLocation;
global using TAttendee = EventManager.WebApi.Models.ModelAttendee;
global using ModelObject = EventManager.WebApi.Models.ModelObject;

///   N A M E S P A C E   ///
namespace EventManager.WebApi;
public static class Usings
{
      public static readonly int MAX_COUNT = 500;
}