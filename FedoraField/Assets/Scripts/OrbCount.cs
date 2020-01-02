using UnityEngine;
using UnityEngine.UI;

public class OrbCount : MonoBehaviour
{
    public Text orbsCollected;
    public Text orbsRemaining;
    public static GameObject[] levelOrbs;
    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelOrbs = GameObject.FindGameObjectsWithTag("Orb");
    }

    // Update is called once per frame
    void Update()
    {
        orbsCollected.text = "C: " + Beacon.orbsCollected.ToString() + "/" + levelManager.orbsRequired;

        levelOrbs = GameObject.FindGameObjectsWithTag("Orb");
        orbsRemaining.text = "R: " + levelOrbs.Length;
    }
}
