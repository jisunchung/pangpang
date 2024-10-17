using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangAction : MonoBehaviour
{
    private Animator animator;
    float chardir;
    float moveX, moveY;
    Rigidbody2D rigid;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // ?????????? ????
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(moveX, 0f, 0f);
        animator.SetBool("isRunning", moveVector.magnitude > 0);
        Vector3 moveVector1 = new Vector3(0f, 0f, moveY);
        animator.SetBool("isWalking", moveVector1.magnitude > 0);
        transform.Translate(new Vector3(moveX, moveY, 0f).normalized * Time.deltaTime * 5f);//trnasfor.Translate : ???? / speed*Time.deltaTime : ?????????? ????????
        Vector3 pos = transform.position;
        if (pos.x > 6.7)
        {
            // moveX = 0;
            pos.x = 6.7f;
        }
        else if (pos.x < -7.3)
        {
            //moveX = 0;
            pos.x = -7.3f;
        }
        if (pos.y < -3.4)
        {
            //moveY = 0;
            pos.y = -3.4f;
        }
        else if (pos.y > 2.45)
        {
            //moveY = 0;
            pos.y = 2.45f;
        }
        transform.position = pos;
    }

        
  
    void FixedUpdate() //?????????? ?????? ?????? ?????? ???? ????(Fixed time)???? ???? - ?????????? ????
    { 

    /*
        if( moveX >0) //Axis???? ?????? ???? ???? ???? RightArrow?? +, LeftArrow?? -?? ?????? ???? ?? ????. 0~1???? ????, -1~0???? ???????????? ?? ???????? ????????.
        {
            chardir = -1;
        }
        else
        {
            chardir = 1;
        }
        transform.localScale = new Vector3(chardir * 1f , 1f, 1f); <-????,????
        */
    
        
        if(Input.GetAxis("Horizontal")>0) 
        {
            chardir = -1;
        } 
        else
        {
            chardir = 1;
        }
        transform.localScale = new Vector3(chardir * 1f, 1f, 1f);
    }
}
