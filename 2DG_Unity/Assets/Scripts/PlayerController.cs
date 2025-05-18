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
    



    //������ ����ɶ� �÷��̾� Ű �Է� ����
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
            if (s_canPressKey)
            {
                
                if (Input.GetKeyDown(KeyCode.LeftArrow))    //��ƮR
                {
                    timingManager.CheckTiming(0);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))   //��ƮB
                {
                    timingManager.CheckTiming(1);
                }

                if (Input.GetKeyDown(KeyCode.Space))        //��ƮY
                {
                    timingManager.CheckTiming(2);
                }
            }
        }

    }




    public void Initialized()
    {
        s_canPressKey = true;
    }


}
