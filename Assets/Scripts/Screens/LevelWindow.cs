using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class LevelWindow : BaseScreen.BaseScreen
    {
        [SerializeField] private Button _buttonBack;

        private void Start()
        {
            _buttonBack.onClick.AddListener(ScreenService.OpenScreenMenu);
        }
    }
}