
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.ServiceLocator;
using Common.Utils;
using Microsoft.EntityFrameworkCore;

namespace Common.Framework.Persistence
{
    public static class PersistSvr<T> where T : class /*, INotifyPropertyChanged*/
    {
        private static IPersistence<T> _provider;
        public static IPersistence<T> PersistenceProvider
        {
            get
            {
                if (_provider == null) _provider = ServiceLocator<IPersistence<T>>.GetService();
                return _provider;
            }
            set { _provider = value; }
        }

        public static async Task<bool> Insert( T entity, bool commit,DbContext context, CancellationToken ct = default(CancellationToken))
        {
            var model = Globals.SetAddDefaultPageValue(entity);
            return await PersistenceProvider.Insert(entity, commit,context,ct );
        }

        public static async Task<bool> Update(T entity, bool commit, DbContext context, CancellationToken ct = default(CancellationToken))
        {
            var model = Globals.SetModifyDefaultPageValue(entity,true);
            return await PersistenceProvider.Update(model, commit,context );
        }


        public static async Task<T> FindById(int id, DbContext context, CancellationToken ct = default(CancellationToken))
        {
            return await PersistenceProvider.FindById(id,context,ct);
        }

        public static bool Commit()
        {
            return PersistenceProvider.Commit();
        }
    }
}