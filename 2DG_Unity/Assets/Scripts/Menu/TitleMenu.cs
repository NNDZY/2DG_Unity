using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//빈 오브젝트(메뉴-타이틀)에 스크립트 넣어줌
public class TitleMenu : MonoBehaviour
{



    [SerializeField] GameObject goStageUI = null;
    [SerializeField] GameObject goHowtoUI = null;
<<<<<<< Updated upstream

=======
    [SerializeField] StageMenu stageMenu;
>>>>>>> Stashed changes

    StageMenu stageMenu;

    private void Start()
    {
        stageMenu = FindObjectOfType<StageMenu>();
    }

    public void ButtonStart()
    {
        //타이틀의 플레이버튼을 누르면, 스테이지메뉴가 활성화하고 타이틀은 비활성화된다
        AudioManager.instance.PlaySFX("Choice");
        AudioManager.instance.StopBGM();
<<<<<<< Updated upstream
        AudioManager.instance.StopSFX("Main");
        goStageUI.SetActive(true);
        this.gameObject.SetActive(false);

        stageMenu.SettingSong(); //null
=======
        stageMenu.SettingSong();
>>>>>>> Stashed changes

    }

    public void ButtonHowto()
    {
        AudioManager.instance.PlaySFX("Choice");
        goHowtoUI.SetActive(true);
    }
    public void ButtonHowtoOut()
    {
        AudioManager.instance.PlaySFX("Choice");
        goHowtoUI.SetActive(false);

    }


    public void ButtonHowto()
    {
        AudioManager.instance.PlaySFX("Choice");
        goHowtoUI.SetActive(true);
    }
    public void ButtonHowtoOut()
    {
        AudioManager.instance.PlaySFX("Choice");
        goHowtoUI.SetActive(false);

    }

}
