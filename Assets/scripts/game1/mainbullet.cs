using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainbullet : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.3f,0, 0);
        Vector3 pos = transform.position;
        if (pos.x > 49 || pos.x < 1 || pos.y > 29 || pos.y < 1)
        {
            // moveX = 0;
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D a)
    {

        if (a.gameObject.name != "maincharac")
        {
            Destroy(gameObject);
           
        }

    }
}
