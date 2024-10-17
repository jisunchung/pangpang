using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    //직렬화 설명
    //접근제한자를 써주지 않으면 기본적으로 private 으로 지정된 것이다.

    //public으로 선언시 인스펙터 창에서는 볼 수 있지만 다른 스크립트에서 접근할 수 있기 때문에 외부 스크립트에서 변경을 하게 되어 오류가 생길수 있다.
    //이러한 상황을 막아주기 위해 [SerializeField]를 사용해 주는 것이다. private 변수를 인스펙터 창에서는 접근 가능하지만 다른 스크립트에서는 접근할 수 없도록!!

    //[SerializeField]사용--> Private 변수이지만 인스펙터 창에서 접근가능해짐

    //serialize는 직렬화 작업을 해주는 것이다. 이것은 추상적인 데이터를 전송과 저장이 가능한 형태로 바꾸는 것을 의미한다. 여기서 우리가 [SerializeField]를 써줌으로
    //유니티가 private변수를 직렬화 하여 전송과 저장이 가능하도록 해주는 것이다. 원래 유니티에서는 public만 직렬화가 가능한데, [SerializeField]를 통해 private도
    //직렬화가 가능해지는 것이다.
    //audio
    public AudioClip clip;

    [SerializeField]
    GameObject StartPanel;
    [SerializeField]
    GameObject IntroPanel;

    //코루틴 설명
    //프레임이 아닌 시간 단위로 특정 작업을 수행하기 위함이다. 다른 예로는 Time.deltaTime이 있다.
    //코루틴은 프레임과 상관없이 별도의 서브 루틴에서 원하는 작업을 원하는 시간만큼 수행하는 것이 가능하다.
    //이 코드는 update()함수에 종속적이지 않으면서 마치 별도의 쓰레드와 같이 동작을 하게된다.
    //이와 같은 코드는 프레임율에 영향을 받지 않는 시간 기반의 서브루틴을 구동할 수 있게 된다.

    //startcoroutine은 IEnumerator를 반환하는 함수를 인자로 받으며, 이 함수(delattime)는 특이하게 실행된 결과값을
    //파라미터로 넘기는 것이 아니라 함수 포인터의 역할을 하는 IEnumerator 열거자를 넘긴다.

    //유니티에서는 유니티 상의 시간을 임의로 느리게 하거나 빠르게 하는 것이 가능하다 Time.timeScale을 통해서 이러한 조정이
    //가능한데, waitforsecnods는 이러한 scaledtime에 영향을 받지 않고 현실 시간을 기준으로만 동작을 하게 된다.
    // Start is called before the first frame update
    //참고 http://theeye.pe.kr/archives/2725

    void Start()
    {
        StartCoroutine(DelayTime(2));           //프렘임율에 영향을 받지 않는 서브루틴 구동
                                         
    }
    IEnumerator DelayTime(float time)           //IEnumerator는 함수 포인터의 역할을 한다.
    {
        yield return new WaitForSeconds(time);  //time 초 동안 멈출 수 있도록 해준다.
        
        IntroPanel.SetActive(false);           //object 활성화 하고싶은것을 정해줌
        StartPanel.SetActive(true); 
    }
   
    public void goHome()
    {
        SoundManager.instance.BGMplay("start", clip);
        SceneManager.LoadScene("main1");
    }
}
