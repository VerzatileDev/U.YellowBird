using UnityEngine;

/// <summary>
///
/// License:
/// Copyrighted to Brian "VerzatileDev" Lätt ©2024.
/// Do not copy, modify, or redistribute this code without prior consent.
/// All rights reserved.
///
/// </summary>
/// <remarks>
/// Spawn a random object from a list of prefabs at a set interval.
/// </remarks>
public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float spawnAnotherAfter = 1.5f;
    [SerializeField] private float minHeight = -1f;
    [SerializeField] private float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 1f, spawnAnotherAfter);
    }

    private void Spawn()
    {
        GameObject selectedRandomPrefab = prefabs[Random.Range(0, prefabs.Length)];
        GameObject objectSpawned = Instantiate(selectedRandomPrefab, transform.position, Quaternion.identity);
        objectSpawned.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}