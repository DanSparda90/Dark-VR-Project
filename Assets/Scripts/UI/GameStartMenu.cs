using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
	#region Fields
	[Header("Sections")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _options;
    [SerializeField] private GameObject _about;

    [Header("Menu Buttons")]
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _optionBtn;
    [SerializeField] private Button _aboutBtn;
    [SerializeField] private Button _quitBtn;

    [SerializeField] private List<Button> _returnBtns;

	#endregion

	#region Unity Callbacks
	void Start()
    {
        EnableMainMenu();

        _startBtn.onClick.AddListener(StartGame);
        _optionBtn.onClick.AddListener(EnableOption);
        _aboutBtn.onClick.AddListener(EnableAbout);
        _quitBtn.onClick.AddListener(QuitGame);

        foreach (Button btn in _returnBtns)
            btn.onClick.AddListener(EnableMainMenu);
    }

	#endregion

	#region Methods
	public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        HideAll();
        SceneTransitionManager.Instance.GoToSceneAsync(1);
    }

    public void HideAll()
    {
        _mainMenu.SetActive(false);
        _options.SetActive(false);
        _about.SetActive(false);
    }

    public void EnableMainMenu()
    {
        _mainMenu.SetActive(true);
        _options.SetActive(false);
        _about.SetActive(false);
    }
    public void EnableOption()
    {
        _mainMenu.SetActive(false);
        _options.SetActive(true);
        _about.SetActive(false);
    }
    public void EnableAbout()
    {
        _mainMenu.SetActive(false);
        _options.SetActive(false);
        _about.SetActive(true);
    }

	#endregion
}
