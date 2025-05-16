using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�� ������Ʈ(�޴�-Ÿ��Ʋ)�� ��ũ��Ʈ �־���
public class TitleMenu : MonoBehaviour
{



    [SerializeField] GameObject goStageUI = null;


    StageMenu stageMenu;

    private void Awake()
    {
        stageMenu = FindObjectOfType<StageMenu>();
    }

    public void ButtonStart()
    {
        //Ÿ��Ʋ�� �÷��̹�ư�� ������, ���������޴��� Ȱ��ȭ�ϰ� Ÿ��Ʋ�� ��Ȱ��ȭ�ȴ�
        goStageUI.SetActive(true);
        this.gameObject.SetActive(false);
        AudioManager.instance.PlaySFX("Choice");
        AudioManager.instance.StopBGM();
        //stageMenu.SettingSong(); /null





    }

}
