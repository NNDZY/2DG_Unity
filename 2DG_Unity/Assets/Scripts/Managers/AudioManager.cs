using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//인스펙터창에서 수정가능하게 함
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

}

//빈 오브젝트(오디오매니저)생성 후 넣어줌

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] sfx = null;
    [SerializeField] Sound[] bgm = null;


    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource[] sfxPlayer = null;



    //어디서든 호출 가능하도록 인스턴스로 만들어준다
    public static AudioManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);  // 중복 방지
        }
            instance = this;
            DontDestroyOnLoad(gameObject);  // 씬 넘어가도 유지
     
    }

    //배경음 재생함수
    public void PlayBGM(string p_bgmName)
    {
        for(int i=0; i<bgm.Length; i++)
        {
            //파라미터의 이름과 해당 bgm배열 안의 이름이 같다면 배열[i]의 클립으로 대체하고 재생한다
            if(p_bgmName == bgm[i].name)
            {
                bgmPlayer.clip = bgm[i].clip;
                bgmPlayer.Play();
            }
        }
    }
    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    //효과음 재생함수
    public void PlaySFX(string p_sfxName)
    {
        for(int i=0; i<sfx.Length; i++)
        {
            //파라미터의 이름과 해당 bgm배열 안의 이름이 같다면 배열[i]의 클립으로 대체하고 재생한다
            if(p_sfxName == sfx[i].name)
            {
               
                for(int x=0; x<sfxPlayer.Length; x++)
                {

                    //노래가 재생중이 아니라면
                    if (!sfxPlayer[x].isPlaying)
                    {
                        //x번째의 효과음으로 대체하고 재생
                        sfxPlayer[x].clip = sfx[i].clip;
                        sfxPlayer[x].Play();
                        return;
                    }


                }
                //포문을 전부 돌아도 재생중이 아닌 배열이 없다면
                Debug.Log("모든 오디오가 재생중");
                return;


            }
        }
        Debug.Log(p_sfxName + "효과음이 목록에 없다");

    }
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
}
