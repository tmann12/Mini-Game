using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorl : MonoBehaviour
{ 
    public bool gameOver = false;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
     public bool isOnGround = true;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    
    
      // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
       
       
    }

    // Update is called once per frame
    void Update()
    {

         // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
            isOnGround = false;
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
       if (other.gameObject.CompareTag("Ground"))
         {
            isOnGround = true; 
         }

    }
}
