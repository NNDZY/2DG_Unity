using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� ������Ʈ(���ӸŴ���)�� ��ũ��Ʈ ����
public class GameManager : MonoBehaviour
{
    //�����÷��̽� Ȱ��ȭ��ųUI�� �迭�θ����
    [SerializeField] GameObject[] goGameUI = null;
    [SerializeField] GameObject goTitleUI = null;



    public static GameManager instance;



    public bool isStartGame = false;


    ComboManager combomanager;
    TimingManager timingManager;
    StatusManager statusManager;
    PlayerController playerController;
    NoteManager noteManager;
    Result result;

    //��Ȱ��ȭ�� �Ķ���ʹ� �ҷ��ü� ��� �ν����ͷ� ���� �־������
    [SerializeField] CenterFrame theMusic;




    void Start()
    {
        instance = this;

        noteManager = FindObjectOfType<NoteManager>();
        combomanager = FindObjectOfType<ComboManager>();
        timingManager = FindObjectOfType<TimingManager>();
        statusManager = FindObjectOfType<StatusManager>();
        playerController = FindObjectOfType<PlayerController>();
        result = FindObjectOfType<Result>();

    }

   
    public void GameStart(int p_songNum, int p_bpm)
    {
        //��� ����UI�� Ȱ��ȭ�Ҷ����� �ݺ�
        for(int i=0; i<goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(true);
        }

        theMusic.bgmName = "BGM" + p_songNum;

        //���ӽ��۽� bpm�� ��ȭ��Ų��
        noteManager.bpm = p_bpm;

        //���� ����۽� ����� �ʱ�ȭ
        combomanager.Resetcombo();
        timingManager.Initialized();
        statusManager.Initialized();
        playerController.Initialized();
        ScoreManager.instance.Initialized();
        result.SetCurrentSong(p_songNum);

        AudioManager.instance.StopBGM();


        isStartGame = true;
    }

    
    public void MainMenu()
    {
        //��� ����UI�� ��Ȱ��ȭ�Ҷ����� �ݺ�
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(false);
        }

        goTitleUI.SetActive(true);

    }



}
