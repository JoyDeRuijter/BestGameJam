using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public string sceneName;
    public GameObject titlePanel;
    public bool menuActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!menuActive)
        {
            if (Input.anyKeyDown)
            {
                TitleScreen();
            }
        }
    }

    public void ChangeSceneButton()
    {
        if (sceneName == "")
        {
            return;
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void TitleScreen()
    {
        menuActive = true;
        titlePanel.SetActive(false);
    }

    public void PauseButton()
    {
        PauseScript.Pause();
    }
}
