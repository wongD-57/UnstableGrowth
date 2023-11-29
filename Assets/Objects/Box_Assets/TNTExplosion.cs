using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTExplosion : MonoBehaviour
{

    [SerializeField] private float timeDelay = 5f;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float explosionForce = 500f;

    private float timeStart;
    private bool explosionStarted = false;

    [SerializeField] private GameObject explosionParticlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (((Time.time - timeStart) > timeDelay) && !explosionStarted) {
            explosionStarted = true;
            Explosion();
        }
    }

    void Explosion() {

        Instantiate(explosionParticlePrefab, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        
        foreach (Collider nearbyObject in colliders) {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    
        // Scale (Shrink)
        Destroy(gameObject);
    }
}
