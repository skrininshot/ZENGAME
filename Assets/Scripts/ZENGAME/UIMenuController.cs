using System;
using ZENGAME.Core;

namespace ZENGAME
{
    public class UIMenuController
    {
        private readonly UIMenuView _view;
        private readonly PlayerScoreSystem _playerScoreSystem;

        public UIMenuController(UIMenuView view, PlayerScoreSystem playerScoreSystem)
        {
            _view = view;
            _playerScoreSystem = playerScoreSystem;
        }
        
        public void Show()
        {
            var currentScoreFormat = TimeFormat(_playerScoreSystem.CurrentScore);
            var bestScoreFormat = TimeFormat(_playerScoreSystem.BestScore);
            
            _view.Show(currentScoreFormat, bestScoreFormat);
        }
        
        private string TimeFormat(float time)
        {
            TimeSpan t = TimeSpan.FromSeconds(time);
            
            return string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", 
                t.Hours,
                t.Minutes,
                t.Seconds,
                t.Milliseconds);
        }

        public void Hide()
        {
            _view.Hide();
        }
    }
}