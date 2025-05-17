using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//센터프레임에 스크립트 삽입
//센터에 노트가 닿으면 노래 플레이
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
            
            //노트 태그에 닿으면 오디오를 플레이
            if(collision.CompareTag("Note"))
            {
                AudioManager.instance.PlayBGM(bgmName);
                musicStart = true;
            }
        }
        //마지막노트가 닿으면 팡파레소리를 냄
        if (collision.CompareTag("Finish"))
        {
            //audioSource.Play();
            AudioManager.instance.PlaySFX("Fanfare");
            PlayerController.s_canPressKey = false;
            noteManager.RemoveNote();

        }


    }

}
