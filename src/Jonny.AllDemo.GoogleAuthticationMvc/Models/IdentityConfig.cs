using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jonny.AllDemo.GoogleAuthticationMvc.Models
{
    public class IdentityConfig
    {
        // 定义Scopes支持
        public static IEnumerable<IdentityResource> Ids =>
            new List<IdentityResource>
            {
                new IdentityResources.Email(),
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
                new ApiResource("cyapi","重庆城银科技api")
            };
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client()
                {                    
                    //城银的微服务客户端请求认证都采用这个ClientId
                    ClientId = "cy.cloud",
                    ClientName="cy.cloud",
                    ClientSecrets = { new Secret("cy.secrets".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    RequireConsent=false,
                    RequirePkce=true,
                    // where to redirect to after login
                    RedirectUris = { "https://googlemvc.utools.club/signin-oidc" },
                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://googlemvc.utools.club/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }


                    //详情文档：https://identityserver4-zh-cn.readthedocs.io/zh_CN/release/topics/refresh_tokens.html
                }
            };
    }
}
