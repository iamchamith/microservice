using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Identity
{
    public static class IdentityConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
         {
             new ApiResource("fiver_auth_api", "Fiver.Security.AuthServer.Api")
         };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
         {
             new IdentityResources.OpenId(),
             new IdentityResources.Profile(),
         };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
         {
             new Client
             {
                 ClientId = "amazon_item",
                 ClientName = "Amazon.Security.Item",
                 ClientSecrets = { new Secret("secret".Sha256()) },

                 AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                 AllowOfflineAccess = true,
                 RequireConsent = false,

                 RedirectUris = { "http://localhost:5002/signin-oidc" },
                 PostLogoutRedirectUris =
                   { "http://localhost:5002/signout-callback-oidc" },

                 AllowedScopes =
                 {
                     IdentityServerConstants.StandardScopes.OpenId,
                     IdentityServerConstants.StandardScopes.Profile,
                     "item_auth_api"
                 },
             }, new Client
             {
                 ClientId = "amazon_order",
                 ClientName = "Amazon.Security.Order",
                 ClientSecrets = { new Secret("secret".Sha256()) },

                 AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                 AllowOfflineAccess = true,
                 RequireConsent = false,

                 RedirectUris = { "http://localhost:5002/signin-oidc" },
                 PostLogoutRedirectUris =
                   { "http://localhost:5002/signout-callback-oidc" },

                 AllowedScopes =
                 {
                     IdentityServerConstants.StandardScopes.OpenId,
                     IdentityServerConstants.StandardScopes.Profile,
                     "order_auth_api"
                 },
             }
         };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
         {
             new TestUser
             {
                 SubjectId = "1",
                 Username = "james",
                 Password = "password",
                 Claims = new List<Claim>
                 {
                     new Claim("name", "James Bond"),
                     new Claim("website", "https://james.com")
                 }
             }
         };
        }
    }
}
