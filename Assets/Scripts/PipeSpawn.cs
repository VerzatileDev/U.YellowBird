using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public GameObject prefab;
    public float SpawnDistance = 1.5f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), SpawnDistance, SpawnDistance);// Needs a provided Method.
    }

    private void Spawn() // Spawns The Set Prefab Of Pipes And Box Collector
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity); // Cloning and setting
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}