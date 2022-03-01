using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float JumpHeight;
    [SerializeField] public static bool iskilled = false;
    [SerializeField] AudioSource hopSound;
    [SerializeField] AudioSource MassiveExplision;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        jump();
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0)) && iskilled == false)
        {
            rb.velocity = Vector2.up * JumpHeight;
            if(!hopSound.isPlaying && iskilled == false && PauseMenu.GameIsPaused == false)
            {
                hopSound.Play();
            }
        }
    }

    // If Collision With Tag Floor Has Occured Set new State of iskilled
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "floor") // Set this to Object.
        {
            MassiveExplision.Play(); // If you find this, then you know that this is the best sound of Dying ever recored in Floppy brid clone history.
            iskilled = true;
            rb.bodyType = RigidbodyType2D.Static; // Stop the Movement of Bird Once Collided.
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
