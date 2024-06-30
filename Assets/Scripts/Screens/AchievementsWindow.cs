using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class AchievementsWindow : BaseScreen.BaseScreen
    {
        [SerializeField] private Button _buttonBack;
        [SerializeField] private AchigmentsConfig _configsAchigments;

        private void Start()
        {
            _buttonBack.onClick.AddListener(ScreenService.OpenScreenMenu);
        }
    }
}