using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject panelMainMenu;
    [SerializeField] private GameObject panelSettings;
    [SerializeField] private GameObject panelCredits;

    [Header("Buttons Main Menu")]
    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;
    [SerializeField] private Button btnBackCredits;

    private bool isPause = false;

    private void Awake()
    {
        btnStart.onClick.AddListener(TogglePause);
        btnSettings.onClick.AddListener(OnSettingClicked);
        btnCredits.onClick.AddListener(OnCreditClicked);
        btnBackCredits.onClick.AddListener(OnBackCredits);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    private void OnDestroy()
    {
        btnStart.onClick.RemoveAllListeners();
        btnSettings.onClick.RemoveAllListeners();
        btnCredits.onClick.RemoveAllListeners();
        btnBackCredits.onClick.RemoveAllListeners();
    }

    public void TogglePause()
    {
        isPause = !isPause;

        if (isPause)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;

        panelMainMenu.SetActive(isPause);
    }

    private void OnSettingClicked()
    {
        panelSettings.SetActive(true);
        TogglePause();
        Time.timeScale = 0f;
    }

    private void OnCreditClicked()
    {
        panelCredits.SetActive(true);
        TogglePause();
        Time.timeScale = 0f;
    }

    private void OnBackCredits()
    {
        panelCredits.SetActive(false);
        TogglePause();
    }
}
