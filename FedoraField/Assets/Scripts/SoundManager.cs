using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static IEnumerator FadeIn (AudioSource source, float volume)
    {
        while(source.volume > volume)
        {
            source.volume += Time.deltaTime / 3.0f;
            yield return null;
        }
    }

}
