using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//�� ������Ʈ(�÷��̾���Ʈ�ѷ�)�� ��ũ��Ʈ����
/*
Ű �Է½� Ÿ�ָ̹Ŵ����� �ִ� ������ �ҷ��;��� 


 */
public class PlayerController : MonoBehaviour
{

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
