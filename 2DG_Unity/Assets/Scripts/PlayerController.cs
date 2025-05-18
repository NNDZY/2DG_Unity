using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




//빈 오브젝트(플레이어컨트롤러)에 스크립트삽입
/*
키 입력시 타이밍매니저에 있는 판정을 불러와야함 


 */
public class PlayerController : MonoBehaviour
{
    



    //게임이 종료될때 플레이어 키 입력 방지
    public static bool s_canPressKey = true;


    TimingManager timingManager;


    SceneChanger sceneChanger;
    Result result;


    void Start()
    {
        timingManager = FindObjectOfType<TimingManager>();
        sceneChanger = FindObjectOfType<SceneChanger>();
        result = FindObjectOfType<Result>();
    }


    void Update()
    {

        if(GameManager.instance.isStartGame)
        {
            //A,D,스페이스바 압력으로 나눠줘야함
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(s_canPressKey)
                {

                    timingManager.CheckTiming();
                }
            
                

            }


        }


        //만약 A키를 눌렀을때 그 노트가 R이라면
        //if (Input.GetKeyDown(KeyCode.A) &&ObjectPool.instance.noteQueueR)
        //{
        //    timingManager.CheckTiming();
        //}

    }




    public void Initialized()
    {
        s_canPressKey = true;
    }


}
