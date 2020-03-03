using NewsModels.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;


namespace NewsModels.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly NewsDBEntities _context;
        public IDbSet<T> _entities;

        public GenericRepository()
        {
            _context = new NewsDBEntities();
            _entities = _context.Set<T>();
        }

        //public GenericRepository(CategoryContext context)
        //{
        //    this._context = context;
        //}
        public IEnumerable<T> Table
        {
            get
            {
                //var articles = _context.Articles.Include(a => a.Author);
                return this.Entities;
            }
        }

        public void Delete(object id)
        {
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException("entity");
                }
                T del = Entities.Find(id);
                Entities.Remove(del);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Add(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                _context.Entry(entity).State = EntityState.Modified;
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        //public void Save(T entity)
        //{
        //    _context.Entry(entity).State = EntityState.Modified;
        //    this._context.SaveChanges();
        //}

        T IGenericRepository<T>.Foreign(T entity)
        {
            throw new NotImplementedException();
        }

        public IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _context.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

    }
}   