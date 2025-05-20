 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//�� ������Ʈ UI-Result�� ��ũ��Ʈ �־���

public class Result : MonoBehaviour
{

    //���â�� �� ��ġ �Է�(����, ����, �޺�)

    //ui�� ����
    //[SerializeField] GameObject goUI = null;
    public GameObject goUI = null;

    //����
    [SerializeField] TMP_Text[] txtCount = null;

    //����, �ִ��޺�
    [SerializeField] TMP_Text txtScore = null;
    [SerializeField] TMP_Text txtMaxCombo = null;

    int currentSong = 0;

    ComboManager comboManager;
    TimingManager timingManager;


    private void Awake()
    {
<<<<<<< Updated upstream
        DontDestroyOnLoad(this.gameObject);
        scenechanger = FindObjectOfType<SceneChanger>();
=======
        //DontDestroyOnLoad(this.gameObject);
>>>>>>> Stashed changes
    }

    private void Start()
    {
        comboManager = FindObjectOfType<ComboManager>();
        timingManager = FindObjectOfType<TimingManager>();
    }



    public void SetCurrentSong(int p_songNum)
    {
        currentSong = p_songNum;
    }


    public void ShowResult()
    {
<<<<<<< Updated upstream

        scenechanger.GotoResultScene();

        //���â�� ������ �÷��������� ����� 
        FindObjectOfType<CenterFrame>().ResetMusic();

        AudioManager.instance.StopBGM();


=======

        AudioManager.instance.StopBGM();

>>>>>>> Stashed changes
        //UIâ Ȱ��ȭ
        goUI.SetActive(true);


        //���� �迭 ���� �����ֱ�
        for(int i=0; i<txtCount.Length; i++)
        {
            txtCount[i].text = "0";
        }

        txtScore.text = "0";
        txtMaxCombo.text = "0";

        //���â�� ��ϵ� ����
        int[] t_judgement = timingManager.GetJudgementRecord(); //����
        int t_currentScore = ScoreManager.instance.GetCurrentScore();    //���ھ�
        int t_maxCombo = comboManager.GetMaxCombo();    //�ִ��޺�


        //������ ���� Ƚ���� ����� ����
        for(int i = 0; i<txtCount.Length; i++)
        {
            txtCount[i].text = string.Format("{0:#,##0}",t_judgement[i]);
        }

        txtScore.text = string.Format("{0:#,##0}", t_currentScore);
        txtMaxCombo.text = string.Format("{0:#,##0}", t_maxCombo);

    }


    public void ButtonMainMenu()
    {
        goUI.SetActive(false);
<<<<<<< Updated upstream
        GameManager.instance.MainMenu();
        comboManager.Resetcombo();
=======
        GameManager.instance.GoMainMenu();
        isResultShown = false;
        AudioManager.instance.PlayBGM("MainBGM");

>>>>>>> Stashed changes
    }

}
