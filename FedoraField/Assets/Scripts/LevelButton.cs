using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public LevelLoader levelLoader;
    public string levelName;
    public Text levelNameDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, GameObject.Find("player").transform.position) < 1)
        {
            levelNameDisplay.text = levelName;
            if (Input.GetButtonDown("X360_A"))
            {
                levelLoader.LoadLevel(levelName);

            }
        } else
        {
            levelNameDisplay.text = "";
        }
        
    }
}
