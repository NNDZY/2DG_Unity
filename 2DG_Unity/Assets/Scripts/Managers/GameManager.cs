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



    public bool isStartGame;
    public bool isGameOver;


    ComboManager combomanager;
    TimingManager timingManager;
    StatusManager statusManager;
    PlayerController playerController;
    NoteManager noteManager;
    Result result;





    void Start()
    {
        instance = this;

        isStartGame = false;
        isGameOver = false;

        noteManager = FindObjectOfType<NoteManager>();
        combomanager = FindObjectOfType<ComboManager>();
        timingManager = FindObjectOfType<TimingManager>();
        statusManager = FindObjectOfType<StatusManager>();
        playerController = FindObjectOfType<PlayerController>();
        result = FindObjectOfType<Result>();

    }

   //스테이지->게임시작 클릭시 실행될 함수
    public void GameStart(int p_songNum, int p_bpm)
    {
        //모든 게임UI를 활성화할때까지 반복
        for(int i=0; i<goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(true);
        }

        //게임시작시 bpm을 변화시킨다
        noteManager.bpm = p_bpm;

        //노트스폰 배열을 처음으로 되돌린다
        noteManager.ResetNote();
        noteManager.MoveNote();


        //게임 재시작시 기록을 초기화
        combomanager.ResetMaxCombo();   //최고콤보 초기화
        combomanager.ResetCurrentcombo();   //현재콤보 초기화
        timingManager.Initialized();    //판정기록 초기화
        statusManager.Initialized();    //체력 회복
        ScoreManager.instance.Initialized();
        result.SetCurrentSong(p_songNum);

        AudioManager.instance.StopBGM();

        result.isResultShown = false;
        isStartGame = true;
        isGameOver = false;
    }


    public void GameOver()
    {
        NoteManager.instance.RemoveNote();     //노트를 지움
        isStartGame = false;
        isGameOver = true;
        result.isResultShown = true;

        result.ShowResult();          //죽으면 결과창 출력
    }

    
    public void GoMainMenu()
    {
        AudioManager.instance.PlayBGM("BGM4");

        //모든 게임UI를 비활성화할때까지 반복
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(false);
        }
        goTitleUI.SetActive(true);

    }



}
