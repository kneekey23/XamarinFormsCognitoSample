using System;

using Xamarin.Forms;

namespace FormsAWSDemo
{
    public class Login : ContentPage
    {
        Entry usernameEntry, passwordEntry;
        Label messageLabel;

        public Login()
        {
            usernameEntry = new Entry
            {
                Placeholder = "username"
            };
            passwordEntry = new Entry
            {
                IsPassword = true
            };
            var loginButton = new Button
            {
                Text = "Login"
            };
            loginButton.Clicked += OnLoginButtonClicked;

            Title = "Login";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = {
                    new Label { Text = "Username" },
                    usernameEntry,
                    new Label { Text = "Password" },
                    passwordEntry,
                    loginButton,
                    messageLabel
                }
            };
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string Username = usernameEntry.Text;
            string Password = passwordEntry.Text;

            string accessToken = await CognitoIdentityAuth.AuthenticateWithSrpAsync(Username, Password);

            if(String.IsNullOrEmpty(accessToken))
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

