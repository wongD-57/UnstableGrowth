using System.Collections;
using System.Collections.Generic;
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

    public void MakeGrow() {
        currentScale = Mathf.Clamp(currentScale + growthRate, minSize, maxSize);
        
        transform.localScale = UpdateScaleRate(currentScale);
    }

    public void MakeShrink() {
        currentScale = Mathf.Clamp(currentScale - shrinkRate, minSize, maxSize);

        transform.localScale = UpdateScaleRate(currentScale);
    }

    void Start() {
        startingScale = transform.localScale;

        UpdateMass(startingScale[0], startingScale[1]);
    }

    Vector3 UpdateScaleRate(float targetScale) {
        targetSize = targetScale * startingScale;
        return targetSize;
    }

    void UpdateMass(float xSize, float ySize) {
        GetComponent<Rigidbody>().mass = density * xSize * ySize;
    }
}
