using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnd : MonoBehaviour
{

    GameObject cloneD;
    public GameObject outDfabs;
    int Drandom;
    public Transform Dout1;
    public Transform Dout2;
    public Transform Dout3;

    public void GenerateD()
    {
        Drandom = Random.Range(1, 4);
        cloneD = Instantiate(outDfabs);
        if (Drandom == 1)
        {
            cloneD.transform.position = Dout1.position;
        }
        else if (Drandom == 2)
        {
            cloneD.transform.position = Dout2.position;
        }
        else if (Drandom == 3)
        {
            cloneD.transform.position = Dout3.position;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateD();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
