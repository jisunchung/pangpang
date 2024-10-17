using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCam : MonoBehaviour
{
    GameObject maincharac;
    // Start is called before the first frame update
    void Start()
    {
        maincharac = GameObject.Find("maincharac");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = maincharac.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, -10);
        if (playerPos.x > 34)
        {
            // moveX = 0;
            playerPos.x = 34;
        }
        else if (playerPos.x < 16)
        {
            //moveX = 0;
            playerPos.x = 16;
        }
        if (playerPos.y < 8)
        {
            //moveY = 0;
            playerPos.y = 8;
        }
        else if (playerPos.y > 22)
        {
            //moveY = 0;
            playerPos.y = 22;
        }
        transform.position = playerPos;

    }
}
