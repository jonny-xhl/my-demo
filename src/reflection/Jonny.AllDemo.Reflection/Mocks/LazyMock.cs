using System;
using System.Collections.Generic;
using System.Text;

namespace Jonny.AllDemo.Reflection.Mocks
{
    public class LazyMock
    {
        private readonly Lazy<TestModel.TenantManagementPermissions> _lazy;
        public LazyMock()
        {
            _lazy = new Lazy<TestModel.TenantManagementPermissions>(Get, System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public TestModel.TenantManagementPermissions TenantManagement => _lazy.Value;

        private TestModel.TenantManagementPermissions Get()
        {
            return new TestModel.TenantManagementPermissions();
        }
    }
}
