using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.U2D;

public class villaintest1 : baseVillain
{


    //audio
    public AudioClip clip;
    public AudioClip clip2;

    GameObject monsterDirec;
    GameObject maincharac;

    int direc_temp_x;
    int direc_temp_y;
    int direc;
    private void Start()
    {
        monsterDirec = GameObject.Find("MonsterDirector");

        maincharac = GameObject.Find("maincharac");


    }


    //new 왜 쓰는지 모름.. 
    new void Update()
    {
        base.Update();
        villainmove();
        //base.targetShoot();
        //base.colorchange();
        base.NontargetShoot();
    }


    void OnTriggerEnter2D(Collider2D a)
    {
        if (a.gameObject.tag == "mainbullet")
        {
  //          Debug.Log("? ??");
//            Debug.Log(HP.fillAmount);
            HP.fillAmount -= 0.1f;
            SoundManager.instance.BGMplay("attacked", clip2);
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

    public void villainmove()
    {


        villainMoveTimer += Time.deltaTime;

        if (villainMoveTimer > villainMoveRate)
        {
            villainMoveTimer = 0;

            if (maincharac != null)
            {
                if (transform.position.x < maincharac.transform.position.x) direc_temp_x = 1;
                else direc_temp_x = 2;

                if (transform.position.y < maincharac.transform.position.y) direc_temp_y = 3;
                else direc_temp_y = 4;
                if (Mathf.Abs(transform.position.x - maincharac.transform.position.x) < 2 * Mathf.Abs(transform.position.y - maincharac.transform.position.y))
                    direc = direc_temp_y;
                else direc = direc_temp_x;

            }
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

}
