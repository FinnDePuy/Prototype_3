using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton : MonoBehaviour
{
    public static GameSingleton main { get; private set; }

    public LightManager lightManager { get; private set; }
    public PlayerController playerController { get; private set; }
    public LanternManager lanternManager { get; private set; }
    public SpiderManager spiderManager { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if (main != null && main != this)
        {
            Destroy(this);
        } else
        {
            main = this;
        }

        lightManager = GetComponentInChildren<LightManager>();
        playerController = GetComponentInChildren<PlayerController>();
        lanternManager = GetComponentInChildren<LanternManager>();
        spiderManager = GetComponentInChildren<SpiderManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
