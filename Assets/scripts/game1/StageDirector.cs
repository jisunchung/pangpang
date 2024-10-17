using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageDirector : MonoBehaviour
{
    public static int stageNumber;

    //지선추가변수
    public static int acc=0;
    //public static int mycoin = 0;

    public GameObject villain1;
    public GameObject villain2;

    public GameObject villain3;

    public GameObject villain4;

    public GameObject villain5;

    public GameObject villain6;

    GameObject MonsterDirector;

    public static int killCount;

    int finNum;

    // Start is called before the first frame update
    void Start()
    {
        killCount = 0;
      

        MonsterDirector = GameObject.Find("MonsterDirector");


//        Debug.Log("킬 카운트 초기화     " + killCount);
  //      Debug.Log("몇마리 죽여야하나요     " + finNum);
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log("몇마리!!!!!!"+ killCount);

        
      
       
    }
    public void gohome()
    {
        GameDirector.totalCoin+= maincharac.coinPoint;
        acc = 0;
        maincharac.coinPoint = 0;
        //maincharac.lifePoint = 0;
        SceneManager.LoadScene("Home");
    }

    public void goGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }


}
