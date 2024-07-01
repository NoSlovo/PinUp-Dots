using TMPro;
using UnityEngine;

namespace GamePlay
{
    public class Timer : MonoBehaviour
    {
        public TextMeshProUGUI timerText;
        public float startTime = 30f; // Начальное время в секундах
        private float remainingTime;
        private bool isRunning;

        void Start()
        {
            ResetTimer();
        }

        void Update()
        {
            if (isRunning)
            {
                remainingTime -= Time.deltaTime;
                if (remainingTime <= 0)
                {
                    remainingTime = 0;
                    isRunning = false;
                    // Можно добавить здесь дополнительное действие по окончанию таймера
                    // Например, вызвать метод, оповестить игрока и т.д.
                }

                UpdateTimerDisplay(remainingTime);
            }
        }

        public void StartTimer()
        {
            isRunning = true;
        }

        public void StopTimer()
        {
            isRunning = false;
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
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}