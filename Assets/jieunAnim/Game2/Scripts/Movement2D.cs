using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    //[SerializeField]
    //GameObject bullet;

    private float moveSpeed = 4f;
    private Vector3 moveDirection;

    public void Setup(Vector3 direction)
    {
        moveDirection = direction;

    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D a)
    {

        if (a.gameObject.tag != "villain")
        {
            Destroy(gameObject);

        }

    }

}
