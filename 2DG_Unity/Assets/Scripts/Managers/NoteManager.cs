//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


///*
// bpm���������
//��Ʈ �������� ��� ����
//��Ʈ �±׿� ������� ��Ʈ�� ������Ų��
//ui-��Ʈ�� ��ũ��Ʈ ����

// */


//public class NoteManager : MonoBehaviour
//{
//    //bpm���������
//    public int bpm =0;

//    //��Ʈ ������ ���� �ð� üũ�� ����. ��Ȯ�� ��ġ�� ���� double ���
//    double currentTime = 0d;

//    //��Ʈ�� ������ ��ġ ����
//    [SerializeField] Transform appearNote = null;
//    //[SerializeField] Transform appearNoteR = null;
//    //[SerializeField] Transform appearNoteB = null;
//    //[SerializeField] Transform appearNoteY = null;



//    //��Ʈ ���� ����
//    bool noteActive = true;


//    TimingManager timingManager;



//    private void Awake()
//    {
//        timingManager = GetComponent<TimingManager>();
//    }

//    private void Start()
//    {

//    }




//    void Update()
//    {
//        if(GameManager.instance.isStartGame)
//        {


//                CreateNotePrefabR();
//                CreateNotePrefabB();
//                CreateNotePrefabY();


//        }


//    }

//    //��Ʈ������ ���̽�
//    //private void CreateNotePrefab()
//    //{
//    //    currentTime += Time.deltaTime;

//    //    if(currentTime >= 60d/bpm)
//    //    {
//    //        //������ƮǮ�� ��� : Dequeue�� noteQueue�� �����Ͽ� Queue�� �ִ� ��ü�� �����´�
//    //        GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();

//    //        //��Ʈ ��ü�� ��ġ���� �����ϰ� Ȱ��ȭ�Ѵ�
//    //        t_note.transform.position = appearNote.position;
//    //        t_note.SetActive(true);

//    //        //��Ʈ�������� �����Ǹ� ����Ʈ�� ��´�
//    //        timingManager.createdNoteList.Add(t_note);

//    //        //ct�� ��ŸŸ���� �����ָ鼭 ���� �ణ�� ������ ����->�����Ǹ鼭 ��Ʈ�����ð��� ���̰� ����. ���� ��Ʈ�� ������ŭ �� ���� ������ ������ �����ϴ� ��
//    //        currentTime -= 60d / bpm;
//    //    }



//    //}

//    private void CreateNotePrefabR()
//    {


//        currentTime += Time.deltaTime;

//        if(currentTime >= 60d/bpm)
//        {
//            //������ƮǮ�� ��� : Dequeue�� noteQueue�� �����Ͽ� Queue�� �ִ� ��ü�� �����´�
//            GameObject t_note = ObjectPool.instance.noteQueueR.Dequeue();

//            //��Ʈ ��ü�� ��ġ���� �����ϰ� Ȱ��ȭ�Ѵ�
//            t_note.transform.position = appearNote.position;
//            t_note.SetActive(true);

//            //��Ʈ�������� �����Ǹ� ����Ʈ�� ��´�
//            timingManager.createdNoteList.Add(t_note);

//            //ct�� ��ŸŸ���� �����ָ鼭 ���� �ణ�� ������ ����->�����Ǹ鼭 ��Ʈ�����ð��� ���̰� ����. ���� ��Ʈ�� ������ŭ �� ���� ������ ������ �����ϴ� ��
//            currentTime -= 60d / bpm;
//        }



//    }

//    private void CreateNotePrefabB()
//    {
//        currentTime += Time.deltaTime;

//        if(currentTime >= 60d/bpm)
//        {
//            //������ƮǮ�� ��� : Dequeue�� noteQueue�� �����Ͽ� Queue�� �ִ� ��ü�� �����´�
//            GameObject t_note = ObjectPool.instance.noteQueueB.Dequeue();

//            //��Ʈ ��ü�� ��ġ���� �����ϰ� Ȱ��ȭ�Ѵ�
//            t_note.transform.position = appearNote.position;
//            t_note.SetActive(true);

//            //��Ʈ�������� �����Ǹ� ����Ʈ�� ��´�
//            timingManager.createdNoteList.Add(t_note);

//            //ct�� ��ŸŸ���� �����ָ鼭 ���� �ణ�� ������ ����->�����Ǹ鼭 ��Ʈ�����ð��� ���̰� ����. ���� ��Ʈ�� ������ŭ �� ���� ������ ������ �����ϴ� ��
//            currentTime -= 60d / bpm;
//        }



//    }

//    private void CreateNotePrefabY()
//    {
//        currentTime += Time.deltaTime;

