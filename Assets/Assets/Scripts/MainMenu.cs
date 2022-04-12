using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public Button controllsButton;
    public Button backButton;

    public GameObject controllsPanel;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(LoadPlayScene);
        quitButton.onClick.AddListener(QuitGame);
        controllsButton.onClick.AddListener(ControllsOn);
        backButton.onClick.AddListener(Back);
    }


    void LoadPlayScene()
    {
        SceneManager.LoadScene(1);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void ControllsOn()
    {
        controllsPanel.SetActive(true);
    }

    void Back()
    {
        controllsPanel.SetActive(false);
    }


}
