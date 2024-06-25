using UnityEngine;

public class ScreenMenager : MonoBehaviour
{
    [SerializeField] private MenuScreen _menu;
    [SerializeField] private LevelWindow _levelScreen;
    [SerializeField] private StoreWindow _store;
    [SerializeField] private AchievementsWindow _achievements;


    private BaseScreen _activeScreen;

    private void Start() => OpenScreen(_menu);
    
    private void OpenScreen(BaseScreen _screen)
    {
        var instantiateScreen = Instantiate(_screen, transform);
    }
}