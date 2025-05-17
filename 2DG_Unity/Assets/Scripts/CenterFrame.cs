using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//���������ӿ� ��ũ��Ʈ ����
//���Ϳ� ��Ʈ�� ������ �뷡 �÷���
public class CenterFrame : MonoBehaviour
{


    bool musicStart = false;


    public string bgmName = "";


    NoteManager noteManager;


    private void Start()
    {
        noteManager = FindObjectOfType<NoteManager>();
    }

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
                AudioManager.instance.PlayBGM(bgmName);
                musicStart = true;
            }
        }
        //��������Ʈ�� ������ ���ķ��Ҹ��� ��
        if (collision.CompareTag("Finish"))
        {
            //audioSource.Play();
            AudioManager.instance.PlaySFX("Fanfare");
            PlayerController.s_canPressKey = false;
            noteManager.RemoveNote();

        }


    }

}
