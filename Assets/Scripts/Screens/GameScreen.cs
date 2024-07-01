using GamePlay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private PauseScreen _pauseScreen;
        [SerializeField] private LevelCompliteScreen _gameWinScreen;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private FoatConfigs foatConfigs;
        [SerializeField] private RectTransform _foatInstanceContainer;
        [SerializeField] private TextMeshProUGUI _levelNumber;
        [SerializeField] private ScreenManager _screenManager;
        [SerializeField] private TextMeshProUGUI _ValueLevel;
        [SerializeField] private Image _paternImage;

        private LineRenderer _lineRenderer;
        private int _levelId = 0;
        private BaseConfig _activePole;
        private PauseScreen _pauseScreenInstance;
        private int _buttonClickValue = 0;
        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(OpenPauseScreen);
        }

        public void InitGame()
        {
            if (_activePole != null)
                Destroy(_activePole.gameObject);
            
            _activePole = Instantiate(foatConfigs.GetConfigs(_levelId).Prefab, _foatInstanceContainer);
            _activePole.LineRendererBetween.OnLevelCompleted += OpenScreenWin;
            _activePole.LineRendererBetween.OnClick += AddValue;
            _paternImage.sprite = foatConfigs.GetConfigs(_levelId).PaternImage;
            _activePole.Close();
            _ValueLevel.text = $"{0}";
            _buttonClickValue =  0;
            _levelNumber.text = $"{_levelId + 1}";
            _pauseScreenInstance?.Close();
            _activePole.Init();
            gameObject.SetActive(false);
        }

        public void OpenNextLevel()
        {
            _levelId++;
            Debug.Log($"{_levelId} Вызов");
        }

        private void OpenScreenWin()
        {
            _activePole.ActiveAchigment();
          var winScreen = Instantiate(_gameWinScreen);
          winScreen.GetScreenServices(_screenManager,this);
        }

        private void OpenPauseScreen()
        {
            _pauseScreenInstance = Instantiate(_pauseScreen);
            _pauseScreenInstance.Init(_screenManager);
        }

        private void AddValue()
        {
            _buttonClickValue += 10;
            _ValueLevel.text = $"{_buttonClickValue}";
        }

        private void OnDisable()
        {
            _pauseButton.onClick.RemoveListener(OpenPauseScreen);
        }
    }
}