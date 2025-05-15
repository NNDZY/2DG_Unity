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

}




//�� ������Ʈ(�޴�-���������޴�)�� ��ũ��Ʈ �־���
public class StageMenu : MonoBehaviour
{
    //�뷡 ������ ǥ��
    [SerializeField] Song[] songList = null;
    [SerializeField] TMP_Text txtSongName = null;
    [SerializeField] TMP_Text txtSongComposer = null;
    [SerializeField] Image imgDisk = null;


    [SerializeField] GameObject titleMenu = null;


    //���� �뷡�� �������� ���� ����
    int currentSong = 0;



    






    Result result;

    private void Start()
    {
        result = FindObjectOfType<Result>();
    }



    //Ÿ��Ʋ�޴� Ȱ��ȭ, ���������޴� ��Ȱ��ȭ, ��� ��Ȱ��ȭ
    public void ButtonBack()
    {
        titleMenu.SetActive(true);
        this.gameObject.SetActive(false);
        result.goUI.SetActive(false);
    }




    public void ButtonPlay()
    {
        //�÷��̹�ư�� ������ ������ ���۵ǰ�, ���������޴��� ��Ȱ��ȭ��
        this.gameObject.SetActive(false);
        result.goUI.SetActive(false);
        GameManager.instance.GameStart();
    }

}
