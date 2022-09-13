using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject GameoverUI;
    public GameObject winnerUI;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (itemmanager.haveChocolate == true && itemmanager.haveDoll == true)
            {
                Cursor.visible = true;
                winnerUI.SetActive(true);
            }
            else
            {
                Cursor.visible = true;
                GameoverUI.SetActive(true);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameoverUI.SetActive(false);
        winnerUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
