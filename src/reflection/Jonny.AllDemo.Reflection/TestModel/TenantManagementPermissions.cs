using System;
using System.Collections.Generic;
using System.Text;

namespace Jonny.AllDemo.Reflection.TestModel
{
    public class TenantManagementPermissions
    {
        public const string GroupName = "AbpTenantManagement";

        protected static class Tenants
        {
            public const string Default = GroupName + ".Tenants";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
            public const string ManageFeatures = Default + ".ManageFeatures";
            public const string ManageConnectionStrings = Default + ".ManageConnectionStrings";
        }

        public enum Struct
        {
            A
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(TenantManagementPermissions));
        }
    }
}
