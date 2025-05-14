using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComboManager : MonoBehaviour
{
    [SerializeField] GameObject goComboImage = null;
    [SerializeField] TMP_Text txtCombo = null;


    int currentCombo = 0;
    int maxCombo = 0;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }



    void Start()
    {
        //���۽� �޺� ��Ȱ��ȭ�ص�
        txtCombo.gameObject.SetActive(false);
        goComboImage.SetActive(false);
                
    }

    
    //�޺� �����ϴ� �Լ�
    public void IncreaseCombo(int p_num =1)
    {
        //�޺� ����
        currentCombo += p_num;
        if(txtCombo!=null)
        {
        txtCombo.text = $"{currentCombo}";
        }
        

        //���� �޺��� �ִ��޺��� ������
        if (maxCombo < currentCombo)
        {
            //���� �޺��� �ִ��޺��� �ȴ�
            maxCombo = currentCombo;
        }


        if(currentCombo >2)
        {
            //3�޺��� �̹��� Ȱ��ȭ
            txtCombo.gameObject.SetActive(true);
            goComboImage.SetActive(true);

            //�޺��̹��� �ִϸ��̼�
            animator.SetTrigger("ComboUp");
        }



    }

    //�ִ��޺��� ������ ��ȯ�ϴ� �Լ�
    public int GetCurrentCombo()
    {
        return currentCombo;
    }



    //�޺��� �����ϴ� �Լ�
    public void Resetcombo()
    {
        currentCombo = 0;
        txtCombo.text = "0";
        //�޺��̹���,�ؽ�Ʈ ��Ȱ��ȭ
        txtCombo.gameObject.SetActive(false);
        goComboImage.SetActive(false);
    }



    //�ִ��޺��� �������� �Լ�
    public int GetMaxCombo()
    {
        return maxCombo;
    }





}
