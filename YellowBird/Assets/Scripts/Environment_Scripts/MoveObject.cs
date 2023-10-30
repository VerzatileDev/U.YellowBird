using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float objectSpeed = 5f;
    private float leftScreenEdge;

    private void Start()
    {
        CalculateLeftScreenEdge();
    }

    private void Update()
    {
        MoveObjectLeft();
        CheckOffScreen();
    }

    private void CalculateLeftScreenEdge()
    {
        leftScreenEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1; // -1 pushes off the screen.
    }

    private void MoveObjectLeft()
    {
        transform.position += Vector3.left * objectSpeed * Time.deltaTime;
    }

    private void CheckOffScreen()
    {
        if (transform.position.x < leftScreenEdge)
        {
            Destroy(gameObject);
        }
    }
}