using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MissionMenu : MonoBehaviour
{
    public Text missionName;
    public Text missionInfo;
    // Start is called before the first frame update
    void Start()
    {
        missionName.text = LevelManager.missionName;
        missionInfo.text = "Recover " + LevelManager.orbsRequired.ToString() + " orbs";
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("X360_A"))
        {
            gameObject.SetActive(false);
        }
    }
}
