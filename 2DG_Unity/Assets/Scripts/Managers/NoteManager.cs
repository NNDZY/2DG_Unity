using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 bpm���������
��Ʈ �������� ��� ����
��Ʈ �±׿� ������� ��Ʈ�� ������Ų��
 
 */


public class NoteManager : MonoBehaviour
{
    public int bpm;

    //��Ʈ ������ ���� �ð� üũ�� ����. ��Ȯ�� ��ġ�� ���� double ���
    double currentTime = 0d;

    [SerializeField] Transform appearNote = null;
    [SerializeField] GameObject notePrefab = null;



    TimingManager timingManager;

    private void Awake()
    {
        timingManager = GetComponent<TimingManager>();
    }




    void Update()
    {
        CreateNotePrefab();


    }


    private void CreateNotePrefab()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= 60d/bpm)
        {
            //��Ʈ������ ����
            GameObject note = Instantiate(notePrefab, appearNote.position, Quaternion.identity);

            //��Ʈ�������� �θ� �÷��������� ����
            note.transform.SetParent(this.transform);

            //��Ʈ�������� �����Ǹ� ����Ʈ�� ��´�
            timingManager.createdNoteList.Add(note);

            //ct�� ��ŸŸ���� �����ָ鼭 ���� �ణ�� ������ ����->�����Ǹ鼭 ��Ʈ�����ð��� ���̰� ����. ���� ��Ʈ�� ������ŭ �� ���� ������ ������ �����ϴ� ��
            currentTime -= 60d / bpm;
        }



    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        //��Ʈ�� �� �������� ��Ʈ�� �ı��ض�
        if(collision.CompareTag("Note"))
        {
            //�ı��ϱ��� ����Ʈ���� ����
            timingManager.createdNoteList.Remove(collision.gameObject);

            Destroy(collision.gameObject);
        }



    }





}
