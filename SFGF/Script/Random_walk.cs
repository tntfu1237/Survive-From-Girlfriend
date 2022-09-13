using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_walk : MonoBehaviour
{
    public GameObject wantToWalk;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, wantToWalk.transform.position, 1 * Time.deltaTime);
        if (Vector3.Distance(transform.position, wantToWalk.transform.position) <= 0.5f)
        {
            wantToWalk.transform.position += new Vector3(Random.Range(0.5f, -0.5f), 0, Random.Range(0.5f, -0.5f));
        }
    }
    //Vector2 StartPointEnemis;
    //float LR = 1;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    StartPointEnemis = transform.position;
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    if (transform.position.x > StartPointEnemis.x + 4)
    //    {
    //        LR = -1;
    //    }
    //    else if (transform.position.x < StartPointEnemis.x - 4)
    //    {
    //        LR = 1;
    //    }
    //    transform.Translate(LR * Time.deltaTime * 4.0f, 0, 0);
    //}
}

