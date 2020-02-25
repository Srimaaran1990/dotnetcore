using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Common
{
    namespace Common.Utils
    {
        public static class Util
        {
            public static string GetMemberName<T>(Expression<Func<T>> propertyExpression)
            {
                return (propertyExpression.Body as MemberExpression).Member.Name;
            }

            public static string GetMemberNameExtra<T, V>(Expression<Func<T, V>> propertyExpression)
            {
                return (propertyExpression.Body as MemberExpression).Member.Name;
            }

            public static Object GetPropertyValueByName<T>(Object objWithProperties, String name)
            {
                Type t = typeof(T);
                PropertyInfo p = t.GetProperty(name);

                return p.GetValue(objWithProperties);
            }

            public static string GetPropertyValue<T>(object objWithProperties, string name)
            {

                try
                {
                    return objWithProperties.GetType().GetProperty(name).GetValue(objWithProperties, null) as string;
                }
                catch { return null; }
            }

            /// <summary>
            /// </summary>
            /// <typeparam name = "T"></typeparam>
            /// <typeparam name = "U"></typeparam>
            /// <param name = "expression"></param>
            /// <returns></returns>
            public static MemberInfo GetMemberInfo<T, U>(Expression<Func<T, U>> expression)
            {
                var member = expression.Body as MemberExpression;
                if (member != null)
                    return member.Member;

                throw new ArgumentException("Expression is not a member access", "expression");
            }

            public static Dictionary<string, object> ReadPropertyValue<T>(T item) where T : new()
            {
                Dictionary<string, object> resultReturn = new Dictionary<string, object>();
                PropertyInfo[] properties = item.GetType().GetProperties();
                // Just grabbing this to get hold of the type name:
                Type sourceType = item.GetType();
                // Get the PropertyInfo object:
                foreach (PropertyInfo property in sourceType.GetProperties())
                {
                    if (Attribute.GetCustomAttribute(property, typeof(KeyAttribute)) as KeyAttribute == null)
                        resultReturn.Add(property.Name, property.GetValue(item));
                }
                return resultReturn;
            }

            public static string[] GetInternalReferenceNumberFromUserID(string UserIDs)
            {
                var ListofInternalRefNos = UserIDs.Split(',');  //Split the comma Seperated UserIDs
                string[] InternalRefNos = new string[ListofInternalRefNos.Length];
                int NoOrUsers = 0;
                foreach (var User in ListofInternalRefNos)
                {
                    var bifurcatedUserID = User.Split('~');
                    InternalRefNos[NoOrUsers++] = bifurcatedUserID[3];      //Assign the InternalRefNo to return as string array
                }
                return InternalRefNos;
            }

            public static string[] GetOrgStructDataFromOrgStructField(string OrgStructField)
            {
                var ListofOrgStructureData = OrgStructField.Split('-');  //Split the comma Seperated UserIDs         
                return ListofOrgStructureData;
            }
        }
    }

}
