using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
           new Client[]
               {
                new Client
                {
                ClientId = "catalogClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                new Secret("secret".Sha256())
                },
                AllowedScopes = { "catalogApi" }
                }
                ,new Client
                           {
                           ClientId = "shopping_web",
                           ClientName = "Shopping Web App",
                           AllowedGrantTypes = GrantTypes.Hybrid,
                           RequirePkce=false,
                           AllowRememberConsent = false,
                           RedirectUris = new List<string>()
                           {
                           "https://localhost:5003/signin-oidc"
                           },
                           PostLogoutRedirectUris = new List<string>()
                           {
                           "https://localhost:5003/signout-callback-oidc"
                           },
                           ClientSecrets = new List<Secret>
                           {
                           new Secret("secret".Sha256())
                           },
                           AllowedScopes = new List<string>
                           {
                           IdentityServerConstants.StandardScopes.OpenId,
                           IdentityServerConstants.StandardScopes.Profile,
                           "catalogApi"
                           }
                           }
                  };
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
 {
 new ApiScope("catalogApi","Catalog Api")
 };

        public static IEnumerable<ApiResource> ApiResources =>
         new ApiResource[]
         {
         };
        public static IEnumerable<IdentityResource> IdentityResources =>
         new IdentityResource[]
         {
 new IdentityResources.OpenId(),
 new IdentityResources.Profile()
         };
        public static List<TestUser> TestUsers =>
   new List<TestUser>
   {
            new TestUser
            {
            SubjectId = "5BE86359–073C-434B-AD2D-A3932222DABE",
            Username = "mehmet",
            Password = "mehmet",
            Claims = new List<Claim>
            {
            new Claim(JwtClaimTypes.GivenName, "mehmet"),
            new Claim(JwtClaimTypes.FamilyName, "ozkaya")
            }
            }
   };
    }
}
