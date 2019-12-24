using UnityEngine;
using UnityEngine.UI;

public class OrbCount : MonoBehaviour
{
    public Text orbsCollected;
    public Text orbsRemaining;
    public static GameObject[] levelOrbs;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        orbsCollected.text = "C: " + Beacon.orbsCollected.ToString() + "/" + LevelManager.orbsRequired;

        levelOrbs = GameObject.FindGameObjectsWithTag("Orb");
        orbsRemaining.text = "R: " + levelOrbs.Length;
    }
}
