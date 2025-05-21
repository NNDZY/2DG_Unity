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
    public GameObject goUI = null;

    //����
    [SerializeField] TMP_Text[] txtCount = null;

    //����, �ִ��޺�
    [SerializeField] TMP_Text txtScore = null;
    [SerializeField] TMP_Text txtMaxCombo = null;

    int currentSong = 0;

    ComboManager comboManager;
    TimingManager timingManager;


<<<<<<< Updated upstream
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
=======
    private void Start()
    {

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream

        scenechanger.GotoResultScene();

        //���â�� ������ �÷��������� ����� 
        FindObjectOfType<CenterFrame>().ResetMusic();
=======
        isResultShown = true;
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
        goUI.SetActive(false);
<<<<<<< Updated upstream
        GameManager.instance.MainMenu();
        comboManager.Resetcombo();
=======
        GameManager.instance.GoMainMenu();
        isResultShown = false;
        AudioManager.instance.PlayBGM("MainBGM");

>>>>>>> Stashed changes
=======
        AudioManager.instance.PlaySFX("Choice");
        goUI.SetActive(false);
        GameManager.instance.GoMainMenu();
        AudioManager.instance.PlayBGM("MainBGM");
>>>>>>> Stashed changes
    }

}
