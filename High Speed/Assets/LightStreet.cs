using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStreet : MonoBehaviour
{
    public GameObject light;
    void Start()
    {
        if(GameManager.isDay)
            light.SetActive(false);
        else
        {
            light.SetActive(true);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
