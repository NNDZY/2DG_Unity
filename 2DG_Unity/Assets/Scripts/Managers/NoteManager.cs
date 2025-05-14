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
    //bpm���������
    public int bpm;

    //��Ʈ ������ ���� �ð� üũ�� ����. ��Ȯ�� ��ġ�� ���� double ���
    double currentTime = 0d;

    //��Ʈ�� ������ ��ġ ����
    [SerializeField] Transform appearNote = null;

    //��Ʈ�������� ���� ��(����)
    //[SerializeField] GameObject notePrefab = null;


    //��Ʈ ���� ����
    //(����)bool noteActive = true;


    TimingManager timingManager;
    EffectManager effectManager;
    ComboManager comboManager;
    StatusManager statusManager;

    GameManager gameManager;


    private void Awake()
    {
        timingManager = GetComponent<TimingManager>();
    }

    private void Start()
    {
        gameManager = GameManager.instance;
        effectManager = FindObjectOfType<EffectManager>();
        comboManager = FindObjectOfType<ComboManager>();
        statusManager = FindObjectOfType<StatusManager>();

    }




    void Update()
    {
        if(gameManager.isStartGame)
        { 
            CreateNotePrefab();
        }


    }


    private void CreateNotePrefab()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= 60d/bpm)
        {
            //������ƮǮ�� ��� : Dequeue�� noteQueue�� �����Ͽ� Queue�� �ִ� ��ü�� �����´�
            GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();

            //��Ʈ ��ü�� ��ġ���� �����ϰ� Ȱ��ȭ�Ѵ�
            t_note.transform.position = appearNote.position;
            t_note.SetActive(true);

            //��Ʈ�������� �����Ǹ� ����Ʈ�� ��´�
            timingManager.createdNoteList.Add(t_note);

            //ct�� ��ŸŸ���� �����ָ鼭 ���� �ణ�� ������ ����->�����Ǹ鼭 ��Ʈ�����ð��� ���̰� ����. ���� ��Ʈ�� ������ŭ �� ���� ������ ������ �����ϴ� ��
            currentTime -= 60d / bpm;
        }



    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        //��Ʈ�� �� �������� ��Ʈ�� �ı��ض�
        if(collision.CompareTag("Note"))
        {
            //��Ʈ�� Ȱ��ȭ�Ǿ� �������� miss�� ���
            if(collision.GetComponent<Note>().GetNoteFlag())
            {
                timingManager.MissRecord();
                //��Ʈ�� ������ ���������� 4(miss)���
                effectManager.JudgementEffect(4);
                //�޺� ����
                comboManager.Resetcombo();
                //�̽��ϰ�� ü�� ����
                statusManager.DecreaseHP(1);
              


            }
            //�ı��ϱ��� ����Ʈ���� ����
            timingManager.createdNoteList.Remove(collision.gameObject);

            //�浹�� ��ü�� Enqueue�� �̿��� �ݳ��ϰ� ��Ȱ��ȭ��
            ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);

            //(����)Destroy(collision.gameObject);
        }



    }



    //�����ִ� ��� ��Ʈ�� ���� ��
    public void RemoveNote()
    {
        gameManager.isStartGame = false;

        for(int i = 0; i<timingManager.createdNoteList.Count; i++)
        {
            //����Ʈ�� �����ξ��� ��Ʈ�� ��� ��Ȱ��ȭ
            timingManager.createdNoteList[i].SetActive(false);
            //������ƮǮ�� �ݳ����ش�
            ObjectPool.instance.noteQueue.Enqueue(timingManager.createdNoteList[i]);
        }

    }





}
