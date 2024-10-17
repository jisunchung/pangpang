using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showtime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = System.DateTime.Now.ToString("yyyy년MM월dd일 "+"HH시mm분ss초 tt");
    }
}
