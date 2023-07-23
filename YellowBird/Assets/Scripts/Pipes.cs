using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float PipeSPeed = 5f;
    private float leftEdge; //Screen Space Defined to Destroy GameObject

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1; // -1 pushing to make sure it goes off screen fully.
    }

    void Update()
    {
        transform.position += Vector3.left * PipeSPeed * Time.deltaTime;

        if(transform.position.x <leftEdge)
        {
            Destroy(gameObject);
        }
    }
}