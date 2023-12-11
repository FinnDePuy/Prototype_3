using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternManager : MonoBehaviour
{
    private ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider playerCollider = GameSingleton.main.playerController.gameObject.GetComponent<CharacterController>();
        if (other == playerCollider)
        {
            particles.Stop();
            GameSingleton.main.lightManager.RemoveLights();
            GameSingleton.main.spiderManager.EnableSpider();
        }
    }
}
