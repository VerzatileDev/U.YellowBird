using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpHeight;
    protected internal static bool isKilled = false;
    [SerializeField] private AudioSource hopSound;

    [SerializeField] private AudioSource massiveExplosion;

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
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0)) && isKilled == false)
        {
            rb.velocity = Vector2.up * jumpHeight;
            if(!hopSound.isPlaying && isKilled == false && PauseMenu.gamePaused == false)
            {
                hopSound.Play();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "floor")
        {
            massiveExplosion.Play();
            isKilled = true;
            rb.bodyType = RigidbodyType2D.Static;
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