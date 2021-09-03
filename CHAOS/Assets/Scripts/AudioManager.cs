using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //public AudioListener audioListener;
    public bool muted = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //audioListener = FindObjectOfType<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuteToggle()
    {
        muted = !muted;
        AudioListener.volume = muted ? 0.0f : 1.0f;
    }
}
