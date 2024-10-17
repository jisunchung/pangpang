using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//???? ???? ???? ?????? ??????
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    // Start is called before the first frame update
    //?????? instance
    public static SoundManager instance;
    //bgm
    public AudioSource bgmSound;
    //scene?? ???????? ???? ??????
    public AudioClip[] bgmlist;

    //button
    

    void Start()
    {
        
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
            
        }
        else
        {
            Destroy(gameObject);
        }
      
    }
    //??????
    public void BGMplay(string bgmName, AudioClip clip)
    { //?????? ????
        GameObject go = new GameObject("Sound");
        AudioSource banana = go.AddComponent<AudioSource>();
        banana.clip = clip;
        banana.Play();
        banana.volume = 0.1f;

       // Destroy(go, clip.length);

        //enemy???? ??
        GameObject enemy = new GameObject();
        AudioSource dead = enemy.AddComponent<AudioSource>();
        dead.clip = clip;
        dead.Play();
        dead.volume = 3f;

        Destroy(dead, clip.length);

        GameObject coi = new GameObject();
        AudioSource coin = coi.AddComponent<AudioSource>();
        coin.clip = clip;
        coin.Play();
        coin.volume = 0.15f;

        GameObject btn = new GameObject();
        AudioSource start = btn.AddComponent<AudioSource>();
        start.Play();
        start.volume = 0.1f;

        GameObject pa = new GameObject();
        AudioSource swing = pa.AddComponent<AudioSource>();
       swing.Play();
        swing.volume = 0.1f;
        swing.clip = clip;
        Destroy(swing, clip.length);

        GameObject potato = new GameObject();
        AudioSource bomb = potato.AddComponent<AudioSource>();
        bomb.Play();
        bomb.volume = 0.005f;
        bomb.clip = clip;
        Destroy(bomb, clip.length);

        GameObject a = new GameObject();
        AudioSource poi = a.AddComponent<AudioSource>();
        poi.Play();
        poi.volume = 0.2f;
        poi.clip = clip;

        GameObject btn2 = new GameObject();
        AudioSource button = btn2.AddComponent<AudioSource>();
        start.Play();
        start.volume = 0.1f;

        GameObject kk = new GameObject();
        AudioSource attacked = kk.AddComponent<AudioSource>();
        attacked.Play();
        attacked.volume = 0.1f;




    }

    public void BgSoundPlay(AudioClip clip)
    {
        bgmSound.clip = clip;
       // bgmSound.loop = true;
        bgmSound.volume = 0.5f;
        bgmSound.Play();
    }
    
   //Scene???? ?????? ????
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for (int i = 0; i < bgmlist.Length; i++)
        { if(arg0.name == bgmlist[i].name)
            BgSoundPlay(bgmlist[i]);
           

        }
    }
    //???
    
}
