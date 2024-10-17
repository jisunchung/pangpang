using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


using Firebase;
using Firebase.Database;

public class loadingScene : MonoBehaviour
{

    public DatabaseReference reference { get; set; }
    int finish;


    // Start is called before the first frame update
    void Start()
    {
        maincharac.coinPoint = 0;
        loginButton.positions.Clear();
        loginButton.monsters.Clear();
        Vec();
        countmon();
        Debug.Log("몬스타는 몇마리일까요 과연" + StageDirector.acc);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("끝났나??     "+finish);

        if (finish == 1) enterGame();
    }
    public void countmon()
    {
        reference = FirebaseDatabase.DefaultInstance.GetReference("stageInfo");

        reference.GetValueAsync().ContinueWith(task =>
        {


            if (task.IsCompleted)
            { // 성공적으로 데이터를 가져왔으면

                DataSnapshot snapshot = task.Result;
                // 데이터를 출력하고자 할때는 Snapshot 객체 사용함
                foreach (DataSnapshot stageinfo in snapshot.Children) //스테이지정보들
                {

                    if (stageinfo.Key == GameDirector.stagelevel.ToString()) //스테이지 키들
                    {
                        StageDirector.acc = int.Parse(stageinfo.Value.ToString());
                    }
                }
            }
        });
        }

    public void Vec()
    {

        reference = FirebaseDatabase.DefaultInstance.GetReference("stage");


        reference.GetValueAsync().ContinueWith(task =>
        {


            if (task.IsCompleted)
            { // 성공적으로 데이터를 가져왔으면

                DataSnapshot snapshot = task.Result;
                // 데이터를 출력하고자 할때는 Snapshot 객체 사용함
                foreach (DataSnapshot stageinfo in snapshot.Children) //스테이지정보들
                {

                    if (stageinfo.Key == GameDirector.stagelevel.ToString()) //스테이지 키들
                    {
                        Debug.Log(GameDirector.stagelevel.ToString());

                        foreach (DataSnapshot monster in stageinfo.Children)    //몬스터1,2,3,4,5,6
                        {


                            int mon;
                            mon = int.Parse(monster.Value.ToString());
                                loginButton.monsters.Add(mon);

                            
                        }
                    }
                }
                finish = 1;
            }


        });



    }


    public void enterGame()
    {
        SceneManager.LoadScene("Game1");
    }
}
