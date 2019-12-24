using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class FailureMenu : MonoBehaviour
{
    public Text failureInfo;
    public Button retryButton;
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

    public void ToggleEndMenu(int orbsCollected, int orbsRequired)
    {
        failureInfo.text = "You only recovered " + orbsCollected + "/" + orbsRequired + " orbs";
        gameObject.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
