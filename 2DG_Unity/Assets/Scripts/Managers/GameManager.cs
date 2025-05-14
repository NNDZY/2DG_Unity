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

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

   
    public void GameStart()
    {
        //��� ����UI�� Ȱ��ȭ�Ҷ����� �ݺ�
        for(int i=0; i<goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(true);
        }

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
