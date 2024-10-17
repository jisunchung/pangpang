using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class coin : MonoBehaviour
{

    //audio
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D a)
    {

        if (a.gameObject.name == "maincharac")
        {
           
            //효과음
            SoundManager.instance.BGMplay("coin", clip);
            Destroy(gameObject);
            
          //  Debug.Log("누적수");
           // Debug.Log(StageDirector.acc);
            //Debug.Log("코인+하트 갯수");
            //Debug.Log(maincharac.coinPoint );

        
            
        }

    }
    void OnDestroy()
    {
        Debug.Log("띵동");

        maincharac.coinPoint += 1;  //지선수정
    }

}
