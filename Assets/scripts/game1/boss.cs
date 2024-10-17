using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : baseVillain
{
    // Start is called before the first frame update

    // Update is called once per frame
    //float time = 0;

    new void Update()
    {
        base.Update();
        base.villainMove();
        base.targetShoot();
        //base.NontargetShoot();


        
            //if (time < 3f)
            //{
            //    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time / 3);

            //}
            //else
            //{
            //    time = 0;
            //    this.gameObject.SetActive(false);
            //}
            //time += Time.deltaTime;
            //this.gameObject.SetActive(true);

            //this.gameObject.transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 20.0f, 0.0f);



    }

    //public void resetanim()
    //{
    //    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    //    this.gameObject.SetActive(true);
    //    time = 0;
    //}
        
}
