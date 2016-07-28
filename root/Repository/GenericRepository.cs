using Console1.Models;
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace Console1.Repository
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> CustomizeGet(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        IQueryable<T> GetAll();
    }

    public class GenericRepository<TEntity, DbContext> : IGenericRepository<TEntity>
        where TEntity : class, new() where DbContext : Models.Context, new()
    {

        private DbContext _entities = new DbContext();

        public IQueryable<TEntity> CustomizeGet(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _entities.Set<TEntity>().Where(predicate);
            return query;
        }

        public void Add(TEntity entity)
        {
            int userId = Program.UserId; // یوزد آی دی بصورت فیک ساخته شده
                            // اگر از آیدنتیتی استفاده میکنید میتوان آی دی و هر چیز دیگری که کلیم شده را در اختیار گرفت

            if (typeof(IUser).IsAssignableFrom(typeof(TEntity)))
            {
                ((IUser)entity).UserId = userId;
            }

            _entities.Set<TEntity>().Add(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> result = _entities.Set<TEntity>();

            int userId = Program.UserId; // یوزد آی دی بصورت فیک ساخته شده
                            // اگر از آیدنتیتی استفاده میکنید میتوان آی دی و هر چیز دیگری که کلیم شده را در اختیار گرفت

            if (typeof(IUser).IsAssignableFrom(typeof(TEntity)))
            {
                User me = _entities.Users.Single(c => c.Id == userId);
                if (me.Type == UserType.Admin)
                {
                    return result;
                }
                else if (me.Type == UserType.Ordinary)
                {
                    string query = $"{nameof(IUser.UserId).ToString()}={userId}";
                    
                    return result.Where(query);
                }
            }
            return result;
        }

        public void Commit()
        {
            _entities.SaveChanges();
        }
    }
}
