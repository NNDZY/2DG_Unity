using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPlate : MonoBehaviour
{
    //�뷡�� ������ ȣ���� ��Ʈ?
    NoteManager noteManager;
    Result result;

  

    private void Start()
    {
        result = FindObjectOfType<Result>();
        noteManager = FindObjectOfType<NoteManager>();
        
    }

    //�����Ʈ�� �������� ����������带 �÷���
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayGround"))
        {
            AudioManager.instance.PlaySFX("Fanfare");
            PlayerController.s_canPressKey = false;
            noteManager.RemoveNote();
            result.ShowResult();
        }




    }

}
