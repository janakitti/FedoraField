using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FieldStateIcon : MonoBehaviour
{
    Image myImageComponent;
    public Sprite blueGravityIcon;
    public Sprite pinkGravityIcon;
    public Sprite magneticIcon;

    // Start is called before the first frame update
    void Start()
    {
        myImageComponent = GetComponent<Image>(); //Our image component is the one attached to this gameObject.
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.fieldState == 0)
        {
            myImageComponent.sprite = blueGravityIcon;
        } else if (Player.fieldState == 1)
        {
            myImageComponent.sprite = pinkGravityIcon;
        } else if (Player.fieldState == 2)
        {
            myImageComponent.sprite = magneticIcon;
        }
    }
}
