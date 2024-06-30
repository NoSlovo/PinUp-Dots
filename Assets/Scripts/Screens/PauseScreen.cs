using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class PauseScreen : MonoBehaviour
    {
        [SerializeField] private Button _buttonBackMenu;
        [SerializeField] private Button _buttonResume;
        [SerializeField] private Button _restartButton;
        
        private IScreenService _screenService;
        public void Init(IScreenService screenService)
        {
            _screenService = screenService;
            _buttonBackMenu.onClick.AddListener(_screenService.OpenScreenMenu);
            _buttonResume.onClick.AddListener(Close);
            _restartButton.onClick.AddListener(_screenService.OpenScreenGame);
        }

        public void Close()
        {
            _buttonBackMenu.onClick.RemoveListener(_screenService.OpenScreenMenu);
            _buttonResume.onClick.RemoveListener(Close);
            _restartButton.onClick.RemoveListener(_screenService.OpenScreenGame);
            Destroy(gameObject);  
        } 
    }
}