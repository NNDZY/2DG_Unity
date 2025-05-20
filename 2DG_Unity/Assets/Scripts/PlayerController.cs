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
    





    TimingManager timingManager;


    SceneChanger sceneChanger;


    void Start()
    {
        timingManager = FindObjectOfType<TimingManager>();
        sceneChanger = FindObjectOfType<SceneChanger>();
    }


    void Update()
    {

        if(GameManager.instance.isStartGame)
        {
            if (!GameManager.instance.isGameOver)
            {
                
                if (Input.GetKeyDown(KeyCode.LeftArrow))    //노트R
                {
                    AudioManager.instance.PlaySFX("NoteR");
                    timingManager.CheckTiming(0);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))   //노트B
                {
                    AudioManager.instance.PlaySFX("NoteB");
                    timingManager.CheckTiming(1);
                }

                if (Input.GetKeyDown(KeyCode.Space))        //노트Y
                {
                    AudioManager.instance.PlaySFX("NoteY");
                    timingManager.CheckTiming(2);
                }
            }
        }

    }





}
