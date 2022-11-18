using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float SpawnDistance = 1.5f;
    [SerializeField] private float minHeight = -1f;
    [SerializeField] private float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), SpawnDistance, SpawnDistance);
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}