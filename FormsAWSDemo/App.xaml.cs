using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Amazon;
using Amazon.Util;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FormsAWSDemo
{
    public partial class App : Application
    {
        public App()
        {
            var loggingConfig = AWSConfigs.LoggingConfig;
            loggingConfig.LogMetrics = true;
            loggingConfig.LogResponses = ResponseLoggingOption.Always;
            loggingConfig.LogMetricsFormat = LogMetricsFormatOption.JSON;
            loggingConfig.LogTo = LoggingOptions.SystemDiagnostics;

            AWSConfigs.AWSRegion = "us-east-1";
            AWSConfigs.AWSProfileName = "default";

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
