using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float spawnDistance = 1.5f;
    [SerializeField] private float minHeight = -1f;
    [SerializeField] private float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnDistance, spawnDistance);
    }

    private void Spawn()
    {
        GameObject selectedRandomPrefab = prefabs[Random.Range(0, prefabs.Length)];
        GameObject objectSpawned = Instantiate(selectedRandomPrefab, transform.position, Quaternion.identity);
        objectSpawned.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}