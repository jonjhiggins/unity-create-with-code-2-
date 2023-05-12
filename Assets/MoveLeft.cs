using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerContoller playerControllerScript;
    private float leftBounds = 15;
    private SpeedManager speedManager;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerContoller>();
        speedManager = GameObject.Find("SpeedManager").GetComponent<SpeedManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver)
        {
            return;
        }
        transform.Translate(Vector3.left * Time.deltaTime * speedManager.GetSpeed());

        if (transform.position.x < -leftBounds && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
