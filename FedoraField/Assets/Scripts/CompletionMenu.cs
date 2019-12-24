using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CompletionMenu : MonoBehaviour
{
    public Text completionInfo;
    public Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        exitButton.Select();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleEndMenu(int score)
    {
        completionInfo.text = "Score:  " + score;
        gameObject.SetActive(true);
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
