using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbScore : MonoBehaviour {
    public Text orbScoreText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        orbScoreText.text = BeaconScript.orbCount.ToString();
    }
}
