using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� ������Ʈ(���ӸŴ���)�� ��ũ��Ʈ ����
public class GameManager : MonoBehaviour
{
    //�����÷��̽� Ȱ��ȭ��ųUI�� �迭�θ����
    [SerializeField] GameObject[] goGameUI = null;
    [SerializeField] GameObject goTitleUI = null;
<<<<<<< Updated upstream
    [SerializeField] Result result;
=======
    [SerializeField] Result result =null; 
>>>>>>> Stashed changes



    public static GameManager instance;



<<<<<<< Updated upstream
    public bool isStartGame = false;
=======
    public bool isStartGame;
    public bool isGameOver;
>>>>>>> Stashed changes


    ComboManager combomanager;
    TimingManager timingManager;
    StatusManager statusManager;

    //��Ȱ��ȭ�� �Ķ���ʹ� �ҷ��ü� ��� �ν����ͷ� ���� �־������




    void Start()
    {
        instance = this;

<<<<<<< Updated upstream
        noteManager = FindObjectOfType<NoteManager>();
=======
        isStartGame = false;
        isGameOver = false;

<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        combomanager = FindObjectOfType<ComboManager>();
        timingManager = FindObjectOfType<TimingManager>();
        statusManager = FindObjectOfType<StatusManager>();

    }

   
    public void GameStart(int p_songNum, int p_bpm)
    {
        //��� ����UI�� Ȱ��ȭ�Ҷ����� �ݺ�
        for(int i=0; i<goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(true);
        }

        //theMusic.bgmName = "BGM" + p_songNum;

        //���ӽ��۽� bpm�� ��ȭ��Ų��
        NoteManager.instance.bpm = p_bpm;
<<<<<<< Updated upstream

<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes

        //��Ʈ���� �迭�� ó������ �ǵ�����
        NoteManager.instance.ResetNote();


>>>>>>> Stashed changes
        //���� ����۽� ����� �ʱ�ȭ
        combomanager.Resetcombo();
        timingManager.Initialized();
        statusManager.Initialized();
        ScoreManager.instance.Initialized();
        result.SetCurrentSong(p_songNum);

        AudioManager.instance.StopBGM();

<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
        isStartGame = true;
        isGameOver = false;

    }

<<<<<<< Updated upstream
    
    public void MainMenu()
=======


     public void GameOver()
    {
        isStartGame = false;
        isGameOver = true;
        result.isResultShown = false;

        NoteManager.instance.RemoveNote();     //��Ʈ�� ����
        result.ShowResult();          //������ ���â ���

    }

<<<<<<< Updated upstream
=======
    
    public void GoMainMenu()
    {
        AudioManager.instance.PlayBGM("MainBGM");
>>>>>>> Stashed changes

    public void GoMainMenu()
>>>>>>> Stashed changes
    {
        //��� ����UI�� ��Ȱ��ȭ�Ҷ����� �ݺ�
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(false);
        }

        goTitleUI.SetActive(true);

    }



}
