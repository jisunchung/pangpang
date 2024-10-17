using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//------------------
using Firebase;
using Firebase.Database;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;
using UnityEngine.UI;
//----------------

public class HomeManager : MonoBehaviour
{

    public GameObject HomePanel;
    [SerializeField]        //private 변수를 인스펙터 창에서 접근 가능하도록 함.
    GameObject GamePanel;
    [SerializeField]
    GameObject SettingPanel;
    [SerializeField]
    GameObject ShopPanel;
    [SerializeField]
    GameObject RankingPanel;
    [SerializeField]
    GameObject copyright;
    [SerializeField]
    GameObject credit;

    public AudioClip clip;

    GameObject lockbtn;

    public GameObject pang;

    public bool iscalc = true;


    //-----------------
    public DatabaseReference reference { get; set; }
    public static string namelist = "";
    public static string scorelist = "";
    //-----------------------

    // Start is called before the first frame update


    void Start()
    {



        SoundManager.instance.BGMplay("button", clip);
        HomePanel.SetActive(true);        //setActive는 인스펙터에 있는 체크 박스를 조정할 수 있게해줌
        GamePanel.SetActive(false);
        SettingPanel.SetActive(false);
        ShopPanel.SetActive(false);
        pang.SetActive(true);
        RankingPanel.SetActive(false);


    }

    //버튼 인스펙터의 onclick 이벤트에 homeManager스크립트를 추가해서 아래의 함수 연결시 버튼을 클릭하면 그 함수를
    //실행하도록 할 수 있다. 
    public void backtohome()
    {
        SoundManager.instance.BGMplay("button", clip);
        HomePanel.SetActive(true);
        GamePanel.SetActive(false);
        SettingPanel.SetActive(false);
        ShopPanel.SetActive(false);
        pang.SetActive(true);
        RankingPanel.SetActive(false);

        namelist = "";
        scorelist = "";
    }
    public void goGamePanel()
    {
        SoundManager.instance.BGMplay("button", clip);
        HomePanel.SetActive(false);
        GamePanel.SetActive(true);
        SettingPanel.SetActive(false);
        ShopPanel.SetActive(false);
        pang.SetActive(false);
        RankingPanel.SetActive(false);


    }

    public void goSettingPanel()
    {
        SoundManager.instance.BGMplay("button", clip);
        HomePanel.SetActive(false);
        GamePanel.SetActive(false);
        SettingPanel.SetActive(true);
        ShopPanel.SetActive(false);
        pang.SetActive(false);
        RankingPanel.SetActive(false);

    }
    public void showcopyright()
    {
        SoundManager.instance.BGMplay("button", clip);
        copyright.SetActive(true);
    }
    public void backsetting()
    {
        SoundManager.instance.BGMplay("button", clip);
        copyright.SetActive(false);
    }
    public void showcredit()
    {
        SoundManager.instance.BGMplay("button", clip);
        credit.SetActive(true);
    }
    public void creditbacksetting()
    {
        SoundManager.instance.BGMplay("button", clip);
        credit.SetActive(false);
    }
    public void goRankingPanel()
    {
        SoundManager.instance.BGMplay("button", clip);
        HomePanel.SetActive(false);
        GamePanel.SetActive(false);
        SettingPanel.SetActive(false);
        ShopPanel.SetActive(false);
        pang.SetActive(true);
        RankingPanel.SetActive(true);



        //--------------------------------------------------------------------
        reference = FirebaseDatabase.DefaultInstance.GetReference("users");
        // 사용하고자 하는 데이터를 reference가 가리킴
        // 여기선 rank 데이터 셋에 접근

        Dictionary<string, int> ranking = new Dictionary<string, int>();
        List<string> name = new List<string>();
        List<int> score = new List<int>();


        reference.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            { // 성공적으로 데이터를 가져왔으면

                Debug.Log("안녕");
                DataSnapshot snapshot = task.Result;
                // 데이터를 출력하고자 할때는 Snapshot 객체 사용함



                foreach (DataSnapshot data in snapshot.Children)
                {
                    IDictionary info = (IDictionary)data.Value;

                    //Debug.Log(info["Name"]);
                    //Debug.Log(info["score"]);


                    string name = info["Name"].ToString();
                    int score = int.Parse(info["score"].ToString());

                    //Debug.Log(name);
                    //Debug.Log(score.ToString());

                    ranking.Add(name, score);




                    //Debug.Log("이름: " + info["name"] + ", 점수: " + info["score"]);
                    // JSON은 사전 형태이기 때문에 딕셔너리 형으로 변환
                }
                var query = ranking.OrderByDescending(x => x.Value);

                foreach (var item in query)
                {
                    //int i = 0;
                    //Debug.Log(i.ToString());
                    //int rank = query.IndexOf(item);
                    //var index = item.i;
                    Debug.Log(item.Key.ToString());
                    Debug.Log(item.Value.ToString());

                    name.Add(item.Key.ToString());
                    score.Add(item.Value);

                    //r += item.Key.ToString() + "    " + item.Value.ToString() + "\r\n";

                }
                for (int i = 0; i < 5; i++)
                {
                    namelist += (i + 1).ToString() + "위   " + name[i].ToString() + "\r\n";
                    scorelist += score[i].ToString() + "\r\n";
                    Debug.Log(name[i].ToString());

                }
                Debug.Log(scorelist);
            }
        });

        //---------------------------------------
    }
    public void goShopPanel()
    {
        SoundManager.instance.BGMplay("button", clip);
        HomePanel.SetActive(false);
        GamePanel.SetActive(false);
        SettingPanel.SetActive(false);
        ShopPanel.SetActive(true);
        pang.SetActive(true);
        RankingPanel.SetActive(false);


        //현재 아이디의 옷장을 보여줌.
        if (iscalc)
        {
            for (int i = 0; i < 5; i++)
            {
                Debug.Log(i);

                lockbtn = GameObject.Find("lock" + (i + 1));
                if (GameDirector.closet[i] == 1)
                {
                    lockbtn.SetActive(false);
                    iscalc = false;
                }
            }
        }

    }
    public void goShootingGame()
    {
        SoundManager.instance.BGMplay("button", clip);
        SceneManager.LoadScene("loadingScene");
    }
}