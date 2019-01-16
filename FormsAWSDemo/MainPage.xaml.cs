using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsAWSDemo
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string Username = usernameEntry.Text;
            string Password = passwordEntry.Text;

            string accessToken = await CognitoIdentityAuth.AuthenticateWithSrpAsync(Username, Password).ConfigureAwait(false);

            if (String.IsNullOrEmpty(accessToken))
            {
                var credentials = CognitoIdentityAuth.GetIdentityPoolCredentials(accessToken);
                Console.WriteLine(credentials.IdentityPoolId);

                //use credentials to call Lambda or any AWS service here
                //go to next page or do whatever
                // await Navigation.PopAsync();

            }

        }
    }
}
