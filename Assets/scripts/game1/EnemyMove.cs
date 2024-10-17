using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : baseVillain
{
    //???? player ?? , ???? ? villain, ? ???? villainbullet ?? ?????.
    
    GameObject villain;
    public float Dis;
    private Animator animator;
    public Transform player;
    private Rigidbody2D rigid;
    public float shortDis;
    public Vector3 direction;
    //public float a = 0.1f;
    [SerializeField] [Range(0.05f, 0.3f)] float Speed = 0.07f;
    public float attacktime = 0.3f;
    GameObject monsterDirec;

    public float cooltime;
    //audio
    public AudioClip clip;
    public AudioClip clip2;
    public AudioClip clip3;


    void Start()
    {
        villain = GameObject.Find("villain");

        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        monsterDirec = GameObject.Find("MonsterDirector");

    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        MoveToTarget();
    }
    public void MoveToTarget()
    {
        
        player = GameObject.Find("maincharac").transform;

        float distance = Vector3.Distance(player.position, transform.position);
       
        if (distance <= 0.3f)
        {
            StartCoroutine(Attacking());
          // SoundManager.instance.BGMplay("swing", clip2);
           

        }
        else if (distance <= 10.0f)
        {
            this.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, Speed);
//            Debug.Log("catch pang");

            animator.SetBool("Attack", false);


        }
        else
        {
            base.villainMove();
            //base.NontargetShoot();
//            Debug.Log("where pang?");
        }
    }
    IEnumerator Attacking()
    { 
        //animation Attack
        while (true)
        {
            animator.SetBool("Attack", true);

            
            yield return new WaitForSeconds(attacktime);
           // SoundManager.instance.BGMplay("swing", clip2);
            

            animator.SetBool("Attack", false);
        }
        

    }


    void OnTriggerEnter2D(Collider2D a)
    {
        if (a.gameObject.tag == "mainbullet")
        {
  //          Debug.Log("? ??");
//            Debug.Log(HP.fillAmount);
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

