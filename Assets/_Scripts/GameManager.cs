using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private CoinCounterUI coinCounter;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private InputManager inputManager;

    private bool isSettingsMenuActive;

    //Creates public getter for the bool
    //So that the variable is read only without making it public
    public bool IsSettingsMenuActive => isSettingsMenuActive;

    protected override void Awake()
    {
        base.Awake();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        inputManager.OnSettingsMenu.AddListener(ToggleSettingsMenu);

        //Start game with settings menu disabled
        DisableSettingsMenu();
    }

    private void ToggleSettingsMenu()
    {
        if (isSettingsMenuActive) DisableSettingsMenu();
        else EnableSettingsMenu();
    }

    private void EnableSettingsMenu()
    {
        Time.timeScale = 0f;
        settingsMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isSettingsMenuActive = true;
    }  
    public void DisableSettingsMenu()
    {
        Time.timeScale = 1f;
        settingsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isSettingsMenuActive = false;
    }

    public void QuitGame() {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void IncreaseScore()
    {
        score++;
        coinCounter.UpdateScore(score);
    }
}
