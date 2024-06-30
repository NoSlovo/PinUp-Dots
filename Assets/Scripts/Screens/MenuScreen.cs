using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class MenuScreen : BaseScreen.BaseScreen
    {
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _AchievementsOpenButton;
        [SerializeField] private Button _levelsOpenButton;

        public override void Open()
        {
            _settingsButton.onClick.AddListener(ScreenService.OpenScreenSettings);
            _AchievementsOpenButton.onClick.AddListener(ScreenService.OpenScreenAchievements);
            _levelsOpenButton.onClick.AddListener(ScreenService.OpenScreenLevel);
        }
    }
}
