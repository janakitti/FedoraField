using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public AudioClip bgMusicClip;
    public AudioSource bgMusicSource;
    // Start is called before the first frame update
    void Start()
    {
        bgMusicSource.clip = bgMusicClip;

        bgMusicSource.PlayOneShot(bgMusicClip, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
