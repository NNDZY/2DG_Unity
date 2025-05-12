using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 ��Ʈ�� ���� ������ ���ϰ� �÷��̾� �Է½� ������ �����
 
 �迭 ���
 
 */

public class TimingManager : MonoBehaviour
{
    //������ ��Ʈ�������� ����Ʈ
    public List<GameObject> createdNoteList = new List<GameObject>();


    //������ �߽����� ����
    [SerializeField] private Transform correctTiming = null;

    //������ ������ �迭�� ����(p,g,g,b,m)
    [SerializeField] private RectTransform[] timingRect = null;


    //���� ������ ��ġ����(�ּ�~�ִ밪)
    Vector2[] timingPositions = null;



    private void Awake()
    {
        //�迭�� ũ�� : ������ ������ŭ
        timingPositions = new Vector2[timingRect.Length];

        //Ÿ�̹���ġ ���� : ������ ���鼭 Ÿ�̹��������� �߽ɿ��� ���ݸ�ŭ �̵��ϵ��� �ۼ�
        for(int i=0; i<timingRect.Length; i++)
        {
            //Set(x,y) : ������ġ�� �߽ɿ��� ���������� ���ݸ�ŭ �A������ �̵��� ������ ��Ÿ��(=����������ŭ�� ������ �ȴ�)
            timingPositions[i].Set(correctTiming.localPosition.x - timingRect[i].rect.width / 2, correctTiming.localPosition.x + timingRect[i].rect.width / 2);
        }

    }

    //������ ��Ʈ����Ʈ�� ���鼭, ������ġ�� ������ŭ ��Ʈ�� ��ġ�� �����ϰ�
    //��Ʈ�� �ּ�~�ִ밪 ���̿� �ִٸ� �ش� ������ ����ض�. �ƿ� ����ٸ� �̽��� ���
    public void CheckTiming()
    {
        //��Ʈ����Ʈ�� ���鼭
        for(int j=0; j<createdNoteList.Count; j++)
        {
            //�����ȳ�Ʈ�� ����
            float notePosX = createdNoteList[j].transform.localPosition.x;

            //��������� ���鼭
            for(int k=0; k<timingPositions.Length; k++)
            {
                //��Ʈ ��ġ�� �������� �����
                if (notePosX >= timingPositions[k].x && notePosX <= timingPositions[k].y)
                {
                    Debug.Log("���� :" + k);
                    return;
                }


            }

        }
        Debug.Log("Miss");

    }
}
