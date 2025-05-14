using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//UI-빈 오브젝트(Score)만들고 스크립트 삽입

public class ScoreManager : MonoBehaviour
{

    [SerializeField] TMP_Text txtScore = null;

    //점수를 얼마나 증가시킬지 변수 설정
    [SerializeField] int increaseScore = 10;

    //현재 점수를 담을 변수
    int currentScore = 0;


    //판정에 따라 점수에 가중치를 두도록 배열을 만듬
    [SerializeField] float[] weight = null;     //소수점사용
    [SerializeField] int comboBonusScore = 10;


    Animator animator;
    ComboManager comboManager;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Start()
    {
        comboManager = FindObjectOfType<ComboManager>();

        //최초 점수를 0으로 설정
        currentScore = 0;
        txtScore.text = "0";
    }


    //점수가 증가하는 함수(콤보, 판정 가중치 반영)
    public void IncreaseScore(int p_judgementState)
    {
        //콤보 증가
        comboManager.IncreaseCombo();


        //콤보 보너스점수계산

        //콤보매니저에서 현재 콤보를 가져오는 변수
        int t_currentCombo = comboManager.GetCurrentCombo();
        //콤보시 점수를 가중시키는 변수 설정(콤보가 10씩 오를때마다, 10의자리수 *보너스스코어(10)만큼 점수 플러스)
        int t_bonusComboScore = (t_currentCombo / 10) * comboBonusScore;
        int t_increaseScore = increaseScore + t_bonusComboScore;

        //판정 가중치 계산(weight)
        t_increaseScore = (int)(t_increaseScore * weight[p_judgementState]);



        //점수 출력
        currentScore += t_increaseScore;
        txtScore.text = string.Format("{0:#,##0}", currentScore);


        //점수 애니메이션
        animator.SetTrigger("ScoreUp");


    }



    //현재 점수를 가져오는 함수
    public int GetCurrentScore()
    {
        return currentScore;
    }





}
