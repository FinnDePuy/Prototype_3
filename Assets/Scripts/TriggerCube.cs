using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerCube : MonoBehaviour
{
    [SerializeField] private bool spawnSpider;
    [SerializeField] private GameObject spider;
    private BoxCollider boxCollider;
    private MeshRenderer meshRenderer;

    public TMP_Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();

        meshRenderer.enabled = false;
        boxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider playerCollider = GameSingleton.main.playerController.gameObject.GetComponent<CharacterController>();
        if (spawnSpider && other == playerCollider)
        {
            Debug.Log("Spawning spider");
            GameObject spawnedSpider = Instantiate(spider, GameSingleton.main.playerController.transform);
            spawnedSpider.transform.LookAt(GameSingleton.main.playerController.transform);
            spawnedSpider.transform.localScale = new Vector3(1, 1, 1);

            Vector3 playerPos = GameSingleton.main.playerController.transform.position;
            spawnedSpider.transform.position = new Vector3(playerPos.x, playerPos.y - 0.5f, playerPos.z + 3);

            GameSingleton.main.playerController.GetComponent<PlayerController>().enabled = false;

            StartCoroutine(GameOverText());
        }
    }

    IEnumerator GameOverText()
    {
        yield return new WaitForSeconds(2f);
        gameOverText.enabled = true;
    }
}
