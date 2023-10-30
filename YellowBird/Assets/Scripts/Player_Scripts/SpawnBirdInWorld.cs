using UnityEngine;

public class SpawnBirdInWorld : MonoBehaviour
{
    public GameObject myPrefab = null;
    public static GameObject obj;

    void Start()
    {
        spawnBird();
    }

    public void spawnBird()
    {
        obj = Instantiate(myPrefab, transform.position, Quaternion.identity);
    }
}