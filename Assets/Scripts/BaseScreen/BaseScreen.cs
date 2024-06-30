using UnityEngine;

namespace BaseScreen
{
    public class BaseScreen : MonoBehaviour
    {
        protected IScreenService ScreenService;

        public void GetScreenService(IScreenService screenService) => ScreenService = screenService;

        public virtual void Open()
        {
        }

        public virtual void Close()
        {
            Destroy(gameObject);
        }
    }
}