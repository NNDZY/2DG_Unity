using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//���������ӿ� ��ũ��Ʈ ����
//���Ϳ� ��Ʈ�� ������ �뷡 �÷���
public class CenterFrame : MonoBehaviour
{


    bool musicStart = false;


    public void ResetMusic()
    {
        musicStart = false;
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!musicStart)
        {
            
            //��Ʈ �±׿� ������ ������� �÷���
            if(collision.CompareTag("Note"))
            {
                AudioManager.instance.PlayBGM("bgm1");
                musicStart = true;
            }
        }

    }

}
