using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterDirector : MonoBehaviour
{


    public GameObject villain1;
    public GameObject villain2;
    public GameObject villain3;
    public GameObject villain4;
    public GameObject villain5;
    public GameObject villain6;



    // Start is called before the first frame update
    void Start()
    {

   

        for (int i=0;i<5;i++)
        {
            for (int j = 0; j < loginButton.monsters[i]; j++)
            {

                if (i == 0)
                {
                    GameObject vill = Instantiate(villain1) as GameObject;
                    float x = Random.Range(8.0f, 42.0f);
                    float y = Random.Range(10.0f, 27.0f);
                    vill.transform.position = new Vector3(x, y, 0);
                }
                else if (i == 1)
                {
                    GameObject vill = Instantiate(villain2) as GameObject;
                    float x = Random.Range(8.0f, 42.0f);
                    float y = Random.Range(10.0f, 27.0f);
                    vill.transform.position = new Vector3(x, y, 0);
                }
                else if (i == 2)
                {
                    GameObject vill = Instantiate(villain3) as GameObject;
                    float x = Random.Range(8.0f, 42.0f);
                    float y = Random.Range(10.0f, 27.0f);
                    vill.transform.position = new Vector3(x, y, 0);
                }
                else if (i == 3)
                {
                    GameObject vill = Instantiate(villain4) as GameObject;
                    float x = Random.Range(8.0f, 42.0f);
                    float y = Random.Range(10.0f, 27.0f);
                    vill.transform.position = new Vector3(x, y, 0);
                }
                else if (i == 4)
                {
                    GameObject vill = Instantiate(villain5) as GameObject;
                    float x = Random.Range(8.0f, 42.0f);
                    float y = Random.Range(10.0f, 27.0f);
                    vill.transform.position = new Vector3(x, y, 0);
                }

            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("몬스타는 몇마리일까요 과연" + StageDirector.acc);

    }
}
 