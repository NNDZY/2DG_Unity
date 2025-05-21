using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//체력/쉴드..?를 관리하기 위한 스크립트. 일단 입력하고 안맞으면 폐기
//체력 감소는 타이밍매니저(입력범위가 미스인 경우),노트매니저(노트를 놓쳤을 경우)에서 호출함
public class StatusManager : MonoBehaviour
{


    public int maxHP;

    private int currentHP;

    public Image fill;




    //몇콤보마다 체력이 회복되는지 설정
    [SerializeField] int increaseHPCombo;
    int currentHPCombo = 0;


<<<<<<< Updated upstream
<<<<<<< Updated upstream
    Result result;
    NoteManager noteManager;
=======
>>>>>>> Stashed changes

=======
>>>>>>> Stashed changes

    private void Start()
    {
        currentHP = maxHP;
        fill.fillAmount = 1;

<<<<<<< Updated upstream
<<<<<<< Updated upstream
        result = FindObjectOfType<Result>();
        noteManager = FindObjectOfType<NoteManager>();
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }


    //재시작시 기록을 초기화
    public void Initialized()
    {
        currentHP = maxHP;
        fill.fillAmount = 1;

    }




    //데미지?를 받으면 HP가 줄어드는 함수
    public void DecreaseHP(int inputNum)
    {
        currentHP -= inputNum;

        if(currentHP<=0)
        {
<<<<<<< Updated upstream
            //Debug.Log("게임오버");
            isGameOver = true;
      
            result.ShowResult();          //죽으면 결과창 출력
            noteManager.RemoveNote();     //노트를 지움
=======
            Debug.Log("게임오버");
            GameManager.instance.GameOver();
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
         
>>>>>>> Stashed changes
        }

        fill.fillAmount = (float)currentHP / maxHP;
    }

    //콤보가 쌓이면 체력이 증가하는 함수
    public void IncreaseHP()
    {
        currentHP++;

        if(currentHP>=maxHP)  currentHP = maxHP;
    }

    //체력회복 콤보를 체크하는 함수
    public void CheckHPCombo()
    {
        currentHPCombo++;

        //만약 콤보가 체력회복기준을 넘으면
        if(currentHPCombo>=increaseHPCombo)
        {
            //콤보를 0으로 리셋시키고 체력을 올린다
            currentHPCombo = 0;
            IncreaseHP();
        }
        fill.fillAmount = (float)currentHP / maxHP;
    }

    //중간에 콤보가 끊기면 체력 회복콤보도 리셋되는 함수
    public void ResetHPCombo()
    {
        currentHPCombo = 0;
        fill.fillAmount = (float)currentHP / maxHP;
    }
}
