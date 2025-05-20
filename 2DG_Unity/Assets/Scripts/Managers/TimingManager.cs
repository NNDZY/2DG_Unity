using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

/*
 노트의 판정 범위를 정하고 플레이어 입력시 판정을 출력함
 
 배열 사용
 
 */
//UI-플레이존에 스크립트를 넣어준다

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
    ComboManager comboManager;
    StatusManager statusManager;


    [SerializeField] RectTransform judgmentLinePrefab;
    [SerializeField] Transform judgmentLineParent; // UI 부모 오브젝트
    private void Start()
    {
        effectManager = FindObjectOfType<EffectManager>();
        comboManager = FindObjectOfType<ComboManager>();
        statusManager = FindObjectOfType<StatusManager>();



        //배열의 크기 : 판정의 개수만큼
        timingPositions = new Vector2[timingRect.Length];

        //타이밍위치 설정 : 포문을 돌면서 타이밍포지션의 중심에서 절반만큼 이동하도록 작성
        for(int i=0; i<timingRect.Length; i++)
        {
            //Set(x,y) : 판정위치의 중심에서 판정범위의 절반만큼 얖옆으로 이동한 범위를 나타냄(=판정범위만큼의 범위가 된다)
            //timingPositions[i].Set(correctTiming.localPosition.x - timingRect[i].rect.width / 2,
            //                       correctTiming.localPosition.x + timingRect[i].rect.width / 2);
            float leftBound = correctTiming.localPosition.x - timingRect[i].rect.width / 2;  // 왼쪽 범위
            float rightBound = correctTiming.localPosition.x + timingRect[i].rect.width / 2; // 오른쪽 범위

            timingPositions[i].Set(leftBound, rightBound);


        }




<<<<<<< Updated upstream
        for (int i = 0; i < timingPositions.Length; i++)
        {
            RectTransform clone = Instantiate(judgmentLinePrefab, judgmentLineParent);
            float centerX = (timingPositions[i].x + timingPositions[i].y) / 2f;
            float width = timingPositions[i].y - timingPositions[i].x;

            clone.anchoredPosition = new Vector2(centerX, 0f);
            clone.sizeDelta = new Vector2(width, 10f); // 10은 높이
        }





=======
        //    clone.anchoredPosition = new Vector2(centerX, 0f);
        //    clone.sizeDelta = new Vector2(width, 10f); // 10은 높이
        //}
>>>>>>> Stashed changes
    }

    //생성된 노트리스트를 돌면서, 판정위치의 개수만큼 노트의 위치를 판정하고
    //노트가 최소~최대값 사이에 있다면 해당 판정을 출력해라. 아예 벗어났다면 미스를 출력
    public bool CheckTiming(int lane)
    {
        
        //노트리스트를 돌면서
        for (int j=0; j<createdNoteList.Count; j++)
        {
            //null체크
            if (createdNoteList[j] == null) continue;


            Note note = createdNoteList[j].GetComponent<Note>();

            // 해당 라인의 노트만 판정
            if (note.lane != lane) continue;

            //생성된노트의 위치변수
            float notePosX = createdNoteList[j].transform.localPosition.x;

            
            //판정목록을 돌면서(0부터 돌아야 퍼펙트부터 내려가면서 판정함)
            for (int k=0; k<timingPositions.Length; k++)
            {
                //노트 위치가 판정범위 내라면
                if (notePosX >= timingPositions[k].x && notePosX <= timingPositions[k].y)
                {
                    //노트를 숨기고, 리스트에서 지우기
                    note.HideNote();
                    createdNoteList.RemoveAt(j);
                    j--;


                    //판정이 퍼펙, 그레잍,굿일때만 타격이펙트 호출
                    if (k<timingPositions.Length-1)
                    {                       
                        effectManager.NoteHitEffect();                         
                    }
                    effectManager.JudgementEffect(k);  //판정이펙트
                    //점수 증가시키고, 판정횟수를 기록
                    ScoreManager.instance.IncreaseScore(k);
                    judgementRecord[k]++;
                    //체력이 증가하는 콤보횟수를 체크
                    statusManager.CheckHPCombo();

                    //입력시 효과음재생
                    audioManager.PlaySFX("Choice");

                    //맞는 판정을 찾았다면 반복문을 나와라
                    return true;
                }
            }

        }
        //타이밍이 아예 안맞으면 미스        
        MissRecord();        
        return false;

    }

    //미스판정일 경우
    public void MissRecord()
    {
        comboManager.Resetcombo();  //콤보리셋
        effectManager.JudgementEffect(4);   //미스이펙트 호출       
        judgementRecord[4]++;   //미스 판정횟수 기록
        statusManager.DecreaseHP(1);    //체력 감소
        statusManager.ResetHPCombo();    //체력회복콤보를 리셋
    }


    //저장된 판정을 가져옴
    public int[] GetJudgementRecord()
    {
        return judgementRecord;
    }



    //재시작시 판정기록 초기화
    public void Initialized()
    {
        for(int i=0; i<judgementRecord.Length; i++)
        {
            judgementRecord[i] = 0;
        }


    }








}
