using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//곡을 고를 수 있도록 클래스를 만듬
[System.Serializable]
public class Song
{
    public string name;
    public string composer;
    public int bpm;
    public Sprite sprite;

}




//빈 오브젝트(메뉴-스테이지메뉴)에 스크립트 넣어줌
public class StageMenu : MonoBehaviour
{
    //노래 정보를 표시
    [SerializeField] Song[] songList = null;
    [SerializeField] TMP_Text txtSongName = null;
    [SerializeField] TMP_Text txtSongComposer = null;
    [SerializeField] Image imgDisk = null;


    [SerializeField] GameObject titleMenu = null;


    //현재 노래가 무엇인지 담을 변수
    int currentSong = 0;



    






    Result result;

    private void Start()
    {
        result = FindObjectOfType<Result>();
    }



    //타이틀메뉴 활성화, 스테이지메뉴 비활성화, 결과 비활성화
    public void ButtonBack()
    {
        titleMenu.SetActive(true);
        this.gameObject.SetActive(false);
        result.goUI.SetActive(false);
    }




    public void ButtonPlay()
    {
        //플레이버튼을 누르면 게임이 시작되고, 스테이지메뉴를 비활성화함
        this.gameObject.SetActive(false);
        result.goUI.SetActive(false);
        GameManager.instance.GameStart();
    }

}
