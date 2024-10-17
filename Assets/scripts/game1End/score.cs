using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Firebase;
using Firebase.Database;




public class score : MonoBehaviour
{
    
    public DatabaseReference reference { get; set; }
  

    // Start is called before the first frame update
    void Start()
    {

        this.GetComponent<Text>().text = (maincharac.coinPoint * 100).ToString();
        GameDirector.totalCoin = GameDirector.totalCoin + (maincharac.coinPoint * 100);
        GameDirector.stagelevel += 1;


        reference = FirebaseDatabase.DefaultInstance.GetReference("users");

        reference.GetValueAsync().ContinueWith(task =>
        {


            if (task.IsCompleted)
            { // 성공적으로 데이터를 가져왔으면
//                Debug.Log("업데이트");
                reference.Child(GameDirector.ID).Child("score").SetValueAsync(GameDirector.stagelevel);

                reference.Child(GameDirector.ID).Child("totalCoin").SetValueAsync(GameDirector.totalCoin);


            }
        });

    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void gotoHome()
    {
        SceneManager.LoadScene("Home");
    }
    public void gotoLoad()
    {
        SceneManager.LoadScene("loadingScene");
    }
}
