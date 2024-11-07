namespace Platformer
{
    public class UpdateScoreCommand : IUICommand
    {
        public int NewScore;

        public UpdateScoreCommand(int NewScore)
        {
            this.NewScore = NewScore;
        }
    }
}
