using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//데이터를 저장하는매니저
//빈 오브젝트(데이터베이스)를 만들고 스크립트삽입
public class DataManager : MonoBehaviour
{


    public int[] score;


    private void Start()
    {
        LoadScore();
    }



    public void SaveScore()
    {

        //PlayerPrefs.SetInt(데이터이름, 데이터값):기기자체에 데이터를 저장(지우면 복구불가)
        //string, int, float 저장가능
        PlayerPrefs.SetInt("Score1", score[0]);
        PlayerPrefs.SetInt("Score2", score[1]);
        PlayerPrefs.SetInt("Score3", score[2]);
    }


    //저장된데이터를 불러옴
    public void LoadScore()
    {
        //스코어1에 키값을 가지고 있어야 불러올 수 있음
        if(PlayerPrefs.HasKey("Score1"))
        {
            score[0] = PlayerPrefs.GetInt("Score1");
            score[1] = PlayerPrefs.GetInt("Score2");
            score[2] = PlayerPrefs.GetInt("Score3");
        }


    }
}
