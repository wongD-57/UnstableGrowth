using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxScale : MonoBehaviour
{
    public float growthRate = 0.05f;

    public float shrinkRate = 0.05f;

    public float maxSize = 1.5f;
    public float minSize = 0.75f;

    float currentScale = 1f; // Assume starting scale is at scale = 1

    private Vector3 startingScale;
    private Vector3 targetSize;

    public float density = 0.7f;

    private bool reachedMaxSize = false;

    private float timeSinceLastParticle;

    [SerializeField] private GameObject maxSizeParticlePrefab;

    public void MakeGrow(float multiplier) {
        currentScale = Mathf.Clamp(currentScale + (growthRate * multiplier), minSize, maxSize);
        
        transform.localScale = UpdateScaleRate(currentScale);
    }

    public void MakeShrink(float multiplier) {
        currentScale = Mathf.Clamp(currentScale - (shrinkRate * multiplier), minSize, maxSize);

        transform.localScale = UpdateScaleRate(currentScale);
    }

    void Start() {
        startingScale = transform.localScale;

        UpdateMass(startingScale[0], startingScale[1]);

        timeSinceLastParticle = Time.time;
    }

    Vector3 UpdateScaleRate(float targetScale) {
        targetSize = targetScale * startingScale;
        return targetSize;
    }

    void UpdateMass(float xSize, float ySize) {
        GetComponent<Rigidbody>().mass = density * xSize * ySize;
    }

    void Update() {
        if ((currentScale == maxSize) && ((Time.time - timeSinceLastParticle) > 0.5f) && !reachedMaxSize) {
            reachedMaxSize = true;
            timeSinceLastParticle = Time.time;
            Instantiate(maxSizeParticlePrefab, transform.position + new Vector3(0, 0, -2), transform.rotation);
        }
        if (currentScale < maxSize) {
            reachedMaxSize = false;
        }
    }
}
