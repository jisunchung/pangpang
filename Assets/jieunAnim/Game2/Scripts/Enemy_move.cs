using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Enemy_move : baseVillain
{

    //audio
    public AudioClip clip;
    public AudioClip clip2;
    public AudioClip clip3;

    private Animator animator;
    Rigidbody2D rigid;
    int nextMove;
    public GameObject bullet;

    GameObject monsterDirec;



    //혁순추가
    GameObject maincharac;

    int direc_temp_x;
    int direc_temp_y;
    int direc;


    // Start is called before the first frame update
    void Start()
    {
        maincharac = GameObject.Find("maincharac"); //혁순추


        StartCoroutine("CircleFire");
        //?????? ????????
        //Invoke???? ?????? ?? ??????. ???? ?????? while????  return new WaitForSeconds?? ????
        // maincharac = GameObject.Find("maincharac");
        monsterDirec = GameObject.Find("MonsterDirector");

    }


    void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        Think();


        Invoke("Think", 5);
        //5?? ???? Think???? ????
    }
    void FixedUpdate()
    {
        rigid.velocity = new Vector3(nextMove, nextMove, 0f);
    }
    void Think()
    {
        nextMove = Random.Range(-1, 2);
        //Think();  ->???????? : ?????????? ?????? ???? / ???? ???? ???????? ??????????
        Invoke("Think", 5);
    }
    // Update is called once per frame
    new void Update()
    {
        base.Update();

    }
    //?????????? ???????? ???????? ?????? ???? ???????? ?????? ?????? ?????? ???????? ???????????? ????
    private IEnumerator CircleFire()
    {

        float attckRate = 6f; //????????
        int count = 16;




        while (true)
        {
            for (int i = 0; i < count; ++i)
            {
                GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity); //p
                SoundManager.instance.BGMplay("poi", clip2);

                float x = Mathf.Cos(Mathf.PI * 2 * i / count);
                float y = Mathf.Sin(Mathf.PI * 2 * i / count);

                clone.GetComponent<Movement2D>().Setup(new Vector3(x, y, 0));


            }
            yield return new WaitForSeconds(attckRate);//attckRate???????? ?????? ?? ????
        }


    }
    void OnTriggerEnter2D(Collider2D a)
    {
        if (a.gameObject.tag == "mainbullet")
        {
            Debug.Log("? ??");
            Debug.Log(HP.fillAmount);
            HP.fillAmount -= 0.1f;
            SoundManager.instance.BGMplay("attacked", clip3);
        }

        if (HP.fillAmount == 0)
        {
            StageDirector.killCount += 1;
            item();
            Destroy(gameObject);
            SoundManager.instance.BGMplay("dead", clip);
        }

    }




    void item()
    {

        GameObject coinI = Instantiate(coin) as GameObject;
        coinI.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);


    }


}
