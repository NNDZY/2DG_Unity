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
    //StatusManager statusManager;


    SceneChanger sceneChanger;
    Result result;


    void Start()
    {
        timingManager = FindObjectOfType<TimingManager>();
        //statusManager = FindObjectOfType<StatusManager>();
        sceneChanger = FindObjectOfType<SceneChanger>();
        result = FindObjectOfType<Result>();
    }


    void Update()
    {

        if(GameManager.instance.isStartGame)
        {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            timingManager.CheckTiming();

        }


        }

        
    }



}
