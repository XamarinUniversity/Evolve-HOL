using System.ComponentModel;
using Xamarin.Forms;

namespace eXam
{
    public class QuestionPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command TrueSelected { get; set; }
        public Command FalseSelected { get; set; }
        public Command NextSelected { get; set; }

        public string Question { get { return game.CurrentQuestion.Question; } }
        public string Response
        {
            get
            {
                if (game.CurrentResponse == null)
                    return string.Empty;

                if (game.CurrentResponse == game.CurrentQuestion.Answer)
                    return "Correct";
                else
                    return "Incorrect";
            }
        }

        public bool IsTrueFalseEnabled
        {
            get
            {
                return game.CurrentResponse == null;
            }
        }

        Game game;

        public QuestionPageViewModel (Game game)
        {
            this.game = game;

            game.Restart();

            TrueSelected = new Command(OnTrue);
            FalseSelected = new Command(OnFalse);
            NextSelected = new Command(OnNext, OnCanExecuteNext);
        }

        void RaiseAllPropertiesChanged ()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(""));
        }

        void OnTrue ()
        {
            game.OnTrue();
            RaiseAllPropertiesChanged();

            NextSelected.ChangeCanExecute();
        }

        void OnFalse()
        {
            game.OnFalse();
            RaiseAllPropertiesChanged();

            NextSelected.ChangeCanExecute();
        }

        async void OnNext()
        {
            if (game.NextQuestion() == true)
            {
                NextSelected.ChangeCanExecute();
                RaiseAllPropertiesChanged();
            }
            else
            {
                var nav = DependencyService.Get<NavigationService>();
                if (nav != null)
                    await nav.GotoPageAsync(AppPage.ReviewPage);
            }
        }

        bool OnCanExecuteNext()
        {
            if (game.CurrentResponse == null)
                return false;
            else
                return true;
        }
    }
}