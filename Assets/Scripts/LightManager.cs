using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public GameObject lightSourceRoom1;
    public GameObject lightSourceRoom2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveLights()
    {
        lightSourceRoom1.SetActive(false);
        lightSourceRoom2.SetActive(false);
    }
}
