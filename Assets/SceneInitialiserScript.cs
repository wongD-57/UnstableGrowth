using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitialiserScript : MonoBehaviour
{
    // Start is called before the first frame update

    private int numberOfPlayers;

    public List<Material> BGList = new List<Material>();

    public List<Material> BoxList = new List<Material>();

    private bool boxesColored = false;

    private float timeOfCreation;

    void Start()
    {
        SetBackground();
        timeOfCreation = Time.time;
        
    }

    void Update()
    {
        if(!boxesColored){
            if(Time.time > timeOfCreation)
            {
                SetBoxColors();
                boxesColored = true;
            }
        }
    }

    void SetBackground()
    {
        numberOfPlayers = MainManager.Instance.numberOfPlayers;
        GameObject BG = GameObject.Find("BGPlane");
        MeshRenderer BGMR = BG.GetComponent<MeshRenderer>();
        int lenHolder = BGList.Count;
        BGMR.material = BGList[Random.Range(0,lenHolder)];

        SimpleMovementScript SMScript = BG.GetComponent<SimpleMovementScript>();
        SMScript.MovmentVector = new Vector3(Random.Range(-0.3f,0.3f),Random.Range(1f,2f),0);

    }

    void SetBoxColors()
    {
        GameObject[] boxes;
        boxes = GameObject.FindGameObjectsWithTag("Box");

        for(int i = 0;  i < boxes.Length ; i++)
        {
            MeshRenderer MRHolder = boxes[i].GetComponent<MeshRenderer>();
            // print(BoxList.Count);
            MRHolder.material = BoxList[Random.Range(0,BoxList.Count)];
        }


        // MeshRenderer BGMR = BG.
        // int lenHolder = BGList.Count;
        // BGMR.material = BGList[Random.Range(0,lenHolder)];

        // SimpleMovementScript SMScript = BG.GetComponent<SimpleMovementScript>();
        // SMScript.MovmentVector = new Vector3(Random.Range(-0.3f,0.3f),Random.Range(1f,2f),0);

    }

    // Update is called once per frame

}
