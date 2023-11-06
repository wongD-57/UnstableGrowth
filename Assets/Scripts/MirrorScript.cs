using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorScript : MonoBehaviour
{
    // Start is called before the first frame update

    public bool mirrorObject = true;

    private GameObject PlatformParent;

    void Start()
    {
        PlatformParent = GameObject.FindWithTag("PlatformPointsTag");

        if(mirrorObject)
        {
            float distToMirror = PlatformParent.transform.position.x - transform.position.x;
            GameObject cloneGO = Instantiate(gameObject);
            Vector3 RotVecHolder = new Vector3(0,0,transform.rotation.z)* (180f/Mathf.PI);
            MirrorScript CloneMirrorScript = cloneGO.GetComponent<MirrorScript>();


            cloneGO.transform.Rotate(-4*RotVecHolder, Space.Self);
            cloneGO.transform.position += new Vector3(distToMirror*2,0,0);
            CloneMirrorScript.mirrorObject=false;


        }
    }

}
