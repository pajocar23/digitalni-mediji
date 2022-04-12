using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(LoadPlayScene);
        quitButton.onClick.AddListener(QuitGame);
    }


    void LoadPlayScene()
    {
        SceneManager.LoadScene(1);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
