using System;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using System.Threading.Tasks;
using Amazon.CognitoIdentity;
using Amazon;
using Amazon.Runtime;

namespace FormsAWSDemo
{
    public static class CognitoIdentityAuth
    {
        static string clientId = "7f9metrrf0spd50ume1t0eiclk";
        static string userPoolId = "us-east-1_2jietfDQk";
        static string identityPoolId = "us-east-1:4593e367-faee-4e3f-ba91-1f35eeb4b70e";

        public static async Task<string> AuthenticateWithSrpAsync(string username, string password)
        {
            Console.WriteLine("Test");

            AmazonCognitoIdentityProviderClient provider = new AmazonCognitoIdentityProviderClient(FallbackRegionFactory.GetRegionEndpoint());

            CognitoUserPool userPool = new CognitoUserPool(userPoolId, clientId, provider);
            CognitoUser user = new CognitoUser(username, clientId, userPool, provider);


            AuthFlowResponse context = await user.StartWithSrpAuthAsync(new InitiateSrpAuthRequest
            {
                Password = password
            }).ConfigureAwait(false);

            return context.AuthenticationResult.AccessToken;
        }

        public static CognitoAWSCredentials GetIdentityPoolCredentials(string accesstoken)
        {

            
            CognitoAWSCredentials credentials = new CognitoAWSCredentials(
                 identityPoolId, // Identity pool ID
                    RegionEndpoint.USEast1 // Region
            );
            credentials.AddLogin("Cognito", accesstoken);


            return credentials;
            
        }
    }
}
