using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//UI-�� ������Ʈ(Score)����� ��ũ��Ʈ ����

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;


    [SerializeField] TMP_Text txtScore = null;

    //������ �󸶳� ������ų�� ���� ����
    [SerializeField] int increaseScore = 10;

    //���� ������ ���� ����
    int currentScore = 0;


    //������ ���� ������ ����ġ�� �ε��� �迭�� ����
    [SerializeField] float[] weight = null;     //�Ҽ������
    [SerializeField] int comboBonusScore = 10;


    ComboManager comboManager;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);  // �ߺ� ����
        }
        instance = this;

        //�� �Ѿ�� ����(�θ� ���� ������Ʈ���� ���� ����)
        //DontDestroyOnLoad(gameObject); 

    }


    void Start()
    {
        comboManager = FindObjectOfType<ComboManager>();

        //���� ������ 0���� ����
        currentScore = 0;
        txtScore.text = "0";
    }


    //�� ������ �����ϸ� �ʱ�ȭ�ϱ�
    public void Initialized()
    {
        currentScore = 0;
        txtScore.text = "0";

    }
    //������ �����ϴ� �Լ�(�޺�, ���� ����ġ �ݿ�)
    public void IncreaseScore(int p_judgementState)
    {        
        comboManager.IncreaseCombo();   //�޺� ����

        //�޺� ���ʽ��������

        //�޺��Ŵ������� ���� �޺��� �������� ����
        int t_currentCombo = comboManager.GetCurrentCombo();
        //�޺��� ������ ���߽�Ű�� ���� ����(�޺��� 10�� ����������, 10���ڸ��� *���ʽ����ھ�(10)��ŭ ���� �÷���)
        int t_bonusComboScore = (t_currentCombo / 10) * comboBonusScore;

        //���� ����ġ ���(weight)
        int t_increaseScore = increaseScore + t_bonusComboScore;
        t_increaseScore = (int)(t_increaseScore * weight[p_judgementState]);



        //���� ���
        currentScore += t_increaseScore;
        txtScore.text = string.Format("{0:#,##0}", currentScore);


    }
    //���� ������ �������� �Լ�
    public int GetCurrentScore()
    {
        return currentScore;
    }

}
