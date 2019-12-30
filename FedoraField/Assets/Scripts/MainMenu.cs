using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public LevelLoader levelLoader;
    public Button playButton;

    private void Start()
    {
        playButton.Select();
    }
    public void Play()
    {
        levelLoader.LoadLevel("level_select");
    }
}
