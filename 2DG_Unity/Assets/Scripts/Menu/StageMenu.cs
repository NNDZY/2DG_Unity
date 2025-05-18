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

    //[SerializeField] TMP_Text txtSongScore = null;


    [SerializeField] GameObject titleMenu = null;


    //DataManager dataManager;


    //현재 노래가 무엇인지 담을 변수
    int currentSong = 0;


    void Start()
    {
        //if(dataManager==null)
        //{ 
        //dataManager = FindObjectOfType<DataManager>();
        //}

        SettingSong();
    }



    //버튼을 누르면 다음노래로 이동/끝이면 처음으로 이동
    public void ButtonNext()
    {
        //클릭할때마다 효과음재생
        AudioManager.instance.PlaySFX("Switch");

        if (++currentSong>songList.Length-1)
        {
            currentSong = 0;
        }
        //노래를 바꿀때마다 곡 정보 호출
        SettingSong();
    }



    //처음이면 끝으로 이동(위와 반대)
    public void ButtonPrior()
    {
        //클릭할때마다 효과음재생
        AudioManager.instance.PlaySFX("Switch");
        if (--currentSong<0)
        {
            currentSong = songList.Length - 1;
        }
        //노래를 바꿀때마다 곡 정보 호출
        SettingSong();
    }

    


    //현재 곡에대한 정보를 반영하는 함수
    public void SettingSong()
    {
        txtSongName.text = songList[currentSong].name;
        txtSongComposer.text = songList[currentSong].composer;
        imgDisk.sprite = songList[currentSong].sprite;

        AudioManager.instance.PlayBGM("BGM" + (currentSong+1));

        //txtSongScore.text = string.Format("{0:#,##0}", dataManager.score[currentSong]);
    }







    //타이틀메뉴 활성화, 스테이지메뉴 비활성화
    public void ButtonBack()
    {
        titleMenu.SetActive(true);
        this.gameObject.SetActive(false);
        AudioManager.instance.StopBGM();
    }




    public void ButtonPlay()
    {
        
        int t_bpm = songList[currentSong].bpm;


        //플레이버튼을 누르면 게임이 시작되고, 스테이지메뉴를 비활성화함
        GameManager.instance.GameStart(currentSong, t_bpm);
        this.gameObject.SetActive(false);

        SettingSong();

    }

}
