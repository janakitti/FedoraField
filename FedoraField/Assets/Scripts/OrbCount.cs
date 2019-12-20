using UnityEngine;
using UnityEngine.UI;

public class OrbCount : MonoBehaviour
{
    public Beacon beacon;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Orbs: " + beacon.orbCount.ToString();
    }
}
