using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//빈 오브젝트(플레이어컨트롤러)에 스크립트삽입
/*
키 입력시 타이밍매니저에 있는 판정을 불러와야함 


 */
public class PlayerController : MonoBehaviour
{

    //게임이 종료될때 플레이어 키 입력 방지
    public static bool s_canPressKey = true;


    TimingManager timingManager;


    void Start()
    {
        timingManager = FindObjectOfType<TimingManager>();
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            timingManager.CheckTiming();

        }

        
    }



}
