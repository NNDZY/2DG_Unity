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



    public bool isStartGame;
    public bool isGameOver;


    ComboManager combomanager;
    TimingManager timingManager;
    StatusManager statusManager;
    PlayerController playerController;
    NoteManager noteManager;
    Result result;





    void Start()
    {
        instance = this;

        isStartGame = false;
        isGameOver = false;

        noteManager = FindObjectOfType<NoteManager>();
        combomanager = FindObjectOfType<ComboManager>();
        timingManager = FindObjectOfType<TimingManager>();
        statusManager = FindObjectOfType<StatusManager>();
        playerController = FindObjectOfType<PlayerController>();
        result = FindObjectOfType<Result>();

    }

   //��������->���ӽ��� Ŭ���� ����� �Լ�
    public void GameStart(int p_songNum, int p_bpm)
    {
        //��� ����UI�� Ȱ��ȭ�Ҷ����� �ݺ�
        for(int i=0; i<goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(true);
        }

        //���ӽ��۽� bpm�� ��ȭ��Ų��
        noteManager.bpm = p_bpm;

        //��Ʈ���� �迭�� ó������ �ǵ�����
        noteManager.ResetNote();
        noteManager.MoveNote();


        //���� ����۽� ����� �ʱ�ȭ
        combomanager.ResetMaxCombo();   //�ְ��޺� �ʱ�ȭ
        combomanager.ResetCurrentcombo();   //�����޺� �ʱ�ȭ
        timingManager.Initialized();    //������� �ʱ�ȭ
        statusManager.Initialized();    //ü�� ȸ��
        ScoreManager.instance.Initialized();
        result.SetCurrentSong(p_songNum);

        AudioManager.instance.StopBGM();

        result.isResultShown = false;
        isStartGame = true;
        isGameOver = false;
    }


    public void GameOver()
    {
        NoteManager.instance.RemoveNote();     //��Ʈ�� ����
        isStartGame = false;
        isGameOver = true;
        result.isResultShown = true;

        result.ShowResult();          //������ ���â ���
    }

    
    public void GoMainMenu()
    {
        AudioManager.instance.PlayBGM("BGM4");

        //��� ����UI�� ��Ȱ��ȭ�Ҷ����� �ݺ�
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(false);
        }
        goTitleUI.SetActive(true);

    }



}
