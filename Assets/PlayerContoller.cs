using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    private Rigidbody _playerRigidBody;
    private float _walkOnSpeed = 10;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private Animator _playerAnimator;
    private AudioSource _playerAudio;
    private int _jumpCount = 0;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        _playerRigidBody = gameObject.GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 2)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _walkOnSpeed);
            return;
        }

        _gameManager.PlayerReady = true;

        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount < 2 && !_gameManager.GameOver)
        {
            _playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _jumpCount += 1;
            _playerAnimator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            _playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _gameManager.IsDashing = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _gameManager.IsDashing = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _jumpCount = 0;
            if (!_gameManager.GameOver)
            {
                dirtParticle.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game over!");
            explosionParticle.Play();
            _playerAnimator.SetBool("Death_b", true);
            _playerAnimator.SetInteger("DeathType_int", 1);
            _gameManager.GameOver = true;
            _playerAudio.PlayOneShot(crashSound, 1.0f);
            dirtParticle.Stop();
        }
    }
}
