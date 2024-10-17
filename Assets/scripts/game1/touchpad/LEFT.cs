using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LEFT : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    GameObject pang;
    bool isPressed;

    Vector3 pos_first = new Vector3();
    Vector3 pos_second = new Vector3();
    Vector3 pos_final = new Vector3();

    float y;
    float x;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        pang = GameObject.Find("maincharac");
        anim = pang.GetComponent<Animator>();

    }


    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        pos_first = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
    private void Update()
    {
        if (isPressed)
        {
            anim.SetBool("isRunning", true);
            pos_second = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

            pos_final = pos_first - pos_second;
            x = Mathf.Abs(pos_first.x - pos_second.x);
            y = Mathf.Abs(pos_first.y - pos_second.y);
            if (x > 10) x = 10;
            if (y > 10) y = 10;

            //if(Mathf.Abs(pos_final.x)< Mathf.Abs(pos_final.y))
            //{
            if (pos_final.y < 0)
            {
                if (pos_final.x < 0)
                {
                    pang.transform.Translate(x *0.007f, y * 0.007f, 0);
                    pang.transform.localScale = new Vector3(-1 * 0.7f, 0.7f, 1f);

                }
                else
                {
                    pang.transform.Translate(-1*x * 0.007f, y * 0.007f, 0);
                    pang.transform.localScale = new Vector3(1 * 0.7f, 0.7f, 1f);

                }

            }
            else if (pos_final.y > 0)
            {
                if (pos_final.x < 0)
                {
                    pang.transform.Translate(x * 0.007f, -1*y * 0.007f, 0);
                    pang.transform.localScale = new Vector3(-1 * 0.7f, 0.7f, 1f);

                }
                else
                {
                    pang.transform.Translate(-1*x * 0.007f, -1*y * 0.007f, 0);
                    pang.transform.localScale = new Vector3(1 * 0.7f, 0.7f, 1f);

                }

            }
            //}
            //else
            //{
            //    if (pos_final.x < 0)
            //    {
            //        if (pang.transform.position.x < 50) pang.transform.Translate(0.2f, 0, 0);
            //    }
            //    else if(pos_final.x > 0)
            //    {
            //        if (pang.transform.position.x > 0) pang.transform.Translate(-0.2f, 0, 0);
            //    }
            //}
        }
        else
        {
            anim.SetBool("isRunning", false);

        }
    }
}
