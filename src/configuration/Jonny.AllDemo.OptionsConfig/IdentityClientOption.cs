using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jonny.AllDemo.OptionsConfig
{
    public class IdentityClientOption
    {
        public string GrantType { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Authority { get; set; }
        public string Scope { get; set; }

        public override string ToString()
        {
            return $"GrantType:{GrantType},ClientId:{ClientId},ClientSecret:{ClientSecret},UserName:{UserName},UserPassword:{UserPassword},Authority:{Authority},Scope:{Scope}";
        }
    }
}
