///   N A M E S P A C E   ///
namespace EventManager.Logic.DataContext;

public abstract class EntitySet<TEntity>( DbContext context , DbSet<TEntity> dbSet ) where TEntity : EntityObject, new()
{
      #region __F I E L D__
      protected DbSet<TEntity> _dbSet = dbSet;
      #endregion

      #region __P R O P E R T I E S__
      internal DbContext Context { get; private set; } = context;

      public IQueryable<TEntity> QuerySet => _dbSet.AsQueryable( );
      #endregion
 
      #region __M E T H O D S__
      protected abstract void CopyProperties( TEntity target , TEntity source );

      public virtual TEntity Create( ) => new( );

      public virtual TEntity Add( TEntity entity ) => _dbSet.Add( entity ).Entity;

      public virtual async Task<TEntity> AddAsync( TEntity entity )
      {
            var res = await _dbSet.AddAsync( entity ).ConfigureAwait( false );

            return res.Entity;
      }

      public virtual TEntity? Update( int id , TEntity entity )
      {
            var res = _dbSet.Find( id );

            if(res != null) CopyProperties( res , entity );

            return res;
      }

      public virtual async Task<TEntity?> UpdateAsync( int id , TEntity entity )
      {
            var res = await _dbSet.FindAsync( id ).ConfigureAwait( false );

            if(res != null) CopyProperties( res , entity );

            return res;
      }

      public virtual TEntity? Remove( int id )
      {
            var res = _dbSet.Find( id );

            if(res != null) _dbSet.Remove( res );

            return res;
      }
      #endregion
}