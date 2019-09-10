using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using IdentityModel.Client;
using System.Net.Http;

namespace TestApi_Front.Helper
{
    public class OAuth
    {
        public static string Authenticate(string clientId, string secretKey)
        {
            var tokenClient = new TokenClient("https://dafateridentity-test.azurewebsites.net/connect/token",
                clientId, 
                secretKey);

            var tokenResponse = tokenClient.RequestClientCredentialsAsync("SystemAPI.Document.Write").Result;
            if (tokenResponse.IsError)                            
                return string.Empty;            

            return tokenResponse.AccessToken;            
        }
    }
}