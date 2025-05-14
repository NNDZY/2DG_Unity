using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//���������ӿ� ��ũ��Ʈ ����
//���Ϳ� ��Ʈ�� ������ �뷡 �÷���
public class CenterFrame : MonoBehaviour
{

    AudioSource myAudio;

    bool musicStart = false;




    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!musicStart)
        {
            
            //��Ʈ �±׿� ������ ������� �÷���
            if(collision.CompareTag("Note"))
            {
                myAudio.Play();
                musicStart = true;
            }
        }

    }

}
