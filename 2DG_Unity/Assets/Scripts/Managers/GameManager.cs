using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� ������Ʈ(���ӸŴ���)�� ��ũ��Ʈ ����
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] goGameUI = null;
    [SerializeField] GameObject goTitleUI = null;



    public static GameManager instance;



    public bool isStartGame = false;


    ComboManager combomanager;
    ScoreManager scoreManager;
    TimingManager timingManager;
    StatusManager statusManager;
    PlayerController playerController;





    void Start()
    {
        instance = this;

        combomanager = FindObjectOfType<ComboManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        timingManager = FindObjectOfType<TimingManager>();
        statusManager = FindObjectOfType<StatusManager>();
    }

   
    public void GameStart()
    {
        //��� ����UI�� Ȱ��ȭ�Ҷ����� �ݺ�
        for(int i=0; i<goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(true);
        }
        isStartGame = true;

        combomanager.Resetcombo();
        scoreManager.Initialized();
        timingManager.Initialized();
        statusManager.Initialized();

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
