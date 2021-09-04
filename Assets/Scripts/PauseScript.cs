using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static GameObject pausePanel;
    public static bool paused;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel = GameObject.Find("PausePanel");
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public static void Pause()
    {
        if (pausePanel == null)
        {
            return;
        }
        paused = !paused;
        Time.timeScale = paused ? 0:1;
        //Debug.Log(Time.timeScale);
        pausePanel.SetActive(paused);
    }
}
