using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//��Ʈ�� ����
//�������� �����̸鼭 ���ڿ� �°�? ����������
public class Note : MonoBehaviour
{
    private float noteSpeed = 400.0f;

    Image noteImage;



    private void Awake()
    {
        noteImage = GetComponent<Image>();
    }




    void Update()
    {
        //localposition�� ���� : �׳� position�̸� ĵ���� �� ��ǥ�� �ƴ϶� ������ǥ�� �����δ�
        transform.localPosition += Vector3.left * noteSpeed * Time.deltaTime;

    }

    //��Ʈ�� ����
    private void HideNote()
    {
        noteImage.enabled = false;
    }


}
