using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class villainbullet : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);

        if (transform.position.x <= 0 || transform.position.x >= 50f || transform.position.y <= 0 || transform.position.y >= 30) Destroy(gameObject);
    
    }

    void OnTriggerEnter2D(Collider2D a)
    {

        if (a.gameObject.tag != "villain")
        {
            Destroy(gameObject);

        }

    }
}
