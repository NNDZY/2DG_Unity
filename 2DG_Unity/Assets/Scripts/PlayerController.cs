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

<<<<<<< Updated upstream
=======



>>>>>>> Stashed changes
    void Start()
    {
        timingManager = FindObjectOfType<TimingManager>();
    }
    void Update()
    {

        if(GameManager.instance.isStartGame)
        {
            if (!GameManager.instance.isGameOver)
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
}
