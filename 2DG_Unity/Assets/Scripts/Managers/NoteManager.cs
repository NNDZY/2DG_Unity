using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 bpm���������
��Ʈ �������� ��� ����
��Ʈ �±׿� ������� ��Ʈ�� ������Ų��
�÷������� ��ũ��Ʈ ����
 
 */


public class NoteManager : MonoBehaviour
{
    //bpm���������
    public int bpm =0;

    //��Ʈ ������ ���� �ð� üũ�� ����. ��Ȯ�� ��ġ�� ���� double ���
    double currentTime = 0d;

    //��Ʈ�� ������ ��ġ ����
    [SerializeField] Transform appearNoteR = null;
    [SerializeField] Transform appearNoteB = null;
    [SerializeField] Transform appearNoteY = null;



    //��Ʈ ���� ����
    bool noteActive = true;


    TimingManager timingManager;
    EffectManager effectManager;
    ComboManager comboManager;
    StatusManager statusManager;



    private void Awake()
    {
        timingManager = GetComponent<TimingManager>();
    }

    private void Start()
    {
        effectManager = FindObjectOfType<EffectManager>();
        comboManager = FindObjectOfType<ComboManager>();
        statusManager = FindObjectOfType<StatusManager>();

    }




    void Update()
    {
        if(GameManager.instance.isStartGame)
        { 
            CreateNotePrefabR();
            CreateNotePrefabB();
            CreateNotePrefabY();
        }


    }

    //��Ʈ������ ���̽�
    //private void CreateNotePrefab()
    //{
    //    currentTime += Time.deltaTime;

    //    if(currentTime >= 60d/bpm)
    //    {
    //        //������ƮǮ�� ��� : Dequeue�� noteQueue�� �����Ͽ� Queue�� �ִ� ��ü�� �����´�
    //        GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();

    //        //��Ʈ ��ü�� ��ġ���� �����ϰ� Ȱ��ȭ�Ѵ�
    //        t_note.transform.position = appearNote.position;
    //        t_note.SetActive(true);

    //        //��Ʈ�������� �����Ǹ� ����Ʈ�� ��´�
    //        timingManager.createdNoteList.Add(t_note);

    //        //ct�� ��ŸŸ���� �����ָ鼭 ���� �ణ�� ������ ����->�����Ǹ鼭 ��Ʈ�����ð��� ���̰� ����. ���� ��Ʈ�� ������ŭ �� ���� ������ ������ �����ϴ� ��
    //        currentTime -= 60d / bpm;
    //    }



    //}

    private void CreateNotePrefabR()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= 60d/bpm)
        {
            //������ƮǮ�� ��� : Dequeue�� noteQueue�� �����Ͽ� Queue�� �ִ� ��ü�� �����´�
            GameObject t_note = ObjectPool.instance.noteQueueR.Dequeue();

            //��Ʈ ��ü�� ��ġ���� �����ϰ� Ȱ��ȭ�Ѵ�
            t_note.transform.position = appearNoteR.position;
            t_note.SetActive(true);

            //��Ʈ�������� �����Ǹ� ����Ʈ�� ��´�
            timingManager.createdNoteList.Add(t_note);

            //ct�� ��ŸŸ���� �����ָ鼭 ���� �ణ�� ������ ����->�����Ǹ鼭 ��Ʈ�����ð��� ���̰� ����. ���� ��Ʈ�� ������ŭ �� ���� ������ ������ �����ϴ� ��
            currentTime -= 60d / bpm;
        }



    }

    private void CreateNotePrefabB()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= 60d/bpm)
        {
            //������ƮǮ�� ��� : Dequeue�� noteQueue�� �����Ͽ� Queue�� �ִ� ��ü�� �����´�
            GameObject t_note = ObjectPool.instance.noteQueueB.Dequeue();

            //��Ʈ ��ü�� ��ġ���� �����ϰ� Ȱ��ȭ�Ѵ�
            t_note.transform.position = appearNoteB.position;
            t_note.SetActive(true);

            //��Ʈ�������� �����Ǹ� ����Ʈ�� ��´�
            timingManager.createdNoteList.Add(t_note);

            //ct�� ��ŸŸ���� �����ָ鼭 ���� �ణ�� ������ ����->�����Ǹ鼭 ��Ʈ�����ð��� ���̰� ����. ���� ��Ʈ�� ������ŭ �� ���� ������ ������ �����ϴ� ��
            currentTime -= 60d / bpm;
        }



    }

    private void CreateNotePrefabY()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= 60d/bpm)
        {
            //������ƮǮ�� ��� : Dequeue�� noteQueue�� �����Ͽ� Queue�� �ִ� ��ü�� �����´�
            GameObject t_note = ObjectPool.instance.noteQueueY.Dequeue();

            //��Ʈ ��ü�� ��ġ���� �����ϰ� Ȱ��ȭ�Ѵ�
            t_note.transform.position = appearNoteY.position;
            t_note.SetActive(true);

            //��Ʈ�������� �����Ǹ� ����Ʈ�� ��´�
            timingManager.createdNoteList.Add(t_note);

            //ct�� ��ŸŸ���� �����ָ鼭 ���� �ణ�� ������ ����->�����Ǹ鼭 ��Ʈ�����ð��� ���̰� ����. ���� ��Ʈ�� ������ŭ �� ���� ������ ������ �����ϴ� ��
            currentTime -= 60d / bpm;
        }



    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        //��Ʈ�� Ȱ��ȭ�����ʾҴٸ� ����
        if (!noteActive) return;

        //��Ʈ�� �� �������� ��Ʈ�� �ı��ض�
        if (collision.CompareTag("Note"))
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
            //��Ʈ�� ����Ʈ�� �����ϰ� �ִٸ�
            if(timingManager.createdNoteList.Contains(collision.gameObject))
            {
            //�ı��ϱ��� ����Ʈ���� ����
            timingManager.createdNoteList.Remove(collision.gameObject);
            }


            //�浹�� ��ü�� Enqueue�� �̿��� �ݳ��ϰ� ��Ȱ��ȭ��
            ObjectPool.instance.noteQueueR.Enqueue(collision.gameObject);
            ObjectPool.instance.noteQueueB.Enqueue(collision.gameObject);
            ObjectPool.instance.noteQueueY.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);

        }



    }



    //�����ִ� ��� ��Ʈ�� ���� ��
    public void RemoveNote()
    {
        noteActive = false;

        GameManager.instance.isStartGame = false;

        for(int i = 0; i<timingManager.createdNoteList.Count; i++)
        {
            
            //����Ʈ�� �����ξ��� ��Ʈ�� ��� ��Ȱ��ȭ
            timingManager.createdNoteList[i].SetActive(false);
            //������ƮǮ�� �ݳ����ش�
            ObjectPool.instance.noteQueueR.Enqueue(timingManager.createdNoteList[i]);
            ObjectPool.instance.noteQueueB.Enqueue(timingManager.createdNoteList[i]);
            ObjectPool.instance.noteQueueY.Enqueue(timingManager.createdNoteList[i]);

        }

        //������ ������ �ڽ�����Ʈ�� �ʱ�ȭ�ؾ���
        timingManager.createdNoteList.Clear();

        noteActive = true;

    }

}
