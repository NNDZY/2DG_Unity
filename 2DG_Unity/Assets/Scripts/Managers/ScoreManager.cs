using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//UI-�� ������Ʈ(Score)����� ��ũ��Ʈ ����

public class ScoreManager : MonoBehaviour
{

    [SerializeField] TMP_Text txtScore = null;

    //������ �󸶳� ������ų�� ���� ����
    [SerializeField] int increaseScore = 10;

    //���� ������ ���� ����
    int currentScore = 0;


    //������ ���� ������ ����ġ�� �ε��� �迭�� ����
    [SerializeField] float[] weight = null;     //�Ҽ������
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

        //���� ������ 0���� ����
        currentScore = 0;
        txtScore.text = "0";
    }


    //������ �����ϴ� �Լ�(�޺�, ���� ����ġ �ݿ�)
    public void IncreaseScore(int p_judgementState)
    {
        //�޺� ����
        comboManager.IncreaseCombo();


        //�޺� ���ʽ��������

        //�޺��Ŵ������� ���� �޺��� �������� ����
        int t_currentCombo = comboManager.GetCurrentCombo();
        //�޺��� ������ ���߽�Ű�� ���� ����(�޺��� 10�� ����������, 10���ڸ��� *���ʽ����ھ�(10)��ŭ ���� �÷���)
        int t_bonusComboScore = (t_currentCombo / 10) * comboBonusScore;
        int t_increaseScore = increaseScore + t_bonusComboScore;

        //���� ����ġ ���(weight)
        t_increaseScore = (int)(t_increaseScore * weight[p_judgementState]);



        //���� ���
        currentScore += t_increaseScore;
        txtScore.text = string.Format("{0:#,##0}", currentScore);


        //���� �ִϸ��̼�
        animator.SetTrigger("ScoreUp");


    }



    //���� ������ �������� �Լ�
    public int GetCurrentScore()
    {
        return currentScore;
    }





}
