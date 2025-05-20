using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//�������Ʈ(����Ʈ) ������ �־���
public class EffectManager : MonoBehaviour
{
    //Ű �Է½� �ִϸ��̼�
    [SerializeField] Animator noteHitAnimator = null;
    
    //Ű �Է½� ���� �ִϸ��̼�
    [SerializeField] Animator judgementAnimator = null;
    
    //���� �̹��� ���
    [SerializeField] Image judgementImage = null;
    
    //�����̹��� �迭
    [SerializeField] Sprite[] judgementSprites = null;


    //Ÿ�� �ִϸ��̼��� ����ϴ� �ڵ�/�Ķ���Ͱ��� �´� �̹��� ��������Ʈ�� ���
    public void NoteHitEffect()
    {

        noteHitAnimator.SetTrigger("Hit");
    }
    //�����ִϸ��̼��� ����ϴ� �ڵ�
    public void JudgementEffect(int p_num)
    {
        judgementImage.sprite = judgementSprites[p_num];
        judgementAnimator.SetTrigger("Hit");
    }
}
