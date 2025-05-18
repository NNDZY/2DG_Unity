using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�����͸� �����ϴ¸Ŵ���
//�� ������Ʈ(�����ͺ��̽�)�� ����� ��ũ��Ʈ����
public class DataManager : MonoBehaviour
{


    public int[] score;


    private void Start()
    {
        LoadScore();
    }



    public void SaveScore()
    {

        //PlayerPrefs.SetInt(�������̸�, �����Ͱ�):�����ü�� �����͸� ����(����� �����Ұ�)
        //string, int, float ���尡��
        PlayerPrefs.SetInt("Score1", score[0]);
        PlayerPrefs.SetInt("Score2", score[1]);
        PlayerPrefs.SetInt("Score3", score[2]);
    }


    //����ȵ����͸� �ҷ���
    public void LoadScore()
    {
        //���ھ�1�� Ű���� ������ �־�� �ҷ��� �� ����
        if(PlayerPrefs.HasKey("Score1"))
        {
            score[0] = PlayerPrefs.GetInt("Score1");
            score[1] = PlayerPrefs.GetInt("Score2");
            score[2] = PlayerPrefs.GetInt("Score3");
        }


    }
}
