using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    private Rigidbody playerRigidBody;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    private bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRigidBody = gameObject.GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game over!");
            gameOver = true;
        }
    }
}
