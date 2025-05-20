using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�� ������Ʈ(�޴�-Ÿ��Ʋ)�� ��ũ��Ʈ �־���
public class TitleMenu : MonoBehaviour
{



    [SerializeField] GameObject goStageUI = null;
    [SerializeField] GameObject goHowtoUI = null;


    StageMenu stageMenu;

    private void Start()
    {
        stageMenu = FindObjectOfType<StageMenu>();
    }

    public void ButtonStart()
    {
        //Ÿ��Ʋ�� �÷��̹�ư�� ������, ���������޴��� Ȱ��ȭ�ϰ� Ÿ��Ʋ�� ��Ȱ��ȭ�ȴ�
        AudioManager.instance.PlaySFX("Choice");
        AudioManager.instance.StopBGM();
        AudioManager.instance.StopSFX("Main");
        goStageUI.SetActive(true);
        this.gameObject.SetActive(false);

        stageMenu.SettingSong(); //null



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
