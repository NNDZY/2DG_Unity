using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPlate : MonoBehaviour
{
    //노래가 끝나면 호출할 노트?
    NoteManager noteManager;
    Result result;

  

    private void Start()
    {
        result = FindObjectOfType<Result>();
        noteManager = FindObjectOfType<NoteManager>();
        
    }

    //종료노트가 지나가면 게임종료사운드를 플레이
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
