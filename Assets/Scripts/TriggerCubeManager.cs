using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCubeManager : MonoBehaviour
{
    private BoxCollider[] triggerCubes;

    // Start is called before the first frame update
    void Start()
    {
        triggerCubes = GetComponentsInChildren<BoxCollider>(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableTriggerCubes()
    {
        for (int i = 0; i < triggerCubes.Length; i += 1)
        {
            BoxCollider boxCollider = triggerCubes[i];
            boxCollider.enabled = true;
            boxCollider.isTrigger = true;
        }
    }
}
