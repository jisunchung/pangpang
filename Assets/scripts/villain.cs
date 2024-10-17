using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class villain : MonoBehaviour
{

    public GameObject villainbullet1;

    GameObject maincharac;
    public float span = 1;
    public float span2 = 0.3f;


    //audio
    public AudioClip clip;

    float delta = 0;
    float delta2 = 0;

    public float villainSpeed;

    GameObject villainHP;


    float x;
    float y;
    float angle;

    //아이템떨구는부분 변수
    public GameObject coin;
    public GameObject life;


    // Start is called before the first frame update
    void Start()
    {
        maincharac = GameObject.Find("maincharac");

        villainHP = GameObject.Find("villainHP");



    }

    // Update is called once per frame
    void Update()
    {
        villainHP.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, -1.3f, 0));

        delta += Time.deltaTime;
        delta2 += Time.deltaTime;

        if (delta > span)
        {
            

            delta = 0;
            GameObject go = Instantiate(villainbullet1) as GameObject;
            go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);


            x = transform.position.x - maincharac.transform.position.x;
            y = transform.position.y - maincharac.transform.position.y;

            angle = Mathf.Atan2(Mathf.Abs(y), Mathf.Abs(x)) * Mathf.Rad2Deg;

            if (x < 0 && y < 0)
                go.transform.Rotate(0, 0, angle);

            else if (x > 0 && y < 0)
                go.transform.Rotate(0, 0, 180-angle);
            else if (x < 0 && y > 0)
                go.transform.Rotate(0, 0,-angle);

            else
                go.transform.Rotate(0, 0, 180+angle);


        }
        if (delta2 > span)
        {
            delta2 = 0;
            int direc = Random.Range(1, 5);
            Debug.Log(direc);
            switch (direc)
            {
                case 1:
                    transform.Translate(1 * villainSpeed, 0, 0);
                    break;

                case 2:
                    transform.Translate(-1 * villainSpeed, 0, 0);
                    break;
                case 3:
                    transform.Translate(0, 1 * villainSpeed, 0);
                    break;
                case 4:
                    transform.Translate(0, -1 * villainSpeed, 0);
                    break;


            }

        }
    }
    void OnTriggerEnter2D(Collider2D a)
    {
        if(a.gameObject.tag=="mainbullet")
        villainHP.GetComponent<Image>().fillAmount -= 0.1f;

        if (villainHP.GetComponent<Image>().fillAmount == 0)
        {
            item();
            Destroy(gameObject);
            SoundManager.instance.BGMplay("dead", clip);
        }

    }

    void item()
    {
        int item = Random.Range(1, 3);
        if (item == 1)
        {
            GameObject coinI = Instantiate(coin) as GameObject;
            coinI.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        }

        else
        {
            GameObject lifeI = Instantiate(life) as GameObject;
            lifeI.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        }
    }

    void endGame1()
    {
        SceneManager.LoadScene("game1End");
    }
}

