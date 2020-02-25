

using Common;
using Common.Framework.Persistence;
using Common.LogService;
using Microsoft.EntityFrameworkCore;
using Persistence.DbCxt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace  Persistence.Common.DbCxt
{


    public class PersistenceBase<T> : IPersistence<T> where T : BusinessEntityBase
    {
        protected String _entitySetName = String.Empty;



        #region IPersistence<T> Members

        public async Task<bool> Insert(T entity, bool commit, DbContext context, CancellationToken ct = default(CancellationToken))
        {
            return await InsertObject(entity, commit, context,ct);
        }

        public async Task<bool> Update(T entity, bool commit, DbContext context, CancellationToken ct = default(CancellationToken))
        {
            return await UpdateObject(entity, commit, context,ct);
        }

        public virtual async Task<T> FindById(int id, DbContext context, CancellationToken ct = default(CancellationToken))
        {
            // return await FindMatchedId(id, context);
            throw new ApplicationException("PersistenceBase.EntitySet: Shouldn't get here.");
        }

        public virtual bool Commit()
        {
            return false;
        }

        #endregion

        protected virtual T FindMatchedOne(T toBeMatched, DbContext context)
        {
            throw new ApplicationException("PersistenceBase.EntitySet: Shouldn't get here.");
        }

        //protected virtual Task<T> FindMatchedId(int id, DbContext context)
        //{
        //    throw new ApplicationException("PersistenceBase.EntitySet: Shouldn't get here.");
        //}

        protected virtual IQueryable<T> EntitySet(DbContext context)
        {
            throw new ApplicationException("PersistenceBase.EntitySet: Shouldn't get here.");
        }


        protected async Task<bool> InsertObject(T entity, bool commit, DbContext context, CancellationToken ct = default(CancellationToken))
        {
            context.Entry(entity).State = EntityState.Added;
            try
            {
                if (commit)
                {
                    if ((await SaveChanges(context)))
                    {
                        context.Entry(entity).State = EntityState.Detached;
                        return true;
                    }
                    else
                    {
                        context.Entry(entity).State = EntityState.Detached;
                    }
                }
                return false;
            }
            //catch (DbEntityValidationException dbex)
            //{
            //    context.Entry(entity).State = EntityState.Detached;
            //    CRUDCommonCode.CreateLog(dbex);
            //    return false;
            //}
            catch (Exception e)
            {
                context.Entry(entity).State = EntityState.Detached;
                CRUDCommonCode.CreateLog(e);
                return false;
            }

        }



        protected async Task<bool> UpdateObject(T entity, bool commit, DbContext context,CancellationToken ct = default(CancellationToken))
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                if (commit)
                {
                    if ((await SaveChanges(context)))
                    {
                        context.Entry(entity).State = EntityState.Detached;
                        return true;
                    }
                    else
                    {
                        context.Entry(entity).State = EntityState.Detached;
                    }
                }
                return false;
            }
            catch (InvalidOperationException e) // Usually the error getting here will have a message: "an object with the same key already exists in the ObjectStateManager. The ObjectStateManager cannot track multiple objects with the same key"
            {
                T t = FindMatchedOne(entity, context);
                if (t == null) throw new ApplicationException("Entity doesn't exist in the repository");
                try
                {
                    context.Entry(t).State = EntityState.Detached;
                    (EntitySet(context) as DbSet<T>).Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                    if (commit)
                    {
                        if ((await SaveChanges(context)))
                        {
                            context.Entry(entity).State = EntityState.Detached;
                            return true;
                        }
                        else
                        {
                            context.Entry(entity).State = EntityState.Detached;
                        }
                    }
                    return false;

                }
                catch (Exception exx)
                {
                    //Roll back
                    context.Entry(entity).State = EntityState.Detached;
                    (EntitySet(context) as DbSet<T>).Attach(t);
                    CRUDCommonCode.CreateLog(exx);
                    return false;
                }
            }
            //catch (DbEntityValidationException dbex)
            //{
            //    context.Entry(entity).State = EntityState.Detached;
            //    CRUDCommonCode.CreateLog(dbex);
            //    return false;
            //}
            catch (Exception ex)
            {
                context.Entry(entity).State = EntityState.Detached;
                CRUDCommonCode.CreateLog(ex);
                return false;
            }

        }

        

        
        protected async Task<bool> SaveChanges(DbContext context)
        {
            using (var dbcxtransaction = context.Database.BeginTransaction())
            {
                try
                {
                    await context.SaveChangesAsync();
                    dbcxtransaction.Commit();
                    return  true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    //Update original values from the database (Similar ClientWins in ObjectContext.Refresh)
                    try
                    {
                        var entry = ex.Entries.Single();
                        entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                        context.SaveChanges();
                        dbcxtransaction.Commit();
                        return true;
                    }

                    catch (Exception exs)
                    {
                        CRUDCommonCode.CreateLog(exs);
                        dbcxtransaction.Rollback();
                        return false;
                    }
                }

                //catch (DbEntityValidationException dbex)
                //{
                //    CRUDCommonCode.CreateLog(dbex);
                //    dbcxtransaction.Rollback();
                //    return false;
                //}
            }
        }
    }
}