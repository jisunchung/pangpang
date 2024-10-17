using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class maincharac : MonoBehaviour
{
    private Animator animator;
    float chardir;
    //cool time
    private float curTime;
    public float coolTime = 1.0f;
    
    int count;

    public GameObject mainbullet;
    GameObject villain;
    float x;
    float y;
    float angle;

    //audio
    public AudioClip clip;

    //혁순변수추가부분
    public static int coinPoint;

    //지선변수 추가부분
    //public static int lifePoint;

    //몸을 바꾸기 위해
    string nowBody;
    UnityEngine.U2D.Animation.SpriteResolver spriteResolver;
    //maincharac 게임 오브젝트 안에 자식 오브젝트 중 head를 넣어주면 된다
    public GameObject head;

    float distance;

    GameObject closeMonster;

    public int lifepoint;

    float dis;

    public Image mainHP;
    GameObject monsterDirec;

    // Start is called before the fi rst frame update
    void Start()
    {

       // lifePoint = 0;
        //coinPoint = 0;
        animator = GetComponent<Animator>();

        villain = GameObject.Find("villain");
        mainHP.fillAmount = 1f;

        spriteResolver = head.GetComponent<UnityEngine.U2D.Animation.SpriteResolver>();

//        Debug.Log("지금몸" + GameDirector.nowBody);

        switch (GameDirector.nowBody)
        {

            case 1:
                nowBody = "Pang";
                break;
            case 2:
                nowBody = "hypang";
                break;
            case 3:
                nowBody = "hspang";
                break;
            case 4:
                nowBody = "sonpang";
                break;
            case 5:
                nowBody = "jspang";
                break;
            case 6:
                nowBody = "forestpang";
                break;
        }

        //DB에서 불러온 값으로 얼굴을 바꿔준다.
        spriteResolver.SetCategoryAndLabel("Head", nowBody);

        monsterDirec = GameObject.Find("MonsterDirector");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("villain");
        Debug.Log(temp.Length);

        if (temp.Length==0)    //축적 값이랑 얻은 코인+하트 값을 비교해서 다음 스테이지로 넘어  
        {
            Debug.Log("빠잉!");


            endGame2();
        }
        //hp바 피사체 따라다니기
        mainHP.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(-0.2f, 3.1f, 0));



        //팡팡이움직임
        //게임 내 애니메이션 작동을 위해 수정함 - 지은
        //기존 움직임에 넣으면 계속 걷는 모션이 실행됨 + 방향키 누르는 동안 바나나 안 나옴
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        //Vector3 moveVector = new Vector3(moveX, 0f, 0f);
        //animator.SetBool("isRunning", moveVector.magnitude > 0);
        Vector3 moveVector1 = new Vector3(0f, 0f, moveY);
        animator.SetBool("isWalking", moveVector1.magnitude > 0);
        transform.Translate(new Vector3(moveX, moveY, 0f).normalized * Time.deltaTime * 5f);


        //if (Input.GetKey(KeyCode.LeftArrow)){
        //    transform.Translate(-0.1f, 0, 0);

        //        //Debug.Log("left");
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{ 
        //    transform.Translate(0.1f, 0, 0);

        //    //Debug.Log("right");
        //}
        //else if(Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.Translate(0, 0.1f, 0);

        //    //Debug.Log("up");
        //}
        //else if(Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.Translate(0, -0.1f, 0);

        //    //Debug.Log("down");
        //}
        //맵 안에 가두기
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
        if (curTime <= 0) {
            //바나나던지기
            if (Input.GetKeyDown(KeyCode.Space))
            {
              //SoundManager.instance.BGMplay("banana", clip);

                

                curTime = coolTime;
                GameObject go = Instantiate(mainbullet) as GameObject;

                go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);





             




                x = transform.position.x - closeMonster.transform.position.x;
                y = transform.position.y - closeMonster.transform.position.y;

                //Hypotenuse = Mathf.Sqrt(Mathf.Abs(x)* Mathf.Abs(x)+ Mathf.Abs(y)+ Mathf.Abs(y));
                //Debug.Log("x" + x);
                //Debug.Log("y" + y);
                //Debug.Log("빗변" + Hypotenuse);

                angle = Mathf.Atan2(Mathf.Abs(y), Mathf.Abs(x)) * Mathf.Rad2Deg;

                //distance = Vector2.Distance(villain.transform.position, transform.position);
                //Debug.Log("두 객체 사이 거리"+distance);


                if (x < 0 && y < 0)
                    go.transform.Rotate(0, 0, angle);

                else if (x > 0 && y < 0)
                    go.transform.Rotate(0, 0, 180 - angle);
                else if (x < 0 && y > 0)
                    go.transform.Rotate(0, 0, -angle);

                else if (x > 0 && y > 0)
                    go.transform.Rotate(0, 0, 180 + angle);
            }

        }
        else
        {
            curTime -= Time.deltaTime;
        }
       
    }
    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            chardir = -1;
        }
        else
        {
            chardir = 1;
        }
        transform.localScale = new Vector3(chardir * 0.7f, 0.7f, 1f);
    }
    void OnTriggerEnter2D(Collider2D a)
    {
//        Debug.Log("앋");
        //충돌시 이벤트
        if (a.gameObject.tag == "villainbullet")
        {
            mainHP.fillAmount -= 0.1f;
//            Debug.Log("적에게 공격 당함");
        }
            
        

        if (mainHP.fillAmount == 0)
        {
            endGame1();

        }
    }
    public void Attack()
    {
        GameObject go = Instantiate(mainbullet) as GameObject;

        go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);








        x = transform.position.x - closeMonster.transform.position.x;
        y = transform.position.y - closeMonster.transform.position.y;

        //Hypotenuse = Mathf.Sqrt(Mathf.Abs(x)* Mathf.Abs(x)+ Mathf.Abs(y)+ Mathf.Abs(y));
        //Debug.Log("x" + x);
        //Debug.Log("y" + y);
        //Debug.Log("빗변" + Hypotenuse);

        angle = Mathf.Atan2(Mathf.Abs(y), Mathf.Abs(x)) * Mathf.Rad2Deg;

        //distance = Vector2.Distance(villain.transform.position, transform.position);
        //Debug.Log("두 객체 사이 거리"+distance);


        if (x < 0 && y < 0)
            go.transform.Rotate(0, 0, angle);

        else if (x > 0 && y < 0)
            go.transform.Rotate(0, 0, 180 - angle);
        else if (x < 0 && y > 0)
            go.transform.Rotate(0, 0, -angle);

        else if (x > 0 && y > 0)
            go.transform.Rotate(0, 0, 180 + angle);

    }

    //피 0됐을때 씬 전환
    void endGame1()
    {
        SceneManager.LoadScene("GameOver");
    }





    void endGame2()
    {
        SceneManager.LoadScene("game1End");
    }


}
