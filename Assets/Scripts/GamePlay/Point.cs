using System;
using Configs;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class Point : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Button _button;
        [SerializeField] private Sprite _spriteActive;
        [SerializeField] private Image _image;
        [SerializeField] private AudioSource _clickSound;
        [SerializeField] private GameSettings _gameSettings;

        private int _id;
        private bool _isActive = false;
        public event Action<RectTransform, bool> OnСorrectButtonPressed;
        public event Action<RectTransform> OnWrongButtonPressed;

        private void Start() => _button.onClick.AddListener(ClickInvoke);

        private void ClickInvoke()
        {
            if (_gameSettings.LoadData().Item1)
                _clickSound.Play();

            else
                _clickSound.mute = !_gameSettings.LoadData().Item1;

            _image.sprite = _spriteActive;
            OnСorrectButtonPressed?.Invoke(_rectTransform, _isActive);
            OnWrongButtonPressed?.Invoke(_rectTransform);
        }
    }
}