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
    }

    Vector3 UpdateScaleRate(float targetScale) {
        targetSize = targetScale * startingScale;
        return targetSize;
    }
}
