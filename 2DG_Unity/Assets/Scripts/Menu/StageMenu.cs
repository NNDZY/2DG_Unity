using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�� ������Ʈ(�޴�-���������޴�)�� ��ũ��Ʈ �־���
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
        //�÷��̹�ư�� ������ ������ ���۵ǰ�, ���������޴��� ��Ȱ��ȭ��
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
