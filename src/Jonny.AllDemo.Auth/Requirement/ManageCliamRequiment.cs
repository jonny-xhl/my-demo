using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Jonny.AllDemo.Auth.Requirement
{
    public class ManageCliamRequiment : AuthorizationHandler<ManageCliamRequiment>,
        IAuthorizationRequirement
    {
        public ManageCliamRequiment() { }
        private readonly ICustomAuthenticationManager _authenticationManager;
        public ManageCliamRequiment(ICustomAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageCliamRequiment requirement)
        {
            // TODO 自定义策略授权
            if (true)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }        
    }
}
