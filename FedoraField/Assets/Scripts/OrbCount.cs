using UnityEngine;
using UnityEngine.UI;

public class OrbCount : MonoBehaviour
{
    public Beacon beacon;
    public Text scoreText;
    public GameObject[] levelOrbs;
    // Start is called before the first frame update
    void Start()
    {
        levelOrbs = GameObject.FindGameObjectsWithTag("Orb");
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreText.text = "Orbs: " + beacon.orbCount.ToString() + "/" + levelOrbs.Length;
    }
}
