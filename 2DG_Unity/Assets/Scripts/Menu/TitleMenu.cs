using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�� ������Ʈ(�޴�-Ÿ��Ʋ)�� ��ũ��Ʈ �־���
public class TitleMenu : MonoBehaviour
{
    [SerializeField] GameObject goStageUI = null;
<<<<<<< Updated upstream

    [SerializeField] StageMenu stageMenu;

=======
    [SerializeField] GameObject goHowtoUI = null;
    [SerializeField] StageMenu stageMenu;
>>>>>>> Stashed changes

    public void ButtonStart()
    {
        //Ÿ��Ʋ�� �÷��̹�ư�� ������, ���������޴��� Ȱ��ȭ�ϰ� Ÿ��Ʋ�� ��Ȱ��ȭ�ȴ�
        goStageUI.SetActive(true);
        this.gameObject.SetActive(false);
        AudioManager.instance.PlaySFX("Choice");
        AudioManager.instance.StopBGM();
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        //stageMenu.SettingSong(); /null


=======
=======
        goStageUI.SetActive(true);
        this.gameObject.SetActive(false);

>>>>>>> Stashed changes
        stageMenu.SettingSong();


<<<<<<< Updated upstream

    }

=======
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


>>>>>>> Stashed changes
}
