using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//빈 오브젝트(게임매니저)에 스크립트 삽입
public class GameManager : MonoBehaviour
{
    //게임플레이시 활성화시킬UI를 배열로만든다
    [SerializeField] GameObject[] goGameUI = null;
    [SerializeField] GameObject goTitleUI = null;
<<<<<<< Updated upstream
    [SerializeField] Result result;
=======
    [SerializeField] Result result =null; 
>>>>>>> Stashed changes



    public static GameManager instance;



<<<<<<< Updated upstream
    public bool isStartGame = false;
=======
    public bool isStartGame;
    public bool isGameOver;
>>>>>>> Stashed changes


    ComboManager combomanager;
    TimingManager timingManager;
    StatusManager statusManager;

    //비활성화된 파라미터는 불러올수 없어서 인스펙터로 직접 넣어줘야함




    void Start()
    {
        instance = this;

<<<<<<< Updated upstream
        noteManager = FindObjectOfType<NoteManager>();
=======
        isStartGame = false;
        isGameOver = false;

<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
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

        //theMusic.bgmName = "BGM" + p_songNum;

        //게임시작시 bpm을 변화시킨다
        NoteManager.instance.bpm = p_bpm;
<<<<<<< Updated upstream

<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes

        //노트스폰 배열을 처음으로 되돌린다
        NoteManager.instance.ResetNote();


>>>>>>> Stashed changes
        //게임 재시작시 기록을 초기화
        combomanager.Resetcombo();
        timingManager.Initialized();
        statusManager.Initialized();
        ScoreManager.instance.Initialized();
        result.SetCurrentSong(p_songNum);

        AudioManager.instance.StopBGM();

<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
        isStartGame = true;
        isGameOver = false;

    }

<<<<<<< Updated upstream
    
    public void MainMenu()
=======


     public void GameOver()
    {
        isStartGame = false;
        isGameOver = true;
        result.isResultShown = false;

        NoteManager.instance.RemoveNote();     //노트를 지움
        result.ShowResult();          //죽으면 결과창 출력

    }

<<<<<<< Updated upstream
=======
    
    public void GoMainMenu()
    {
        AudioManager.instance.PlayBGM("MainBGM");
>>>>>>> Stashed changes

    public void GoMainMenu()
>>>>>>> Stashed changes
    {
        //모든 게임UI를 비활성화할때까지 반복
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(false);
        }

        goTitleUI.SetActive(true);

    }



}
