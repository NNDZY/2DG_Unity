using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�� ������Ʈ(�޴�-Ÿ��Ʋ)�� ��ũ��Ʈ �־���
public class TitleMenu : MonoBehaviour
{


    [SerializeField] GameObject goStageUI = null;

    public void ButtonPlay()
    {
        //Ÿ��Ʋ�� �÷��̹�ư�� ������, ���������޴��� Ȱ��ȭ�ϰ� Ÿ��Ʋ�� ��Ȱ��ȭ�ȴ�
        goStageUI.SetActive(true);
        this.gameObject.SetActive(false);



    }

}
