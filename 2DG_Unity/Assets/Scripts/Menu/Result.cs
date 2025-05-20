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
    //[SerializeField] GameObject goUI = null;
    public GameObject goUI = null;

    //판정
    [SerializeField] TMP_Text[] txtCount = null;

    //점수, 최대콤보
    [SerializeField] TMP_Text txtScore = null;
    [SerializeField] TMP_Text txtMaxCombo = null;

    int currentSong = 0;

    //결과창 생성 여부
    public bool isResultShown = false;


    ComboManager comboManager;
    TimingManager timingManager;
    SceneChanger scenechanger;


    private void Awake()
    {
    }

    private void Start()
    {

        scenechanger = FindObjectOfType<SceneChanger>();
        comboManager = FindObjectOfType<ComboManager>();
        timingManager = FindObjectOfType<TimingManager>();
    }



    public void SetCurrentSong(int p_songNum)
    {
        currentSong = p_songNum;
    }


    public void ShowResult()
    {

        AudioManager.instance.StopBGM();

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
        AudioManager.instance.PlaySFX("Choice");

        goUI.SetActive(false);

        GameManager.instance.GoMainMenu();
    }




}
