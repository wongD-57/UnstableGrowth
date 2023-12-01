using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCubeSpawner : MonoBehaviour
{
    public List<GameObject> boxOptions = new List<GameObject>();

    public float spawnMaxDistance = 3.5f;

    public float minTimeForSpawn;
    public float maxTimeForSpawn;

    private float lastSpawnAt;
    private float nextSpawnAt;

    public float spawnHeight = 10f;
    public float backgroundDistance = 7f;

    void Start()
    {
        lastSpawnAt = Time.time;
        nextSpawnAt = Random.Range(minTimeForSpawn,maxTimeForSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > (lastSpawnAt+nextSpawnAt))
        {
            GameObject spawnedBox = Instantiate(boxOptions[Random.Range(0,boxOptions.Count)], new Vector3(Random.Range(-spawnMaxDistance, spawnMaxDistance),spawnHeight, backgroundDistance), Quaternion.identity);
            spawnedBox.transform.localScale = Random.Range(0.25f, 0.75f) * Vector3.one;
            spawnedBox.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)) * 1.0f;

            lastSpawnAt = Time.time;   
            nextSpawnAt = Random.Range(minTimeForSpawn,maxTimeForSpawn);
        }
    }
}
