global using EntityObject = EventManager.Logic.Entities.EntityObject;
global using IContext = EventManager.Logic.Contracts.IContext;
global using IIdentifiable = EventManager.Common.Contracts.IIdentifiable;
global using Factory = EventManager.Logic.DataContext.Factory;
global using CredLoader = EventManager.Logic.DataContext.DataLoader.CredentialLoader;
global using EventManager.WebApi.Models;
global using Microsoft.AspNetCore.Mvc;

///   E N T I T Y   F R A M E W O R K   ///
global using Microsoft.EntityFrameworkCore;


///   N A M E S P A C E   ///
namespace EventManager.WebApi;