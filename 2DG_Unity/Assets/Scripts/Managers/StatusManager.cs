using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;


//ü��/����..?�� �����ϱ� ���� ��ũ��Ʈ. �ϴ� �Է��ϰ� �ȸ����� ���
//ü�� ���Ҵ� Ÿ�ָ̹Ŵ���(�Է¹����� �̽��� ���),��Ʈ�Ŵ���(��Ʈ�� ������ ���)���� ȣ����
public class StatusManager : MonoBehaviour
{

    bool isGameOver = false;

    public int maxHP;

    private int currentHP;

    public Image fill;




    //���޺����� ü���� ȸ���Ǵ��� ����
    [SerializeField] int increaseHPCombo;
    int currentHPCombo = 0;


    Result result;
    //NoteManager noteManager;


    private void Start()
    {
        currentHP = maxHP;
        fill.fillAmount = 1;

        result = FindObjectOfType<Result>();
        //noteManager = FindObjectOfType<NoteManager>();
    }


    //����۽� ����� �ʱ�ȭ
    public void Initialized()
    {
        currentHP = maxHP;
        fill.fillAmount = 1;

        isGameOver = false;
    }




    //������?�� ������ HP�� �پ��� �Լ�
    public void DecreaseHP(int inputNum)
    {
        currentHP -= inputNum;

        if(currentHP<=0)
        {
            //isGameOver = true;
            Debug.Log("���ӿ���");
            result.isResultShown = true;

            result.ShowResult();          //������ ���â ���
            NoteManager.instance.RemoveNote();     //��Ʈ�� ����
            NoteManager.instance.ResetNote();     //��Ʈ�� ����
            
        }

        fill.fillAmount = (float)currentHP / maxHP;
    }

    //�޺��� ���̸� ü���� �����ϴ� �Լ�
    public void IncreaseHP()
    {
        currentHP++;

        if(currentHP>=maxHP)
        {
            currentHP = maxHP;
        }
    }

    //ü��ȸ�� �޺��� üũ�ϴ� �Լ�
    public void CheckHPCombo()
    {
        currentHPCombo++;

        //���� �޺��� ü��ȸ�������� ������
        if(currentHPCombo>=increaseHPCombo)
        {
            //�޺��� 0���� ���½�Ű�� ü���� �ø���
            currentHPCombo = 0;
            IncreaseHP();
        }
        fill.fillAmount = (float)currentHP / maxHP;

    }

    //�߰��� �޺��� ����� ü�� ȸ���޺��� ���µǴ� �Լ�
    public void ResetHPCombo()
    {
        currentHPCombo = 0;
        fill.fillAmount = (float)currentHP / maxHP;
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
}
