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
            //A,D,�����̽��� �з����� ���������
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(s_canPressKey)
                {

                    timingManager.CheckTiming();
                }
            
                

            }


        }


        //���� AŰ�� �������� �� ��Ʈ�� R�̶��
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
