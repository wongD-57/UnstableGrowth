using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TNTExplosion : MonoBehaviour
{

    [SerializeField] private float timeDelay = 5f;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float explosionForce = 500f;
    [SerializeField] private float timeBlink = 1f;
    [SerializeField] private float blinkFadeRate = 1.5f;

    private float timeStart;
    private bool explosionStarted = false;
    private float timePreviousBlink;
    GameObject blinkObject;
    private float blinkTransparency = 0f;

    [SerializeField] private GameObject explosionParticlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.time;
        timePreviousBlink = Time.time;
        blinkObject = transform.GetChild(1).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (((Time.time - timeStart) > timeDelay) && !explosionStarted) {
            explosionStarted = true;
            Explosion();
        }
        if ((Time.time - timePreviousBlink) > timeBlink) {
            timePreviousBlink = Time.time;
            blinkTransparency  = 1f;
        }
        blinkTransparency = Mathf.Clamp(blinkTransparency - blinkFadeRate*Time.deltaTime, 0f, 1f);
        
        blinkObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, blinkTransparency);
        
    }

    void Explosion() {

        Instantiate(explosionParticlePrefab, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        
        foreach (Collider nearbyObject in colliders) {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(explosionForce * transform.localScale.x, transform.position, explosionRadius);
            }
        }
    
        // Scale (Shrink)
        Destroy(gameObject);
    }
}
