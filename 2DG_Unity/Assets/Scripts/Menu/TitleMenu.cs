using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�� ������Ʈ(�޴�-Ÿ��Ʋ)�� ��ũ��Ʈ �־���
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
        //Ÿ��Ʋ�� �÷��̹�ư�� ������, ���������޴��� Ȱ��ȭ�ϰ� Ÿ��Ʋ�� ��Ȱ��ȭ�ȴ�
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
