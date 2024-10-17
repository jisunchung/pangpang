using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundcontrol : MonoBehaviour
{
    //button
    [SerializeField] Image soundONIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateBtnIcon();
        AudioListener.pause = muted;

    }
    private void Awake()
    {

    }
    //Scene별로 사운도 조절

    //사운드 버튼
    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
            Debug.Log("안들림");
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
            Debug.Log("들림");
        }
        Save();
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;

    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
    private void UpdateBtnIcon()
    {
        if (muted == false)
        {
            soundONIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else if (muted == true)
        {
            soundONIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }
}
