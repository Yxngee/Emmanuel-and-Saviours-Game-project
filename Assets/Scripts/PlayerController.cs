using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // private GameObject focalPoint;
    public AudioClip crashSound;
    public AudioClip eatSound;
    public AudioClip shootShound;
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworkParticle;
    private AudioSource playerAudio;
    public GameObject projectilePrefab;
    private float speed = 10.0f;
    private float xRange = 13.0f;
    public bool gameOver = false;
    public bool hasPowerup;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        // focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {

        //Mover player in horizontal direction
        if (gameOver == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }
        //Launch projectiles
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAudio.PlayOneShot(shootShound, 5.0f);
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        //left and right boundries
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            gameOver = true;
            Debug.Log("You did not survive. Game Over");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Food"))
        {
            fireworkParticle.Play();
            playerAudio.PlayOneShot(eatSound, 1.0f);
            Debug.Log("Player has collided with powerup");
            Destroy(other.gameObject);
        }
    }

}

