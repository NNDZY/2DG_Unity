using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//빈 오브젝트(메뉴-스테이지메뉴)에 스크립트 넣어줌
public class StageMenu : MonoBehaviour
{

    [SerializeField] GameObject titleMenu = null;

    public void ButtonBack()
    {
        titleMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }




    public void ButtonPlay()
    {
        //플레이버튼을 누르면 게임이 시작되고, 스테이지메뉴를 비활성화함
        GameManager.instance.GameStart();
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
