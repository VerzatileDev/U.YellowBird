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
/// Instntiates a bird prefab in the world. (Player's bird)
/// </remarks>
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