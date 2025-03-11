///   S Y S T E M   ///
global using System;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using System.Linq.Dynamic.Core;
global using System.Collections.Generic;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;

///   E N T I T Y   F R A M E W O R K   ///
global using Microsoft.EntityFrameworkCore;

///   E V E N T   M A N A G E R   ///
//   - Common   
global using EventManager.Common.Contracts;
//   - Logic   
global using EventManager.Logic.Entities;
global using EventManager.Logic.Contracts;
global using EventManager.Logic.Extensions;
global using EventManager.Logic.DataContext;

///   N A M E S P A C E   ///
namespace Eventmanager.Logic;