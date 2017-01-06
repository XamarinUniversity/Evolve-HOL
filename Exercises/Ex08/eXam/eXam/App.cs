using System;
using System.Collections.Generic;
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

        protected override void OnStart()
        {
            // Handle when your app starts
            var assembly = typeof(App).GetTypeInfo().Assembly;

            string questionText;

            using (var stream = assembly.GetManifestResourceStream("eXam.Data.questions.xml"))
            {
                questionText = new StreamReader(stream).ReadToEnd();
            }

            var questions = QuizQuestionXmlSerializer.Deserialize(questionText);

            CurrentGame = new Game(questions);
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
