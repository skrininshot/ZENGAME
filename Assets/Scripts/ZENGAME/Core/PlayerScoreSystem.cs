namespace ZENGAME.Core
{
    public class PlayerScoreSystem
    {
        public float CurrentScore { get; private set; }
        public float BestScore => SaveSystem.LoadData().bestScore;

        public void SetCurrentScore(float score)
        {
            CurrentScore = score;

            if (!(BestScore < CurrentScore)) return;
            
            SaveData saveData = new()
            {
                bestScore = CurrentScore
            };

            SaveSystem.SaveData(saveData);
        }
    }
}