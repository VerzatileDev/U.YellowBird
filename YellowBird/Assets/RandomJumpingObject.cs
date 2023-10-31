using UnityEngine;

public class RandomJumpingObject : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float minY = -2f;
    public float fallForce = 10f;
    public float destroyPosition = 15f;

    private Rigidbody2D rb;
    private bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (isFalling)
        {

            rb.velocity = new Vector2(0, 0);
            rb.AddForce(Vector2.down * fallForce, ForceMode2D.Impulse);

            if (transform.position.y < -destroyPosition)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (transform.position.y < minY)
            {
                Jump();
            }

            if (transform.position.x > destroyPosition)
            {
                Destroy(gameObject);
            }
        }
    }

    void Jump()
    {
        float jumpForce = Random.Range(8f, 12f);
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void OnMouseDown()
    {
        isFalling = true;
    }
}