//        if(currentTime >= 60d/bpm)
//        {
//            //������ƮǮ�� ��� : Dequeue�� noteQueue�� �����Ͽ� Queue�� �ִ� ��ü�� �����´�
//            GameObject t_note = ObjectPool.instance.noteQueueY.Dequeue();

//            //��Ʈ ��ü�� ��ġ���� �����ϰ� Ȱ��ȭ�Ѵ�
//            t_note.transform.position = appearNote.position;
//            t_note.SetActive(true);

//            //��Ʈ�������� �����Ǹ� ����Ʈ�� ��´�
//            timingManager.createdNoteList.Add(t_note);

//            //ct�� ��ŸŸ���� �����ָ鼭 ���� �ణ�� ������ ����->�����Ǹ鼭 ��Ʈ�����ð��� ���̰� ����. ���� ��Ʈ�� ������ŭ �� ���� ������ ������ �����ϴ� ��
//            currentTime -= 60d / bpm;
//        }



//    }


//    //��Ʈ�� �ö��̴������� ����� �̽��� ������
//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        //��Ʈ�� Ȱ��ȭ�����ʾҴٸ� ����
//        if (!noteActive) return;

//        //��Ʈ�� �� �������� ��Ʈ�� ���־���
//        if (collision.CompareTag("Note"))
//        {
//            //��Ʈ�� Ȱ��ȭ�Ǿ� �������� miss�� ���
//            if(collision.GetComponent<Note>().GetNoteFlag())
//            {
//                timingManager.MissRecord();                

//            }
//            //��Ʈ�� ����Ʈ�� �����ϰ� �ִٸ�
//            if(timingManager.createdNoteList.Contains(collision.gameObject))
//            {
//            //�ı��ϱ��� ����Ʈ���� ����
//            timingManager.createdNoteList.Remove(collision.gameObject);
//            }


//            //�浹�� ��ü�� Enqueue�� �̿��� �ݳ��ϰ� ��Ȱ��ȭ��
//            ObjectPool.instance.noteQueueR.Enqueue(collision.gameObject);
//            ObjectPool.instance.noteQueueB.Enqueue(collision.gameObject);
//            ObjectPool.instance.noteQueueY.Enqueue(collision.gameObject);
//            collision.gameObject.SetActive(false);

//        }



//    }



//    //�����ִ� ��� ��Ʈ�� ���� ��
//    public void RemoveNote()
//    {

//        GameManager.instance.isStartGame = false;

//        for(int i = 0; i<timingManager.createdNoteList.Count; i++)
//        {

//            //����Ʈ�� �����ξ��� ��Ʈ�� ��� ��Ȱ��ȭ
//            timingManager.createdNoteList[i].SetActive(false);
//            //������ƮǮ�� �ݳ����ش�
//            ObjectPool.instance.noteQueueR.Enqueue(timingManager.createdNoteList[i]);
//            ObjectPool.instance.noteQueueB.Enqueue(timingManager.createdNoteList[i]);
//            ObjectPool.instance.noteQueueY.Enqueue(timingManager.createdNoteList[i]);

//        }

//        //������ ������ ����Ʈ�� �ʱ�ȭ�ؾ���
//        timingManager.createdNoteList.Clear();


//    }

//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager instance;


    public AudioSource audioSource;
    public BMSParser parser;

    public Transform[] spawnPoints; // 0: AA, 1: BB, 2: CC

    public int bpm = 155;

    private List<NoteData> notes;
    private int nextIndex = 0;

    TimingManager timingManager;
    Result result;


    //��Ʈ ��������
    bool noteActive = true;


    void Start()
    {
        instance = this;


        result = FindObjectOfType<Result>();


        parser = FindObjectOfType<BMSParser>();
        timingManager = FindObjectOfType<TimingManager>();
        notes = parser.Parse();  // BMS ��Ʈ ������ �Ľ�
        audioSource.Play();
    }

    void Update()
    {
        MoveNote();
    }


    public void MoveNote()
    {
        if (!GameManager.instance.isStartGame) return;

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
            result.isResultShown = true;
            result.ShowResult();
            RemoveNote();
            nextIndex = 0;
        }

    }

    public void ResetNote()
    {
        //�ε����� ó������ �ǵ���..?
        SpawnNote(notes[0]);
        
    }


    void SpawnNote(NoteData noteData)
    {
        GameObject note = null;

        Debug.Log($"Spawn Note - Lane: {noteData.lane}, Time: {noteData.time}, SongTime: {audioSource.time}");

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
            //if (timingManager.createdNoteList.Contains(collision.gameObject))
            //{
            //    //�ı��ϱ��� ����Ʈ���� ����
            //    timingManager.createdNoteList.Remove(collision.gameObject);
            //}


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


