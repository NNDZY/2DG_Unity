using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//���� �� �� �ֵ��� Ŭ������ ����
[System.Serializable]
public class Song
{
    public string name;
    public string composer;
    public int bpm;
    public Sprite sprite;
    public BMSFile fileName;

}
//�� ������Ʈ(�޴�-���������޴�)�� ��ũ��Ʈ �־���
public class StageMenu : MonoBehaviour
{
    //�뷡 ������ ǥ��
    [SerializeField] Song[] songList = null;
    [SerializeField] TMP_Text txtSongName = null;
    [SerializeField] TMP_Text txtSongComposer = null;
    [SerializeField] Image imgDisk = null;

    //[SerializeField] TMP_Text txtSongScore = null;


    [SerializeField] GameObject titleMenu = null;


    //���� �뷡�� �������� ���� ����
    int currentSong = 0;


    void Start()
    {
        SettingSong();
    }



    //��ư�� ������ �����뷡�� �̵�/���̸� ó������ �̵�
    public void ButtonNext()
    {
        //Ŭ���Ҷ����� ȿ�������
        AudioManager.instance.PlaySFX("Switch");

        if (++currentSong>songList.Length-1)
        {
            currentSong = 0;
        }
        //�뷡�� �ٲܶ����� �� ���� ȣ��
        SettingSong();
    }



    //ó���̸� ������ �̵�(���� �ݴ�)
    public void ButtonPrior()
    {
        //Ŭ���Ҷ����� ȿ�������
        AudioManager.instance.PlaySFX("Switch");
        if (--currentSong<0)
        {
            currentSong = songList.Length - 1;
        }
        //�뷡�� �ٲܶ����� �� ���� ȣ��
        SettingSong();
    }

    


    //���� ����� ������ �ݿ��ϴ� �Լ�
    public void SettingSong()
    {
        txtSongName.text = songList[currentSong].name;
        txtSongComposer.text = songList[currentSong].composer;
        imgDisk.sprite = songList[currentSong].sprite;

        AudioManager.instance.PlayBGM("BGM" + (currentSong+1));

    }


    //Ÿ��Ʋ�޴� Ȱ��ȭ, ���������޴� ��Ȱ��ȭ
    public void ButtonBack()
    {
        AudioManager.instance.PlaySFX("Choice");
        titleMenu.SetActive(true);
        this.gameObject.SetActive(false);
        AudioManager.instance.StopBGM();
        AudioManager.instance.PlayBGM("MainBGM");
    }
    public void ButtonPlay()
    {
        
        int t_bpm = songList[currentSong].bpm;

        AudioManager.instance.PlaySFX("Choice");

        //�÷��̹�ư�� ������ ������ ���۵ǰ�, ���������޴��� ��Ȱ��ȭ��
        GameManager.instance.GameStart(currentSong, t_bpm);
        this.gameObject.SetActive(false);

        SettingSong();

    }

}
