using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 노트의 판정 범위를 정하고 플레이어 입력시 판정을 출력함
 
 배열 사용
 
 */
//UI-노트에 스크립트를 넣어준다

public class TimingManager : MonoBehaviour
{
    //생성된 노트프리팹의 리스트
    public List<GameObject> createdNoteList = new List<GameObject>();

    //판정이 몇개였는지 담을 배열 작성
    int[] judgementRecord = new int[5];


    //판정의 중심점을 지정
    [SerializeField] private Transform correctTiming = null;

    //판정의 범위를 배열로 설정(p,g,g,b,m)
    [SerializeField] private RectTransform[] timingRect = null;


    //실제 판정할 위치범위(최소~최대값)
    Vector2[] timingPositions = null;


    EffectManager effectManager;
    ScoreManager scoreManager;
    ComboManager comboManager;
    StatusManager statusManager;



    private void Start()
    {
        effectManager = FindObjectOfType<EffectManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        comboManager = FindObjectOfType<ComboManager>();
        statusManager = FindObjectOfType<StatusManager>();



        //배열의 크기 : 판정의 개수만큼
        timingPositions = new Vector2[timingRect.Length];

        //타이밍위치 설정 : 포문을 돌면서 타이밍포지션의 중심에서 절반만큼 이동하도록 작성
        for(int i=0; i<timingRect.Length; i++)
        {
            //Set(x,y) : 판정위치의 중심에서 판정범위의 절반만큼 얖옆으로 이동한 범위를 나타냄(=판정범위만큼의 범위가 된다)
            timingPositions[i].Set(correctTiming.localPosition.x - timingRect[i].rect.width / 2,
                                   correctTiming.localPosition.x + timingRect[i].rect.width / 2);
        }

    }

    //생성된 노트리스트를 돌면서, 판정위치의 개수만큼 노트의 위치를 판정하고
    //노트가 최소~최대값 사이에 있다면 해당 판정을 출력해라. 아예 벗어났다면 미스를 출력
    public void CheckTiming()
    {
        //노트리스트를 돌면서
        for(int j=0; j<createdNoteList.Count; j++)
        {
            //생성된노트의 위치변수
            float notePosX = createdNoteList[j].transform.localPosition.x;


            //판정목록을 돌면서(0부터 돌아야 퍼펙트부터 내려가면서 판정함)
            for (int k=0; k<timingPositions.Length; k++)
            {
                //노트 위치가 판정범위 내라면
                if (notePosX >= timingPositions[k].x && notePosX <= timingPositions[k].y)
                {
                    //노트를 숨기고, 리스트에서 지우기
                    createdNoteList[j].GetComponent<Note>().HideNote();
                    createdNoteList.RemoveAt(j);


                    //판정이 퍼펙, 그레잍,굿일때만 이펙트 호출
                    if (k<timingPositions.Length-1)
                    {
                        //타격이펙트
                        effectManager.NoteHitEffect();
                        //판정이펙트
                        effectManager.JudgementEffect(k);
                    }
                    //점수 증가시키고, 판정횟수를 기록
                    scoreManager.IncreaseScore(k);
                    judgementRecord[k]++;
                    //체력이 증가하는 콤보횟수를 체크
                    statusManager.CheckHPCombo();

                    //맞는 판정을 찾았다면 반복문을 나와라
                    return;
                }


            }

        }
        //타이밍이 아예 안맞으면 콤보 리셋. 미스이펙트 호출, 미스 판정횟수 기록
        comboManager.Resetcombo();
        effectManager.JudgementEffect(4);
        MissRecord();

        //미스일경우 체력 감소
        statusManager.DecreaseHP(1);


        //if(!statusManager.IsGameOver())



    }

    public void MissRecord()
    {
        //미스 판정횟수 기록
        judgementRecord[4]++;
        //체력회복콤보를 리셋
        statusManager.ResetHPCombo();
    }


    //저장된 판정을 가져옴
    public int[] GetJudgementRecord()
    {
        return judgementRecord;
    }


}
