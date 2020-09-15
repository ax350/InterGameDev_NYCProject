using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour //it's able to attach to a GameObject
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.8f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
