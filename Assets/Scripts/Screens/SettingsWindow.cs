using System;
using Configs;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class SettingsWindow : BaseScreen.BaseScreen
    {
        [SerializeField] private SettingsButton _settingsButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private GameSettings _settingsData;
        [SerializeField] private Sprite _imageActive;
        [SerializeField] private Sprite _imageDisable;

        private bool _activeSound;
        private bool _activeMusic;
        private bool _activeNorifaction;

        private void Awake()
        {
            var value = _settingsData.LoadData();
            SetImageButton(value);
            _activeSound = value.Item2;
            _activeMusic = value.Item1;
        }

        private void SetImageButton((bool, bool) value)
        {
            if (value.Item1)
                _settingsButton.ImageButtonSound.sprite = _imageActive;

            else
                _settingsButton.ImageButtonSound.sprite = _imageDisable;


            if (value.Item2)
                _settingsButton.ImageButtonMusic.sprite = _imageActive;

            else
                _settingsButton.ImageButtonMusic.sprite = _imageDisable;
        }

        private void OnEnable()
        {
            _settingsButton.ActiveMusic.onClick.AddListener(SwitchMusic);
            _settingsButton.ActiveSound.onClick.AddListener(SwitchSound);
            _settingsButton.Norifaction.onClick.AddListener(SwitchNorifaction);
        }

        private void Start()
        {
            _backButton.onClick.AddListener(ScreenService.OpenScreenMenu);
        }

        private void SwitchMusic()
        {
            _activeMusic = !_activeMusic;
            _settingsButton.ImageButtonMusic.sprite = _activeMusic ? _imageActive : _imageDisable;
            _settingsData.SetValueMusicActive(_activeMusic);
        }

        private void SwitchSound()
        {
            _activeSound = !_activeSound;
            _settingsButton.ImageButtonSound.sprite = _activeSound ? _imageActive : _imageDisable;
            _settingsData.SetValueSaundsActive(_activeSound);
        }

        public void SwitchNorifaction()
        {
        }


        private void OnDisable()
        {
            _settingsButton.ActiveMusic.onClick.RemoveListener(SwitchMusic);
            _settingsButton.ActiveSound.onClick.RemoveListener(SwitchSound);
            _settingsButton.Norifaction.onClick.RemoveListener(SwitchNorifaction);
        }
    }

    [Serializable]
    public struct SettingsButton
    {
        public Button ActiveSound;
        public Image ImageButtonSound;
        public Button ActiveMusic;
        public Image ImageButtonMusic;
        public Button Norifaction;
        public Image ImageButtonNorifaction;
    }
}