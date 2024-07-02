using Configs;
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
        [SerializeField] private FoatConfigs _foatConfigs;
        [SerializeField] private RectTransform _foatInstanceContainer;
        [SerializeField] private TextMeshProUGUI _levelNumber;
        [SerializeField] private ScreenManager _screenManager;
        [SerializeField] private TextMeshProUGUI _ValueLevel;
        [SerializeField] private Image _paternImage;
        [SerializeField] private Timer _timer;
        [SerializeField] private GameEndScreen _gameAndScreen;
        [SerializeField] private Image _resultImage;
        [SerializeField] private AudioSource _source;
        [SerializeField] private GameSettings _gameSettings;

        private LineRenderer _lineRenderer;
        private int _levelId = 0;
        private BaseConfig _activePole;
        private PauseScreen _pauseScreenInstance;
        private GameEndScreen _endScreen;
        private int _buttonClickValue = 0;

        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(OpenPauseScreen);
            _timer.OnEnd += OpenEndScreen;
        }

        public void InitGame()
        {
            if (_activePole != null)
                Destroy(_activePole.gameObject);
            if (_endScreen != null)
                Destroy(_endScreen.gameObject);

            if (_gameSettings.MusicActive)
                _source.Play();
            else
                _source.mute = !_gameSettings.MusicActive;


            _activePole = Instantiate(_foatConfigs.GetConfigs(_levelId).Prefab, _foatInstanceContainer);
            _activePole.LineRendererBetween.OnLevelCompleted += OpenScreenWin;
            _activePole.LineRendererBetween.OnClick += AddValue;
            _timer.InitTimer(_foatConfigs.GetConfigs(_levelId).Time);
            _paternImage.sprite = _foatConfigs.GetConfigs(_levelId).PaternImage;
            _activePole.Close();
            _ValueLevel.text = $"{0}";
            _buttonClickValue = 0;
            _levelNumber.text = $"{_levelId + 1}";
            _pauseScreenInstance?.Close();
            _activePole.Init();
            gameObject.SetActive(false);
        }

        public void OpenNextLevel()
        {
            _levelId++;
            _timer.ResetTimer();
        }

        private void OpenEndScreen()
        {
            _endScreen = Instantiate(_gameAndScreen, transform);
            _endScreen.Construct(_screenManager, this);
            _source.Stop();
        }

        private void OpenScreenWin()
        {
            _foatConfigs.SaveResult(_levelId, _resultImage.sprite);
            _activePole.ActiveAchigment();
            _source.Stop();
            var winScreen = Instantiate(_gameWinScreen);
            winScreen.GetScreenServices(_screenManager, this);
        }

        private void OpenPauseScreen()
        {
            _pauseScreenInstance = Instantiate(_pauseScreen);
            _pauseScreenInstance.OnOpen += _timer.StopTimer;
            _pauseScreenInstance.OnOpen += _source.Stop;
            _pauseScreenInstance.Init(_screenManager);
            _pauseScreenInstance.OnClose += _timer.ContinueTimer;

            if (_gameSettings.MusicActive)
                _pauseScreenInstance.OnClose += _source.Play;
        }

        private void AddValue()
        {
            _buttonClickValue += 10;
            _ValueLevel.text = $"{_buttonClickValue}";
        }

        private void OnDisable()
        {
            _pauseButton.onClick.RemoveListener(OpenPauseScreen);
            _timer.OnEnd -= OpenEndScreen;
        }
    }
}