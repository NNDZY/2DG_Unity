using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�ν�����â���� ���������ϰ� ��
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;



}



//�� ������Ʈ(������Ŵ���)���� �� �־���

public class AudioManager : MonoBehaviour
{

    //��𼭵� ȣ�� �����ϵ��� �ν��Ͻ��� ������ش�
    public static AudioManager instance;



    [SerializeField] Sound[] sfx = null;
    [SerializeField] Sound[] bgm = null;


    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource[] sfxPlayer = null;


    void Start()
    {
        instance = this;
    }


    //����� ����Լ�
    public void PlayBGM(string p_bgmName)
    {
        for(int i=0; i<bgm.Length; i++)
        {
            //�Ķ������ �̸��� �ش� bgm�迭 ���� �̸��� ���ٸ� �迭[i]�� Ŭ������ ��ü�ϰ� ����Ѵ�
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

    //ȿ���� ����Լ�
    public void PlaySFX(string p_sfxName)
    {
        for(int i=0; i<sfx.Length; i++)
        {
            //�Ķ������ �̸��� �ش� bgm�迭 ���� �̸��� ���ٸ� �迭[i]�� Ŭ������ ��ü�ϰ� ����Ѵ�
            if(p_sfxName == sfx[i].name)
            {
               
                for(int x=0; x<sfxPlayer.Length; i++)
                {

                    //�뷡�� ������� �ƴ϶��
                    if (!sfxPlayer[x].isPlaying)
                    {
                        //x��°�� ȿ�������� ��ü�ϰ� ���
                        sfxPlayer[x].clip = sfx[x].clip;
                        sfxPlayer[x].Play();
                        return;
                    }


                }
                //������ ���� ���Ƶ� ������� �ƴ� �迭�� ���ٸ�
                Debug.Log("��� ������� �����");
                return;


            }
        }
        Debug.Log(p_sfxName + "ȿ������ ��Ͽ� ����");

    }
}
