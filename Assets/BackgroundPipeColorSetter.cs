using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPipeColorSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color randomColor = Color.HSVToRGB(Random.Range(0f, 1f), 0.25f, 0.9f);
        Color randomColorRGB = new Color(randomColor.r, randomColor.g, randomColor.b, 70f);
        for(int i = 0; i < 3; i++) {
        // gameObject.transform.GetChild(i).transform.GetChild(0).transform.GetChild(2).GetComponent<Renderer>().material.SetColor(Shader.PropertyToID("PipeMaterial"), randomColorRGB);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
}
