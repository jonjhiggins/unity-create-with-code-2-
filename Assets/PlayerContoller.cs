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
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private Animator playerAnimator;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRigidBody = gameObject.GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            if (!gameOver)
            {
                dirtParticle.Play();
            }
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game over!");
            explosionParticle.Play();
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);
            dirtParticle.Stop();
        }
    }
}
