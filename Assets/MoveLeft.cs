using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed = 30;
    private PlayerContoller playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerContoller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver)
        {
            return;
        }
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
    }
}
