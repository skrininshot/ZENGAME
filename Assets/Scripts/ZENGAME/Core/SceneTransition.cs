using UnityEngine.SceneManagement;
using Zenject;

namespace ZENGAME.Core
{
    public class SceneTransition : IInitializable
    {
        private GameStateMachine _gameStateMachine;
        private GameStates _transitionNextState;

        public SceneTransition (GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Initialize()
        {
            Scene currentScene = SceneManager.GetActiveScene();

            if (currentScene.name == "SplashScene")
                TransitionToPlay();
            else if (currentScene.name.Contains("MainScene"))
                _gameStateMachine.ChangeState((int)GameStates.Play);
        }
        
        protected void SceneLoaded(Scene scene, LoadSceneMode mode)
        {
            _gameStateMachine.ChangeState((int)_transitionNextState);
            SceneManager.sceneLoaded -= SceneLoaded;
        }

        public void TransitionToPlay()
        {
            _transitionNextState = GameStates.Play;
            _gameStateMachine.ChangeState((int)GameStates.Transition);

            SceneManager.LoadScene("MainScene");
            SceneManager.sceneLoaded += SceneLoaded;
        }
    }
}