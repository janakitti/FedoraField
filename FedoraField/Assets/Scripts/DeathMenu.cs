using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public Button retryButton;
    public LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        retryButton.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleEndMenu()
    {
        gameObject.SetActive(true);
    }

    public void Retry()
    {
        levelLoader.LoadLevel(SceneManager.GetActiveScene().name);
    }

    public void ExitLevel()
    {
        levelLoader.LoadLevel("level_select");
    }
}
