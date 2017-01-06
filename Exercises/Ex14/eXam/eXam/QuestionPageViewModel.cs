namespace eXam
{
    public class QuestionPageViewModel
    {
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

        Game game;

        public QuestionPageViewModel (Game game)
        {
            this.game = game;

            game.Restart();
        }
    }
}