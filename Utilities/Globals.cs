using DotnetCore.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Common.Utils
{
    public class Globals
    {
        public static List<EntityChangeObserver> observers = new List<EntityChangeObserver>();
        public static T SetAddDefaultPageValue<T>(T sourceObject, int createdby = 0)
        {
            Type sourceType = sourceObject.GetType();
            //  Loop through the source properties
            foreach (PropertyInfo p in sourceType.GetProperties().Where(k => k.Name == "UniqueId" || k.Name == "IsDeleted" ))
            {
                //  Get the matching property in the destination object
                string name = p.Name;
                switch (name)
                {
                    case "UniqueId":
                        p.SetValue(sourceObject, Guid.NewGuid());
                        break;
                    case "IsDeleted":
                        p.SetValue(sourceObject, false);
                        break;
                }
            }
            return (T)sourceObject;
        }

        public static T SetModifyDefaultPageValue<T>(T sourceObject, bool status = true, int updatedby = 0)
        {
            Type sourceType = sourceObject.GetType();

            //  Loop through the source properties
            foreach (PropertyInfo p in sourceType.GetProperties().Where(k => k.Name == "UpdatedBy" || k.Name == "UpdatedDate" || k.Name == "Status"))
            {
                //  Get the matching property in the destination object
                string name = p.Name;
                switch (name)
                {
                    case "UpdatedBy":
                        p.SetValue(sourceObject, updatedby.ToString());
                        break;
                    case "UpdatedDate":
                        p.SetValue(sourceObject, DateTime.Now);
                        break;
                    case "Status":
                        p.SetValue(sourceObject, status);
                        break;
                }
            }
            return (T)sourceObject;
        }

    }
}