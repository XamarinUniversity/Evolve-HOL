using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilationAttribute(XamlCompilationOptions.Compile)]

namespace eXam
{
    public class App : Application
    {
        public static Game CurrentGame { get; private set; }

        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage ( new HomePage() );
        }

        protected override async void OnStart()
        {
            var fileHelper = DependencyService.Get<IFileHelper>();

            var questionsText = await fileHelper.LoadLocalFileAsync("cachedquestions.xml");

            if (string.IsNullOrWhiteSpace(questionsText))
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;

                using (var stream = assembly.GetManifestResourceStream("eXam.Data.questions.xml"))
                {
                    questionsText = new StreamReader(stream).ReadToEnd();
                }

                await fileHelper.SaveLocalFileAsync("cachedquestions.xml", questionsText);
            }

            var questions = QuizQuestionXmlSerializer.Deserialize(questionsText);
            CurrentGame = new Game(questions);

            if (CrossConnectivity.Current.IsConnected)
                Debug.WriteLine("Connected");
            else
                Debug.WriteLine("Not connected");
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
