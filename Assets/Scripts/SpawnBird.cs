using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBird : MonoBehaviour
{
    public GameObject myPrefab = null; // Pref Of The Player( Bird )
    public static GameObject obj;
    Vector2 playerPosition = new Vector2(0, 0);

    void Start()
    {
        spawnBird();
        
    }

    public void Update()
    {
        
    }


    public void spawnBird()
    {
        obj = Instantiate(myPrefab, transform.position, Quaternion.identity); // At centre of Scene.
    }


}
