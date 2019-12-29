using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    // Start is called before the first frame update
    void Start()
    {
        bar.fillAmount = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = (float)Player.health / 100f; //find a way to convert to percentage
    }
}
