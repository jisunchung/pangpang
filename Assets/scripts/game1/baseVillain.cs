using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class baseVillain : MonoBehaviour
{
    public float villainMoveTimer = 0;  //타이머 (villainMoveRate까지 도달했는지 측정하는 시간) 건들 x
    public float villainMoveRate = 1;   //악당의 속도 이거 줄이면 빨라짐
    public float villanFootStep = 1;      //줄이면 보폭 줄어든다

    public float villainShootTimer = 0;  //타이머
    public float villainShootRate = 1;   //악당의 사격속도 이거 줄이면 빨라짐
    public GameObject villainbullet;     //악당의 투사체

    GameObject maincharac;

    public Image HP;

    public GameObject coin;
    public GameObject life;


    //float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        maincharac = GameObject.Find("maincharac");
        HP.fillAmount = 1f;
    }

    // Update is called once per frame
    public void Update()
    {
        HP.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, 2.0f, 0));
        //게임오브젝트의 transform을 통해서 존재하는 오브젝트의 child와 parent오브젝트를 접근할 수 있다. 
        Vector3 pos = transform.position;
        if (pos.x > 49)
        {
            // moveX = 0;
            pos.x = 49;
        }
        else if (pos.x < 1)
        {
            //moveX = 0;
            pos.x = 1;
        }
        if (pos.y < 1)
        {
            //moveY = 0;
            pos.y = 1;
        }
        else if (pos.y > 29)
        {
            //moveY = 0;
            pos.y = 29;
        }
        transform.position = pos;
    }

    public void villainMove()
    {


        villainMoveTimer += Time.deltaTime;

        if (villainMoveTimer > villainMoveRate)
        {
            villainMoveTimer = 0;
            int direc = Random.Range(1, 5);
            //            Debug.Log(direc);
            switch (direc)
            {
                case 1:
                    transform.Translate(villanFootStep, 0, 0);  //오른쪽 움직임 추후에 애니메이션 적용
                    break;

                case 2:
                    transform.Translate(-villanFootStep, 0, 0);  //왼쪽 움직임 추후에 애니메이션 적용
                    break;
                case 3:
                    transform.Translate(0, villanFootStep, 0);   //위쪽 움직임 추후에 애니메이션 적용
                    break;
                case 4:
                    transform.Translate(0, -villanFootStep, 0);  //아래쪽 움직임 추후에 애니메이션 적용
                    break;
            }

        }
    }

    public void targetShoot()
    {
        villainShootTimer += Time.deltaTime;

        float x;
        float y;
        float angle;

        if (villainShootTimer > 2)
        {


            villainShootTimer = 0;
            GameObject go = Instantiate(villainbullet) as GameObject;
            go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);


            x = transform.position.x - maincharac.transform.position.x;
            y = transform.position.y - maincharac.transform.position.y;

            angle = Mathf.Atan2(Mathf.Abs(y), Mathf.Abs(x)) * Mathf.Rad2Deg;

            if (x < 0 && y < 0)
                go.transform.Rotate(0, 0, angle);

            else if (x > 0 && y < 0)
                go.transform.Rotate(0, 0, 180 - angle);
            else if (x < 0 && y > 0)
                go.transform.Rotate(0, 0, -angle);

            else
                go.transform.Rotate(0, 0, 180 + angle);


        }

    }

    public void NontargetShoot()
    {
        villainShootTimer += Time.deltaTime;

        float angle;

        if (villainShootTimer > villainShootRate)
        {
            villainShootTimer = 0;
            GameObject go = Instantiate(villainbullet) as GameObject;
            go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);

            angle = Random.Range(1, 361);

            go.transform.Rotate(0, 0, angle);

        }

    }




    void OnTriggerEnter2D(Collider2D a)
    {

        if (a.gameObject.tag == "mainbullet")
        {

            HP.fillAmount -= 0.1f;
        }

        if (HP.fillAmount == 0)
        {
            Destroy(gameObject);
        }

    }




}
