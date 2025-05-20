
///*
// bpm���������
//��Ʈ �������� ��� ����
//��Ʈ �±׿� ������� ��Ʈ�� ������Ų��
//ui-��Ʈ�� ��ũ��Ʈ ����

// */






using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public AudioSource audioSource;
    public BMSParser parser;

    public Transform[] spawnPoints; // 0: AA, 1: BB, 2: CC

    public int bpm = 155;

    private List<NoteData2> notes;
    private int nextIndex = 0;

    TimingManager timingManager;


    //��Ʈ ��������
    bool noteActive = true;


    void Start()
    {






        timingManager = FindObjectOfType<TimingManager>();
        notes = parser.Parse();  // BMS ��Ʈ ������ �Ľ�
        audioSource.Play();
    }

    void Update()
    {
<<<<<<< Updated upstream
        if (!GameManager.instance.isStartGame) return;
        if (nextIndex >= notes.Count) return;

        float songTime = audioSource.time;

        // �̸����� �ð� 1.5��
        while (nextIndex < notes.Count && notes[nextIndex].time <= songTime + 1.5f)
        {
            SpawnNote(notes[nextIndex]);
            nextIndex++;
        }
    }

    void SpawnNote(NoteData2 noteData)
=======
        MoveNote();
    }


    public void MoveNote()
    {
        if (GameManager.instance.isStartGame)
        {
            float songTime = audioSource.time;

            //��Ʈ�� �߻���Ų��
            // songTime + n�ʷ� ��Ʈ�� ��Ÿ���� Ÿ�̹� ����
            while (nextIndex < notes.Count && notes[nextIndex].time <= songTime + 3.8f)
            {
                SpawnNote(notes[nextIndex]);
                nextIndex++;
            }
            //�뷡�� ������ ���â ȣ��
            if (!audioSource.isPlaying && !result.isResultShown)
            {
                Debug.Log("�뷡 ����");
                GameManager.instance.GameOver();
            }

        }


    }

    public void ResetNote()
    {
        //�ε����� ó������ �ǵ���
        nextIndex = 0;        
    }


    void SpawnNote(NoteData noteData)
>>>>>>> Stashed changes
    {
        GameObject note = null;

        switch (noteData.lane)
        {
            case 0:
                if (ObjectPool.instance.noteQueueR.Count > 0)
                    note = ObjectPool.instance.noteQueueR.Dequeue();
                break;
            case 1:
                if (ObjectPool.instance.noteQueueB.Count > 0)
                    note = ObjectPool.instance.noteQueueB.Dequeue();
                break;
            case 2:
                if (ObjectPool.instance.noteQueueY.Count > 0)
                    note = ObjectPool.instance.noteQueueY.Dequeue();
                break;
        }

        if (note != null)
        {
            note.transform.position = spawnPoints[noteData.lane].position;
            note.SetActive(true);
            timingManager.createdNoteList.Add(note);
        }
        else
        {
            Debug.LogWarning("Ǯ�� ��Ʈ�� �����ϴ�!");
        }
    }


    //��Ʈ�� �ö��̴������� ����� �̽��� ������
    private void OnTriggerExit2D(Collider2D collision)
    {
        //��Ʈ�� Ȱ��ȭ�����ʾҴٸ� ����
        if (!noteActive) return;

        //��Ʈ�� �� �������� ��Ʈ�� ���־���
        if (collision.CompareTag("NoteR")|| collision.CompareTag("NoteB")|| collision.CompareTag("NoteY"))
        {
            //��Ʈ�� Ȱ��ȭ�Ǿ� �������� miss�� ���
            if (collision.GetComponent<Note>().GetNoteFlag())
            {
                timingManager.MissRecord();

            }
            //��Ʈ�� ����Ʈ�� �����ϰ� �ִٸ�
            if (timingManager.createdNoteList.Contains(collision.gameObject))
            {
                //�ı��ϱ��� ����Ʈ���� ����
                timingManager.createdNoteList.Remove(collision.gameObject);
            }


            // �±׿� ���� �´� ť���� �ݳ�
            if (collision.CompareTag("NoteR"))
            {
                Debug.Log("NoteR �ݳ���");
                ObjectPool.instance.noteQueueR.Enqueue(collision.gameObject);
            }
            else if (collision.CompareTag("NoteB"))
            {
                Debug.Log("NoteB �ݳ���");
                ObjectPool.instance.noteQueueB.Enqueue(collision.gameObject);
            }
            else if (collision.CompareTag("NoteY"))
            {
                Debug.Log("NoteY �ݳ���");
                ObjectPool.instance.noteQueueY.Enqueue(collision.gameObject);
            }


            collision.gameObject.SetActive(false);

        }
    }

<<<<<<< Updated upstream





=======
>>>>>>> Stashed changes
    public void RemoveNote()
    {
        GameManager.instance.isStartGame = false;

        for (int i = 0; i < timingManager.createdNoteList.Count; i++)
        {
            GameObject note = timingManager.createdNoteList[i];
            note.SetActive(false);

            // ������ ť�� ��ȯ
            if (note.CompareTag("NoteR"))
                ObjectPool.instance.noteQueueR.Enqueue(note);
            else if (note.CompareTag("NoteB"))
                ObjectPool.instance.noteQueueB.Enqueue(note);
            else if (note.CompareTag("NoteY"))
                ObjectPool.instance.noteQueueY.Enqueue(note);
        }

        timingManager.createdNoteList.Clear();
    }
}


