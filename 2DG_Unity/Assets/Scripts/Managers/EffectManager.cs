using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//빈오브젝트(이펙트) 생성후 넣어줌
public class EffectManager : MonoBehaviour
{
    //키 입력시 애니메이션
    [SerializeField] Animator noteHitAnimator = null;
    
    //키 입력시 판정 애니메이션
    [SerializeField] Animator judgementAnimator = null;
    
    //판정 이미지 출력
    [SerializeField] Image judgementImage = null;
    
    //판정이미지 배열
    [SerializeField] Sprite[] judgementSprites = null;


    //타격 애니메이션을 재생하는 코드/파라미터값에 맞는 이미지 스프라이트를 사용
    public void NoteHitEffect()
    {

        noteHitAnimator.SetTrigger("Hit");
    }
    //판정애니메이션을 재생하는 코드
    public void JudgementEffect(int p_num)
    {
        judgementImage.sprite = judgementSprites[p_num];
        judgementAnimator.SetTrigger("Hit");
    }
}
