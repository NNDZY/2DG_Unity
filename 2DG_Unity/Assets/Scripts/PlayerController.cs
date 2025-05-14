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
    GameManager gameManager;


    void Start()
    {
        timingManager = FindObjectOfType<TimingManager>();
        //statusManager = FindObjectOfType<StatusManager>();
        sceneChanger = FindObjectOfType<SceneChanger>();
        result = FindObjectOfType<Result>();
        gameManager = GameManager.instance;
    }


    void Update()
    {

        if(gameManager.isStartGame)
        {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            timingManager.CheckTiming();

        }

        //��� Ȯ���� ���� �ӽ��ڵ�
        if(Input.GetKeyDown(KeyCode.H))
        {
            //sceneChanger.GotoResultScene();
            result.ShowResult();
        }


        }

        
    }



}
