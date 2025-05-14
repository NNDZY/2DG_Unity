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
        //시작시 콤보 비활성화해둠
        txtCombo.gameObject.SetActive(false);
        goComboImage.SetActive(false);
                
    }

    
    //콤보 증가하는 함수
    public void IncreaseCombo(int p_num =1)
    {
        //콤보 변수
        currentCombo += p_num;
        if(txtCombo!=null)
        {
        txtCombo.text = $"{currentCombo}";
        }
        

        //현재 콤보가 최대콤보를 넘으면
        if (maxCombo < currentCombo)
        {
            //현재 콤보가 최대콤보가 된다
            maxCombo = currentCombo;
        }


        if(currentCombo >2)
        {
            //3콤부터 이미지 활성화
            txtCombo.gameObject.SetActive(true);
            goComboImage.SetActive(true);

            //콤보이미지 애니메이션
            animator.SetTrigger("ComboUp");
        }



    }

    //최대콤보가 몇인지 반환하는 함수
    public int GetCurrentCombo()
    {
        return currentCombo;
    }



    //콤보를 리셋하는 함수
    public void Resetcombo()
    {
        currentCombo = 0;
        txtCombo.text = "0";
        //콤보이미지,텍스트 비활성화
        txtCombo.gameObject.SetActive(false);
        goComboImage.SetActive(false);
    }



    //최대콤보를 가져오는 함수
    public int GetMaxCombo()
    {
        return maxCombo;
    }





}
