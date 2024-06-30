using System;
using UnityEngine;

namespace GamePlay
{
    public class LineRendererBetweenPoints : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;

        private int _index = 0;
        private int _countCurenntButton;
        private int _maxCurrentButtons = 1;
        public event Action OnLevelCompleted;
        
        public event Action OnClick;

        public void ClickCurrentButton(RectTransform rectTransform, bool IsButtonActive)
        {
            var startPosition = _lineRenderer.GetPosition(0);

            if (rectTransform.position == startPosition && _countCurenntButton == _maxCurrentButtons - 1)
            {
                _countCurenntButton++;
            }
            else if (!IsButtonActive)
            {
                _countCurenntButton++;
                SetPosition(rectTransform);
                OnClick?.Invoke();
            }

            if (_countCurenntButton == _maxCurrentButtons)
                OnLevelCompleted?.Invoke();
        }

        public void AddMaxCurrentButtons()
        {
            _maxCurrentButtons++;
        }

        public void ClickNonCorrentButton(RectTransform rectTransform)
        {
            _countCurenntButton--;
            OnClick?.Invoke();
            SetPosition(rectTransform);
        }

        public void Clear()
        {
            _lineRenderer.positionCount = 0;
            _index = 0;
            _maxCurrentButtons = 1;
            _countCurenntButton = 0;
        }


        private void SetPosition(RectTransform rectTransform)
        {
            _lineRenderer.positionCount++;
            _lineRenderer.SetPosition(_index, rectTransform.position);
            _index++;
        }
    }
}