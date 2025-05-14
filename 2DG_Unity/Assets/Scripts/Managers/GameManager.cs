using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//빈 오브젝트(게임매니저)에 스크립트 삽입
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
        //모든 게임UI를 활성화할때까지 반복
        for(int i=0; i<goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(true);
        }

        isStartGame = true;

    }

    
    public void MainMenu()
    {
        //모든 게임UI를 비활성화할때까지 반복
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(false);
        }

        goTitleUI.SetActive(true);

    }



}
