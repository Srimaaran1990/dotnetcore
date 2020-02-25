using Common.Utils;
using System.Collections.Generic;
using System.Linq;


namespace DotnetCore.Web.Helpers
{

    public class ChangeOperation : IChangeOperation
    {


        public void Attach(EntityChangeObserver observer)
        {
            Globals.observers.Add(observer);
        }

        public void Detach(EntityChangeObserver observer)
        {
            Globals.observers.Remove(observer);
        }

        public bool Clone(EntityChangeObserver observer)
        {
            List<EntityChangeObserver> _observerChild = Globals.observers.Where(n => n._clientId == observer._clientId && n._countryId == observer._countryId && n._buId == observer._buId && n._functionName == observer._functionName).ToList();
            if (_observerChild.Count() >= 1)
            {
                foreach (var elem in _observerChild)
                {
                    Detach(elem);
                }
                return true;
            }
            return false;
        }
    }

    interface IChangeOperation
    {
        void Attach(EntityChangeObserver observer);
        void Detach(EntityChangeObserver observer);
        bool Clone(EntityChangeObserver observer);
    }

    public class EntityChangeObserver : IEntityChangeObserver
    {
        public int _clientId { get; set; }
        public int _countryId { get; set; }
        public int _buId { get; set; }
        public string _functionName { get; set; }
        public EntityChangeObserver(int clientId, int countryId, int buId, string functionality)
        {
            this._clientId = clientId;
            this._countryId = countryId;
            this._buId = buId;
            this._functionName = functionality;
        }

        public void Update(EntityChangeObserver observer)
        {
        }
    }

    interface IEntityChangeObserver
    {
        void Update(EntityChangeObserver observer);
    }

    public static class EntityChangeObserverMaster
    {
        public static bool DataSetObserver(string functionality, int clientId, int countryId, int buId)
        {
            ChangeOperation subject = new ChangeOperation();
            var entityAttachObserver = new EntityChangeObserver(clientId, countryId, buId, functionality);
            if (Globals.observers.Count(n => n._clientId == entityAttachObserver._clientId && n._countryId == entityAttachObserver._countryId && n._buId == entityAttachObserver._buId && n._functionName == entityAttachObserver._functionName) == 0)
            {
                subject.Attach(entityAttachObserver);
            }
            return true;
        }

        public static bool DataGetObserver(string functionality, int clientId, int countryId, int buId)
        {
            ChangeOperation subject = new ChangeOperation();
            var entityDetachObserver = new EntityChangeObserver(clientId, countryId, buId, functionality);
            return subject.Clone(entityDetachObserver);
        }
    }
}