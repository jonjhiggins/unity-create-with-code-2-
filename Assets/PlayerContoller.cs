using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    private Rigidbody playerRigidBody;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private Animator playerAnimator;
    private AudioSource playerAudio;
    private int jumpCount = 0;
    private SpeedManager speedManager;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRigidBody = gameObject.GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        speedManager = GameObject.Find("SpeedManager").GetComponent<SpeedManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2 && !gameOver)
        {
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount += 1;
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedManager.IncreaseSpeed();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedManager.DecreaseSpeed();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
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
