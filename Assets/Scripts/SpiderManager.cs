using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderManager : MonoBehaviour
{
    [SerializeField] public GameObject spider;
    public Animation anim;
    public AnimationClip[] animations;

    private void Awake()
    {
        spider.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableSpider()
    {
        spider.gameObject.SetActive(true);
    }
    public void DisableSpider()
    {
        spider.gameObject.SetActive(false);
    }
}
