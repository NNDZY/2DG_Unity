using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//빈 오브젝트(게임매니저)에 스크립트 삽입
public class GameManager : MonoBehaviour
{
    //게임플레이시 활성화시킬UI를 배열로만든다
    [SerializeField] GameObject[] goGameUI = null;
    [SerializeField] GameObject goTitleUI = null;



    public static GameManager instance;



    public bool isStartGame = false;


    ComboManager combomanager;
    TimingManager timingManager;
    StatusManager statusManager;
    PlayerController playerController;
    NoteManager noteManager;

    //비활성화된 파라미터는 불러올수 없어서 인스펙터로 직접 넣어줘야함
    [SerializeField] CenterFrame theMusic;




    void Start()
    {
        instance = this;

        noteManager = FindObjectOfType<NoteManager>();
        combomanager = FindObjectOfType<ComboManager>();
        timingManager = FindObjectOfType<TimingManager>();
        statusManager = FindObjectOfType<StatusManager>();
    }

   
    public void GameStart(int p_songNum, int p_bpm)
    {
        //모든 게임UI를 활성화할때까지 반복
        for(int i=0; i<goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(true);
        }

        theMusic.bgmName = "BGM" + p_songNum;

        noteManager.bpm = p_bpm;
        combomanager.Resetcombo();
        timingManager.Initialized();
        statusManager.Initialized();
        ScoreManager.instance.Initialized();

        AudioManager.instance.StopBGM();


        isStartGame = true;
    }

    
    public void MainMenu()
    {
        //모든 게임UI를 비활성화할때까지 반복
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(false);
        }

        goTitleUI.SetActive(true);

    }



}
