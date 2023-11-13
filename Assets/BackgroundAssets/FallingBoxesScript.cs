using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBoxesScript : MonoBehaviour
{

    public float cylinderRadius = 5;

    private float timeOfLastInstantiation = 0;
    private float variableDelay;

    public float minimumDelay = 0.5f;
    public float maximumDelay = 2;

    public float maxLateralForce = 5;

    public List<GameObject> FallingObjects;
    public GameObject platformObject;

    public float poisonPillLifetime = 10;

    private Vector3 parentLocation;

    private int objectsSpawnedCounter = 0;

    void Start(){

        timeOfLastInstantiation = Time.time;

        parentLocation = transform.position;


        if (FallingObjects.Count < 1)
        {
            Debug.LogWarning("Error No objects in list.");
        }

    }

    void Update()
    {
            if( Time.time - timeOfLastInstantiation > variableDelay)
            {
                
                variableDelay = Random.Range(minimumDelay,maximumDelay);

                createObject();
                timeOfLastInstantiation = Time.time;
            }

            debugRays();

    }

    void createObject()
    {

        objectsSpawnedCounter += 1;

        GameObject cloneHolder;

        switch(objectsSpawnedCounter){

        case 150: // Spawn special object to flavour the scene.
            print("Platform Spawned");

            cloneHolder = Instantiate(platformObject,transform);

            cloneHolder.TryGetComponent<PivotPointsScript>(out PivotPointsScript PPS);
            Destroy(PPS);

            cloneHolder.AddComponent<Rigidbody>();

            break;

        default:    
            int i = Random.Range(0,FallingObjects.Count);
            cloneHolder = Instantiate(FallingObjects[i],transform);
            Vector3 offsetVectorHolder = new Vector3(Random.Range(-cylinderRadius,cylinderRadius),0,Random.Range(-cylinderRadius,cylinderRadius));
            cloneHolder.transform.position += offsetVectorHolder;
            break;
        }


        if(!cloneHolder.TryGetComponent<Rigidbody>(out Rigidbody rb))        
        {
            rb = cloneHolder.AddComponent<Rigidbody>();
        };        
            Vector3 forceVector = new Vector3(Random.Range(-maxLateralForce,maxLateralForce),0,Random.Range(-maxLateralForce,maxLateralForce));
            rb.AddForce(forceVector);

            Vector3 torqueVector = new Vector3(Random.Range(-maxLateralForce,maxLateralForce),0,Random.Range(-maxLateralForce,maxLateralForce));

            rb.AddTorque(forceVector);

            rb.drag = 0.9f;


        timedGOPoisonPill TPP = cloneHolder.AddComponent<timedGOPoisonPill>();
        TPP.durationOfLife = poisonPillLifetime;
    }


    void debugRays(){

            Vector3 forward = transform.TransformDirection(Vector3.forward) * cylinderRadius;
            Debug.DrawRay(transform.position, forward, Color.green);
            Vector3 back = transform.TransformDirection(Vector3.back) * cylinderRadius;
            Debug.DrawRay(transform.position, back, Color.green);
            Vector3 left = transform.TransformDirection(Vector3.left) * cylinderRadius;
            Debug.DrawRay(transform.position, left, Color.green);
            Vector3 right = transform.TransformDirection(Vector3.right) * cylinderRadius;
            Debug.DrawRay(transform.position, right, Color.green);

    }
}
