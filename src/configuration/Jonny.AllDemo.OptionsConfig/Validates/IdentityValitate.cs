using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jonny.AllDemo.OptionsConfig
{
    public class IdentityValitate : IValidateOptions<IdentityClientOption>
    {
        public ValidateOptionsResult Validate(string name, IdentityClientOption options)
        {
            if (options.GrantType=="password")
            {
                return ValidateOptionsResult.Success;
            }
            return ValidateOptionsResult.Fail("验证方式不是password模式");
        }
    }
}
