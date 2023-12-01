using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float spawnMaxDistance = 3.5f;

    public float minTimeForSpawn;
    public float maxTimeForSpawn;

    private float lastSpawnAt;
    private float nextSpawnAt;

    public List<GameObject> boxOptions = new List<GameObject>();

    public List<Material> BrownList = new List<Material>();
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

            GameObject boxClone = Instantiate(boxOptions[Random.Range(0,boxOptions.Count)]);
            print(boxClone.transform.localScale);
            MirrorScript MSScript;
            
            if(boxClone.TryGetComponent<MirrorScript>(out MSScript))
            {
                MSScript.mirrorObject = false;
            }

            if(boxClone.tag == "Box")
            {
                MeshRenderer MRHolder = boxClone.GetComponent<MeshRenderer>();
                MRHolder.material = BrownList[Random.Range(0,BrownList.Count)];
            }
            Vector3 V3Holder = new Vector3(Random.Range(-spawnMaxDistance,spawnMaxDistance),5.5f,0);
            print(V3Holder);
            boxClone.transform.position += V3Holder;

            lastSpawnAt = Time.time;   
            nextSpawnAt = Random.Range(minTimeForSpawn,maxTimeForSpawn);
            print("Spawn Made");
        }
    }
}
