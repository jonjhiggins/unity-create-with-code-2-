using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float leftBounds = 15;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GameOver)
        {
            return;
        }
        transform.Translate(Vector3.left * Time.deltaTime * gameManager.Speed);

        if (transform.position.x < -leftBounds && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
