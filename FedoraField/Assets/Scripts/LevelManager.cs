using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int orbsRequired;
    public static string missionName;
    public MissionMenu missionMenu;

    public AudioClip bgMusicClip;
    public AudioSource bgMusicSource;

    public AudioClip beatClip;
    public AudioSource beatSource;

    public AudioClip pianoClip;
    public AudioSource pianoSource;

    public AudioClip synthClip;
    public AudioSource synthSource;

    public AudioClip magClip;
    public AudioSource magSource;

    // Start is called before the first frame update
    void Start()
    {
        missionName = "Dawn";
        missionMenu.ToggleMissionMenu();

        bgMusicSource.clip = bgMusicClip;
        beatSource.clip = beatClip;
        pianoSource.clip = pianoClip;
        synthSource.clip = synthClip;
        magSource.clip = magClip;

        bgMusicSource.PlayOneShot(bgMusicClip, 0f);
        beatSource.PlayOneShot(beatClip, 0f);
        pianoSource.PlayOneShot(pianoClip, 0f);
        synthSource.PlayOneShot(synthClip, 0f);
        magSource.PlayOneShot(magClip, 0f);
        bgMusicSource.volume = 0f;
        synthSource.volume = 0f;
        magSource.volume = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("X360_Y") && Player.fieldState == 0)
        {
            StartCoroutine("synthFadeIn");
            StopCoroutine("synthFadeOut");
        } else if (Input.GetButtonUp("X360_Y"))
        {
            StopCoroutine("synthFadeIn");
            StartCoroutine("synthFadeOut");
        }

        if (Input.GetButtonDown("X360_Y") && Player.fieldState == 2)
        {
            magSource.volume = 1f;
            StopCoroutine("magFadeOut");
            StopCoroutine("pianoFadeIn");
            StartCoroutine("pianoFadeOut");
        }
        else if (Input.GetButtonUp("X360_Y"))
        {
            StopCoroutine("pianoFadeOut");
            StartCoroutine("magFadeOut");
            StartCoroutine("pianoFadeIn");
        }
    }

    IEnumerator pianoFadeIn()
    {
        while (pianoSource.volume < 1f)
        {
            pianoSource.volume += Time.deltaTime / 1.0f;
            yield return null;
        }
    }
    IEnumerator pianoFadeOut()
    {
        while (pianoSource.volume > 0f)
        {
            pianoSource.volume -= Time.deltaTime / 1.0f;
            yield return null;
        }
    }

    IEnumerator synthFadeIn()
    {
        while (synthSource.volume < 0.5f)
        {
            synthSource.volume += Time.deltaTime / 2.0f;
            yield return null;
        }
    }
    IEnumerator synthFadeOut()
    {
        while (synthSource.volume > 0f)
        {
            synthSource.volume -= Time.deltaTime / 2.0f;
            yield return null;
        }
    }


    IEnumerator magFadeIn()
    {
        while (magSource.volume < 1f)
        {
            magSource.volume += Time.deltaTime / 0.5f;
            yield return null;
        }
    }
    IEnumerator magFadeOut()
    {
        while (magSource.volume > 0f)
        {
            magSource.volume -= Time.deltaTime / 0.5f;
            yield return null;
        }
    }

    IEnumerator beatFadeIn()
    {
        while (beatSource.volume < 1f)
        {
            beatSource.volume += Time.deltaTime / 0.5f;
            yield return null;
        }
    }
    IEnumerator beatFadeOut()
    {
        while (beatSource.volume > 0f)
        {
            beatSource.volume -= Time.deltaTime / 0.5f;
            yield return null;
        }
    }

}
