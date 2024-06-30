using Screens;
using UnityEngine;

public class ScreenManager : MonoBehaviour, IScreenService
{
    [SerializeField] private MenuScreen _menu;
    [SerializeField] private LevelWindow _levelScreen;
    [SerializeField] private AchievementsWindow _achievements;
    [SerializeField] private SettingsWindow _settingsScreen;
    [SerializeField] private GameScreen _gameScreen;

    private BaseScreen.BaseScreen _activeScreen;

    private void Start() => OpenScreen(_menu);


    public void OpenScreenMenu() => OpenScreen(_menu);


    public void OpenScreenLevel() => OpenScreen(_levelScreen);


    public void OpenScreenAchievements() => OpenScreen(_achievements);

    public void OpenScreenSettings() => OpenScreen(_settingsScreen);

    public void OpenScreenGame()
    {
        _gameScreen.InitGame();
        _gameScreen.gameObject.SetActive(true);
        _activeScreen.gameObject.SetActive(false);
    } 


    private void OpenScreen(BaseScreen.BaseScreen screen)
    {
        var instantiateScreen = Instantiate(screen, transform);
        _activeScreen?.Close();
        _activeScreen = instantiateScreen;
        _activeScreen.GetScreenService(this);
        _activeScreen.Open();
    }
}

public interface IScreenService
{
    public void OpenScreenMenu();
    public void OpenScreenLevel();
    public void OpenScreenAchievements();
    public void OpenScreenSettings();

    public void OpenScreenGame();
}