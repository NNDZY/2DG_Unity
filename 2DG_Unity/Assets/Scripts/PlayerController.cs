using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




//�� ������Ʈ(�÷��̾���Ʈ�ѷ�)�� ��ũ��Ʈ����
/*
Ű �Է½� Ÿ�ָ̹Ŵ����� �ִ� ������ �ҷ��;��� 


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
                
                if (Input.GetKeyDown(KeyCode.LeftArrow))    //��ƮR
                {
                    AudioManager.instance.PlaySFX("NoteR");
                    timingManager.CheckTiming(0);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))   //��ƮB
                {
                    AudioManager.instance.PlaySFX("NoteB");
                    timingManager.CheckTiming(1);
                }

                if (Input.GetKeyDown(KeyCode.Space))        //��ƮY
                {
                    AudioManager.instance.PlaySFX("NoteY");
                    timingManager.CheckTiming(2);
                }
            }
        }

    }





}
