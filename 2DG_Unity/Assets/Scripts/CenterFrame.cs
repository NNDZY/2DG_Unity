using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//센터프레임에 스크립트 삽입
//센터에 노트가 닿으면 노래 플레이
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
            
            //노트 태그에 닿으면 오디오를 플레이
            if(collision.CompareTag("Note"))
            {
                AudioManager.instance.PlayBGM("bgm1");
                musicStart = true;
            }
        }

    }

}
