using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//빈 오브젝트(메뉴-타이틀)에 스크립트 넣어줌
public class TitleMenu : MonoBehaviour
{


    [SerializeField] GameObject goStageUI = null;

    public void ButtonPlay()
    {
        //타이틀의 플레이버튼을 누르면, 스테이지메뉴가 활성화하고 타이틀은 비활성화된다
        goStageUI.SetActive(true);
        this.gameObject.SetActive(false);



    }

}
