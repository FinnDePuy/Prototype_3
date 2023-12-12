using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternManager : MonoBehaviour
{
    private ParticleSystem particles;
    public Light flickeringLight;
    private bool Flag;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        flickeringLight = GetComponentInChildren<Light>();
        Flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Flag)
        {
            float flickerAmount = Mathf.PerlinNoise(Time.time * 1.0f, 0);
            float intensity = Mathf.Lerp(0.5f, 5.0f, flickerAmount);
            flickeringLight.intensity = intensity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider playerCollider = GameSingleton.main.playerController.gameObject.GetComponent<CharacterController>();
        if (other == playerCollider && !Flag)
        {
            particles.Stop();
            GameSingleton.main.lightManager.RemoveLights();
            GameSingleton.main.spiderManager.EnableSpider();
            GameSingleton.main.triggerCubeManager.EnableTriggerCubes();
            transform.SetParent(GameSingleton.main.playerController.gameObject.transform);
            transform.localPosition = new Vector3(0.5f, 0.5f, 0.6f);
            Flag = true;
        }
    }
}
