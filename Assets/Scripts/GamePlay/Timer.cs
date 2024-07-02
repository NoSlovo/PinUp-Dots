using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private Image _stars;
        [Header("Stars")]
        [SerializeField] private List<Sprite> _starsSprites;

        private int _initStarIndex = 2;
        private float startTime;
        private float remainingTime;
        private float interval;
        private bool isRunning;
        private float _actionTime;

        public event Action OnEnd;

        private void Update()
        {
            if (isRunning)
            {
                startTime -= Time.deltaTime;
                if (startTime <= 0)
                {
                    startTime = 0;
                    isRunning = false;
                    OnEnd?.Invoke();
                }

                UpdateTimerDisplay(startTime);
                if (startTime <= _actionTime)
                {
                    Debug.Log(interval);
                    RemoveSrar();
                    _actionTime -= interval;
                }
            }
        }

        public void InitTimer(float time)
        {
            startTime = time;
            isRunning = true;
            interval = startTime / 3;
            _actionTime = startTime - interval;
            _stars.sprite =_starsSprites[3];
            Debug.Log(_actionTime);
        }

        public void StopTimer()
        {
            isRunning = false;
        }

        public void ContinueTimer()
        {
            isRunning = true;
        }

        public void ResetTimer()
        {
            isRunning = false;
            remainingTime = startTime;
            UpdateTimerDisplay(remainingTime);
        }

        void UpdateTimerDisplay(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60F);
            int seconds = Mathf.FloorToInt(time % 60F);
            timerText.text = $"{minutes}:{seconds}";
        }

        private void RemoveSrar()
        {
            if (_initStarIndex <= 0)
            {
                _stars.sprite = _starsSprites[0];
                return;
            }
            _stars.sprite = _starsSprites[_initStarIndex];
            _initStarIndex --;
        }
    }
}