using Elktab.Data;
using Elktab.DataAccess.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elktab.DataAccess
{
    public class GeneralRepository<T> : IRepository<T> where T : class
    {
        
            private readonly ApplicationDbContext db;
            public readonly DbSet<T> table;
            public GeneralRepository(ApplicationDbContext Db)
            {
                db  = Db;

                table = db.Set<T>();

            }


            public T Add(T Entity)
            {
                try
                {
                    AddWithoutSave(Entity);
                    if (SaveChange())
                        return Entity;
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            public IQueryable<T> GetALl()
            {
                return table;

            }
        public IQueryable<T> GetALl(Func<T, bool> condition)
        {
            return table.Where(condition).AsQueryable();

        }
        public T AddWithoutSave(T Enitity)
            {
                table.Add(Enitity);
                return Enitity;
            }

            public virtual T Get(int id)
            {

                return table.Find(id);
            }
       
        public bool SaveChange()
            {
                try
                {
                    return db.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public bool Update(T Entity)
            {
                if (UpdateWithoutSave(Entity))
                {
                    return SaveChange();
                }
                return false;
            }

            public bool UpdateWithoutSave(T Entity)
            {
                try
                {
                    table.Attach(Entity);
                    db.Entry(Entity).State = EntityState.Modified;
                    return true;

                }
                catch (Exception ex)
                {


                    return false;




                }
            }

            public void Dispose()
            {
                db.Dispose();
            }

            public bool AddRange(ICollection<T> Entity)
            {
                try
                {
                    table.AddRange(Entity);
                    return SaveChange();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            public virtual T Get(string id)
            {
                return table.Find(id);
            }
        public bool Remove(T entity) {

            table.Remove(entity);
            try
            {
             return  db.SaveChanges() > 0 ? true : false;
            }
            catch { return false; }
        }
        }
    }

