using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 ��Ʈ�� ���� ������ ���ϰ� �÷��̾� �Է½� ������ �����
 
 �迭 ���
 
 */
//UI-��Ʈ�� ��ũ��Ʈ�� �־��ش�

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
    ScoreManager scoreManager;
    ComboManager comboManager;
    StatusManager statusManager;



    private void Start()
    {
        effectManager = FindObjectOfType<EffectManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        comboManager = FindObjectOfType<ComboManager>();
        statusManager = FindObjectOfType<StatusManager>();



        //�迭�� ũ�� : ������ ������ŭ
        timingPositions = new Vector2[timingRect.Length];

        //Ÿ�̹���ġ ���� : ������ ���鼭 Ÿ�̹��������� �߽ɿ��� ���ݸ�ŭ �̵��ϵ��� �ۼ�
        for(int i=0; i<timingRect.Length; i++)
        {
            //Set(x,y) : ������ġ�� �߽ɿ��� ���������� ���ݸ�ŭ �A������ �̵��� ������ ��Ÿ��(=����������ŭ�� ������ �ȴ�)
            timingPositions[i].Set(correctTiming.localPosition.x - timingRect[i].rect.width / 2,
                                   correctTiming.localPosition.x + timingRect[i].rect.width / 2);
        }

    }

    //������ ��Ʈ����Ʈ�� ���鼭, ������ġ�� ������ŭ ��Ʈ�� ��ġ�� �����ϰ�
    //��Ʈ�� �ּ�~�ִ밪 ���̿� �ִٸ� �ش� ������ ����ض�. �ƿ� ����ٸ� �̽��� ���
    public void CheckTiming()
    {
        //��Ʈ����Ʈ�� ���鼭
        for(int j=0; j<createdNoteList.Count; j++)
        {
            //�����ȳ�Ʈ�� ��ġ����
            float notePosX = createdNoteList[j].transform.localPosition.x;


            //��������� ���鼭(0���� ���ƾ� ����Ʈ���� �������鼭 ������)
            for (int k=0; k<timingPositions.Length; k++)
            {
                //��Ʈ ��ġ�� �������� �����
                if (notePosX >= timingPositions[k].x && notePosX <= timingPositions[k].y)
                {
                    //��Ʈ�� �����, ����Ʈ���� �����
                    createdNoteList[j].GetComponent<Note>().HideNote();
                    createdNoteList.RemoveAt(j);


                    //������ ����, �׷���,���϶��� ����Ʈ ȣ��
                    if (k<timingPositions.Length-1)
                    {
                        //Ÿ������Ʈ
                        effectManager.NoteHitEffect();
                        //��������Ʈ
                        effectManager.JudgementEffect(k);
                    }
                    //���� ������Ű��, ����Ƚ���� ���
                    scoreManager.IncreaseScore(k);
                    judgementRecord[k]++;
                    //ü���� �����ϴ� �޺�Ƚ���� üũ
                    statusManager.CheckHPCombo();

                    //�´� ������ ã�Ҵٸ� �ݺ����� ���Ͷ�
                    return;
                }


            }

        }
        //Ÿ�̹��� �ƿ� �ȸ����� �޺� ����. �̽�����Ʈ ȣ��, �̽� ����Ƚ�� ���
        comboManager.Resetcombo();
        effectManager.JudgementEffect(4);
        MissRecord();

        //�̽��ϰ�� ü�� ����
        statusManager.DecreaseHP(1);


        //if(!statusManager.IsGameOver())



    }

    public void MissRecord()
    {
        //�̽� ����Ƚ�� ���
        judgementRecord[4]++;
        //ü��ȸ���޺��� ����
        statusManager.ResetHPCombo();
    }


    //����� ������ ������
    public int[] GetJudgementRecord()
    {
        return judgementRecord;
    }


}
