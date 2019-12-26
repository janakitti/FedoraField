using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int orbsRequired;

    public AudioClip bgMusicClip;
    public AudioSource bgMusicSource;
    // Start is called before the first frame update
    void Start()
    {
        orbsRequired = 2;
        bgMusicSource.clip = bgMusicClip;
        bgMusicSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
