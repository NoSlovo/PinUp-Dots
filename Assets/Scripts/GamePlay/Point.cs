using System;
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

        private int _id;
        private bool _isActive = false;
        public event Action<RectTransform, bool> OnСorrectButtonPressed;
        public event Action<RectTransform> OnWrongButtonPressed;

        private void Start() => _button.onClick.AddListener(ClickInvoke);

        private void ClickInvoke()
        {
            _image.sprite = _spriteActive;
            OnСorrectButtonPressed?.Invoke(_rectTransform,_isActive);
            OnWrongButtonPressed?.Invoke(_rectTransform);
        }
    }
}