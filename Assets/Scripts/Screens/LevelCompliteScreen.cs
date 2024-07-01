using System;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class LevelCompliteScreen : MonoBehaviour
    {
        [SerializeField] private Image _imageResult;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Button _levels;
        
        private GameScreen  _gameScreen;
        private IScreenService _screenService;

        private void OnEnable()
        {
            _nextLevelButton.onClick.AddListener(NextLevel);
            _levels.onClick.AddListener(OpenLevelsScreen);
            _restartButton.onClick.AddListener(Restart);
        }

        public void GetScreenServices(IScreenService screenService,GameScreen gameScreen)
        {
            _screenService = screenService;
            _gameScreen = gameScreen;
        }

        private void OpenLevelsScreen()
        {
            _screenService.OpenScreenLevel();
            Destroy(gameObject);
        }

        private void Restart()
        {
            _screenService.OpenScreenGame();
            Destroy(gameObject);
        }

        private void NextLevel()
        {
            _gameScreen.OpenNextLevel();
            _screenService.OpenScreenGame();
            Destroy(gameObject);
        }

        private void OnDisable()
        {
            _nextLevelButton.onClick.RemoveListener(NextLevel);
            _levels.onClick.RemoveListener(OpenLevelsScreen);
            _restartButton.onClick.RemoveListener(Restart);
        }
    }
}