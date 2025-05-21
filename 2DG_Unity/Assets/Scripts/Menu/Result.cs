 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//빈 오브젝트 UI-Result에 스크립트 넣어줌

public class Result : MonoBehaviour
{

    //결과창에 들어갈 수치 입력(판정, 점수, 콤보)

    //ui에 접근
    public GameObject goUI = null;

    //판정
    [SerializeField] TMP_Text[] txtCount = null;

    //점수, 최대콤보
    [SerializeField] TMP_Text txtScore = null;
    [SerializeField] TMP_Text txtMaxCombo = null;

    int currentSong = 0;

    ComboManager comboManager;
    TimingManager timingManager;


<<<<<<< Updated upstream
    private void Awake()
    {
<<<<<<< Updated upstream
        DontDestroyOnLoad(this.gameObject);
        scenechanger = FindObjectOfType<SceneChanger>();
=======
        //DontDestroyOnLoad(this.gameObject);
>>>>>>> Stashed changes
    }

    private void Start()
    {
=======
    private void Start()
    {

>>>>>>> Stashed changes
        comboManager = FindObjectOfType<ComboManager>();
        timingManager = FindObjectOfType<TimingManager>();
    }
    public void SetCurrentSong(int p_songNum)
    {
        currentSong = p_songNum;
    }


    public void ShowResult()
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream

        scenechanger.GotoResultScene();

        //결과창이 나오면 플레이음악을 멈춘다 
        FindObjectOfType<CenterFrame>().ResetMusic();
=======
        isResultShown = true;
>>>>>>> Stashed changes

        AudioManager.instance.StopBGM();


=======

        AudioManager.instance.StopBGM();

>>>>>>> Stashed changes
        //UI창 활성화
        goUI.SetActive(true);


        //판정 배열 포문 돌려주기
        for(int i=0; i<txtCount.Length; i++)
        {
            txtCount[i].text = "0";
        }

        txtScore.text = "0";
        txtMaxCombo.text = "0";

        //결과창에 기록될 숫자
        int[] t_judgement = timingManager.GetJudgementRecord(); //판정
        int t_currentScore = ScoreManager.instance.GetCurrentScore();    //스코어
        int t_maxCombo = comboManager.GetMaxCombo();    //최대콤보


        //판정을 받은 횟수를 기록한 포문
        for(int i = 0; i<txtCount.Length; i++)
        {
            txtCount[i].text = string.Format("{0:#,##0}",t_judgement[i]);
        }

        txtScore.text = string.Format("{0:#,##0}", t_currentScore);
        txtMaxCombo.text = string.Format("{0:#,##0}", t_maxCombo);

    }


    public void ButtonMainMenu()
    {
<<<<<<< Updated upstream
        goUI.SetActive(false);
<<<<<<< Updated upstream
        GameManager.instance.MainMenu();
        comboManager.Resetcombo();
=======
        GameManager.instance.GoMainMenu();
        isResultShown = false;
        AudioManager.instance.PlayBGM("MainBGM");

>>>>>>> Stashed changes
=======
        AudioManager.instance.PlaySFX("Choice");
        goUI.SetActive(false);
        GameManager.instance.GoMainMenu();
        AudioManager.instance.PlayBGM("MainBGM");
>>>>>>> Stashed changes
    }

}
