using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnM : MonoBehaviour
{
    GameObject cloneM1;
    public GameObject outM1fabs;
    GameObject cloneM2;
    public GameObject outM2fabs;    
    int m1random;
    int m2random;
    public Transform m1out;
    public Transform m2out;
    public Transform m3out;
    public Transform m4out;
    public Transform m5out;

    public void Generatem()
    {
        m1random = Random.Range(1, 6);
        do
        {
            m2random = Random.Range(1, 6);
        } while (m1random == m2random);
        cloneM1 = Instantiate(outM1fabs);
        cloneM2 = Instantiate(outM2fabs);
        if (m1random == 1)
        {
            cloneM1.transform.position = m1out.position;
        }
        else if (m1random == 2)
        {
            cloneM1.transform.position = m2out.position;
        }
        else if (m1random == 3)
        {
            cloneM1.transform.position = m3out.position;
        }
        else if (m1random == 4)
        {
            cloneM1.transform.position = m4out.position;
        }
        else if (m1random == 5)
        {
            cloneM1.transform.position = m5out.position;
        }
        if (m2random == 1)
        {
            cloneM2.transform.position = m1out.position;
        }
        else if (m2random == 2)
        {
            cloneM2.transform.position = m2out.position;
        }
        else if (m2random == 3)
        {
            cloneM2.transform.position = m3out.position;
        }
        else if (m2random == 4)
        {
            cloneM2.transform.position = m4out.position;
        }
        else if (m2random == 5)
        {
            cloneM2.transform.position = m5out.position;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Generatem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
