///   N A M E S P A C E   ///
namespace EventManager.Logic.DataContext;

public class EventContext : DbContext, IContext
{
      #region __F I E L D S__
      private static string
            _databaseType = "Sqlite",
            _connectionString = "data source=EventManager.db";
      #endregion

      #region __P R O P E R T I E S__
      public DbSet<Event> EventSet { get; set; }
      public DbSet<Location> LocationSet { get; set; }
      public DbSet<Attendee> AttendeeSet { get; set; }
      #endregion

      #region __C O N S T R U C T O R__
      public EventContext( )
      {
            var appSettings = Common.Modules.Configuration.AppSettings.Instance;
            
            _databaseType = appSettings[ "Database:Type" ] ?? _databaseType;
            _connectionString = appSettings[ $"ConnectionStrings:{_databaseType}ConnectionString" ] ?? _connectionString;
      }
      #endregion

      #region __O V E R R I D E S__
      protected override void OnConfiguring( DbContextOptionsBuilder builder )
      {
            if(_databaseType == "Sqlite") builder.UseSqlite( _connectionString );

            else if(_databaseType == "SqlServer") builder.UseSqlServer( _connectionString );

            base.OnConfiguring( builder );
      }
      #endregion
}