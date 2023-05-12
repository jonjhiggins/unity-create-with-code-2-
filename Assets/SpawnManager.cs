using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 startPosition = new Vector3(25, 0, 0);
    public float startDelay = 2;
    public float repeatDelay = 2;
    private GameManager gameManager;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        if (gameManager.GameOver || !gameManager.PlayerReady)
        {
            return;
        }
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstaclePrefab = obstaclePrefabs[randomIndex];
        Instantiate(obstaclePrefab, startPosition, obstaclePrefab.transform.rotation);
    }
}


