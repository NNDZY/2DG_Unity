using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

/*
 ��Ʈ�� ���� ������ ���ϰ� �÷��̾� �Է½� ������ �����
 
 �迭 ���
 
 */
//UI-�÷������� ��ũ��Ʈ�� �־��ش�

public class TimingManager : MonoBehaviour
{
    //������ ��Ʈ�������� ����Ʈ
    public List<GameObject> createdNoteList = new List<GameObject>();

    //������ ������� ���� �迭 �ۼ�
    int[] judgementRecord = new int[5];


    //������ �߽����� ����
    [SerializeField] private Transform correctTiming = null;

    //������ ������ �迭�� ����(p,g,g,b,m)
    [SerializeField] private RectTransform[] timingRect = null;


    //���� ������ ��ġ����(�ּ�~�ִ밪)
    Vector2[] timingPositions = null;


    EffectManager effectManager;
    ComboManager comboManager;
    StatusManager statusManager;


    [SerializeField] RectTransform judgmentLinePrefab;
    [SerializeField] Transform judgmentLineParent; // UI �θ� ������Ʈ
    private void Start()
    {
        effectManager = FindObjectOfType<EffectManager>();
        comboManager = FindObjectOfType<ComboManager>();
        statusManager = FindObjectOfType<StatusManager>();



        //�迭�� ũ�� : ������ ������ŭ
        timingPositions = new Vector2[timingRect.Length];

        //Ÿ�̹���ġ ���� : ������ ���鼭 Ÿ�̹��������� �߽ɿ��� ���ݸ�ŭ �̵��ϵ��� �ۼ�
        for(int i=0; i<timingRect.Length; i++)
        {
            //Set(x,y) : ������ġ�� �߽ɿ��� ���������� ���ݸ�ŭ �A������ �̵��� ������ ��Ÿ��(=����������ŭ�� ������ �ȴ�)
            //timingPositions[i].Set(correctTiming.localPosition.x - timingRect[i].rect.width / 2,
            //                       correctTiming.localPosition.x + timingRect[i].rect.width / 2);
            float leftBound = correctTiming.localPosition.x - timingRect[i].rect.width / 2;  // ���� ����
            float rightBound = correctTiming.localPosition.x + timingRect[i].rect.width / 2; // ������ ����

            timingPositions[i].Set(leftBound, rightBound);


        }




<<<<<<< Updated upstream
        for (int i = 0; i < timingPositions.Length; i++)
        {
            RectTransform clone = Instantiate(judgmentLinePrefab, judgmentLineParent);
            float centerX = (timingPositions[i].x + timingPositions[i].y) / 2f;
            float width = timingPositions[i].y - timingPositions[i].x;

            clone.anchoredPosition = new Vector2(centerX, 0f);
            clone.sizeDelta = new Vector2(width, 10f); // 10�� ����
        }





=======
        //    clone.anchoredPosition = new Vector2(centerX, 0f);
        //    clone.sizeDelta = new Vector2(width, 10f); // 10�� ����
        //}
>>>>>>> Stashed changes
    }

    //������ ��Ʈ����Ʈ�� ���鼭, ������ġ�� ������ŭ ��Ʈ�� ��ġ�� �����ϰ�
    //��Ʈ�� �ּ�~�ִ밪 ���̿� �ִٸ� �ش� ������ ����ض�. �ƿ� ����ٸ� �̽��� ���
    public bool CheckTiming(int lane)
    {
        
        //��Ʈ����Ʈ�� ���鼭
        for (int j=0; j<createdNoteList.Count; j++)
        {
            //nullüũ
            if (createdNoteList[j] == null) continue;


            Note note = createdNoteList[j].GetComponent<Note>();

            // �ش� ������ ��Ʈ�� ����
            if (note.lane != lane) continue;

            //�����ȳ�Ʈ�� ��ġ����
            float notePosX = createdNoteList[j].transform.localPosition.x;

            
            //��������� ���鼭(0���� ���ƾ� ����Ʈ���� �������鼭 ������)
            for (int k=0; k<timingPositions.Length; k++)
            {
                //��Ʈ ��ġ�� �������� �����
                if (notePosX >= timingPositions[k].x && notePosX <= timingPositions[k].y)
                {
                    //��Ʈ�� �����, ����Ʈ���� �����
                    note.HideNote();
                    createdNoteList.RemoveAt(j);
                    j--;


                    //������ ����, �׷���,���϶��� Ÿ������Ʈ ȣ��
                    if (k<timingPositions.Length-1)
                    {                       
                        effectManager.NoteHitEffect();                         
                    }
                    effectManager.JudgementEffect(k);  //��������Ʈ
                    //���� ������Ű��, ����Ƚ���� ���
                    ScoreManager.instance.IncreaseScore(k);
                    judgementRecord[k]++;
                    //ü���� �����ϴ� �޺�Ƚ���� üũ
                    statusManager.CheckHPCombo();

                    //�Է½� ȿ�������
                    audioManager.PlaySFX("Choice");

                    //�´� ������ ã�Ҵٸ� �ݺ����� ���Ͷ�
                    return true;
                }
            }

        }
        //Ÿ�̹��� �ƿ� �ȸ����� �̽�        
        MissRecord();        
        return false;

    }

    //�̽������� ���
    public void MissRecord()
    {
        comboManager.Resetcombo();  //�޺�����
        effectManager.JudgementEffect(4);   //�̽�����Ʈ ȣ��       
        judgementRecord[4]++;   //�̽� ����Ƚ�� ���
        statusManager.DecreaseHP(1);    //ü�� ����
        statusManager.ResetHPCombo();    //ü��ȸ���޺��� ����
    }


    //����� ������ ������
    public int[] GetJudgementRecord()
    {
        return judgementRecord;
    }



    //����۽� ������� �ʱ�ȭ
    public void Initialized()
    {
        for(int i=0; i<judgementRecord.Length; i++)
        {
            judgementRecord[i] = 0;
        }


    }








}
