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


    // �� ��Ʈ�� ��� ����(AA, BB, CC)�� ���ϴ����� ���� ����
    public int lane;

    //1���� ȣ��
    private void OnEnable()
    {
        //��Ʈ�̹����� ��Ȱ��ȭ�϶��� ������Ʈ�� �����ͼ� Ȱ��ȭ�Ѵ�
        if(noteImage==null)
        {
        noteImage = GetComponent<Image>();
        }
        noteImage.enabled = true;
    }
    void Update()
    {
        //localposition�� ���� : �׳� position�̸� ĵ���� �� ��ǥ�� �ƴ϶� ������ǥ�� �����δ�
        transform.localPosition += Vector3.left * noteSpeed * Time.deltaTime;

    }

    //��Ʈ�� ����
    public void HideNote()
    {
        noteImage.enabled = false;
    }

    //��Ʈ�̹����� ��Ȱ��ȭ
    public bool GetNoteFlag()
    {
        return noteImage.enabled;
    }


}
