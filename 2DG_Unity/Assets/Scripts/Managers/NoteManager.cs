//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


///*
// bpm변수만들기
//노트 프리팹을 담고 생성
//노트 태그와 닿았을때 노트를 삭제시킨다
//ui-노트에 스크립트 삽입

// */


//public class NoteManager : MonoBehaviour
//{
//    //bpm변수만들기
//    public int bpm =0;

//    //노트 생성을 위한 시간 체크용 변수. 정확한 수치를 위해 double 사용
//    double currentTime = 0d;

//    //노트가 생성될 위치 변수
//    [SerializeField] Transform appearNote = null;
//    //[SerializeField] Transform appearNoteR = null;
//    //[SerializeField] Transform appearNoteB = null;
//    //[SerializeField] Transform appearNoteY = null;



//    //노트 생성 상태
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

//    //노트프리팹 베이스
//    //private void CreateNotePrefab()
//    //{
//    //    currentTime += Time.deltaTime;

//    //    if(currentTime >= 60d/bpm)
//    //    {
//    //        //오브젝트풀링 사용 : Dequeue로 noteQueue에 접근하여 Queue에 있는 객체를 꺼내온다
//    //        GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();

//    //        //노트 객체의 위치값을 설정하고 활성화한다
//    //        t_note.transform.position = appearNote.position;
//    //        t_note.SetActive(true);

//    //        //노트프리팹이 생성되면 리스트에 담는다
//    //        timingManager.createdNoteList.Add(t_note);

//    //        //ct에 델타타임을 더해주면서 조금 약간의 오차가 생김->누적되면서 노트생성시간에 차이가 생김. 다음 노트는 오차만큼 더 빨리 나오는 식으로 조정하는 것
//    //        currentTime -= 60d / bpm;
//    //    }



//    //}

//    private void CreateNotePrefabR()
//    {


//        currentTime += Time.deltaTime;

//        if(currentTime >= 60d/bpm)
//        {
//            //오브젝트풀링 사용 : Dequeue로 noteQueue에 접근하여 Queue에 있는 객체를 꺼내온다
//            GameObject t_note = ObjectPool.instance.noteQueueR.Dequeue();

//            //노트 객체의 위치값을 설정하고 활성화한다
//            t_note.transform.position = appearNote.position;
//            t_note.SetActive(true);

//            //노트프리팹이 생성되면 리스트에 담는다
//            timingManager.createdNoteList.Add(t_note);

//            //ct에 델타타임을 더해주면서 조금 약간의 오차가 생김->누적되면서 노트생성시간에 차이가 생김. 다음 노트는 오차만큼 더 빨리 나오는 식으로 조정하는 것
//            currentTime -= 60d / bpm;
//        }



//    }

//    private void CreateNotePrefabB()
//    {
//        currentTime += Time.deltaTime;

//        if(currentTime >= 60d/bpm)
//        {
//            //오브젝트풀링 사용 : Dequeue로 noteQueue에 접근하여 Queue에 있는 객체를 꺼내온다
//            GameObject t_note = ObjectPool.instance.noteQueueB.Dequeue();

//            //노트 객체의 위치값을 설정하고 활성화한다
//            t_note.transform.position = appearNote.position;
//            t_note.SetActive(true);

//            //노트프리팹이 생성되면 리스트에 담는다
//            timingManager.createdNoteList.Add(t_note);

//            //ct에 델타타임을 더해주면서 조금 약간의 오차가 생김->누적되면서 노트생성시간에 차이가 생김. 다음 노트는 오차만큼 더 빨리 나오는 식으로 조정하는 것
//            currentTime -= 60d / bpm;
//        }



//    }

//    private void CreateNotePrefabY()
//    {
//        currentTime += Time.deltaTime;

//        if(currentTime >= 60d/bpm)
//        {
//            //오브젝트풀링 사용 : Dequeue로 noteQueue에 접근하여 Queue에 있는 객체를 꺼내온다
//            GameObject t_note = ObjectPool.instance.noteQueueY.Dequeue();

//            //노트 객체의 위치값을 설정하고 활성화한다
//            t_note.transform.position = appearNote.position;
//            t_note.SetActive(true);

//            //노트프리팹이 생성되면 리스트에 담는다
//            timingManager.createdNoteList.Add(t_note);

//            //ct에 델타타임을 더해주면서 조금 약간의 오차가 생김->누적되면서 노트생성시간에 차이가 생김. 다음 노트는 오차만큼 더 빨리 나오는 식으로 조정하는 것
//            currentTime -= 60d / bpm;
//        }



//    }


//    //노트의 컬라이더구간을 벗어나면 미스가 나게함
//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        //노트가 활성화되지않았다면 무시
//        if (!noteActive) return;

//        //노트가 다 지나가면 노트를 없애야함
//        if (collision.CompareTag("Note"))
//        {
//            //노트가 활성화되어 있을때만 miss를 출력
//            if(collision.GetComponent<Note>().GetNoteFlag())
//            {
//                timingManager.MissRecord();                

//            }
//            //노트가 리스트에 존재하고 있다면
//            if(timingManager.createdNoteList.Contains(collision.gameObject))
//            {
//            //파괴하기전 리스트에서 삭제
//            timingManager.createdNoteList.Remove(collision.gameObject);
//            }


//            //충돌한 객체를 Enqueue를 이용해 반납하고 비활성화함
//            ObjectPool.instance.noteQueueR.Enqueue(collision.gameObject);
//            ObjectPool.instance.noteQueueB.Enqueue(collision.gameObject);
//            ObjectPool.instance.noteQueueY.Enqueue(collision.gameObject);
//            collision.gameObject.SetActive(false);

//        }



//    }



//    //나와있는 모든 노트를 없앨 것
//    public void RemoveNote()
//    {

//        GameManager.instance.isStartGame = false;

//        for(int i = 0; i<timingManager.createdNoteList.Count; i++)
//        {

//            //리스트로 만들어두었던 노트를 모두 비활성화
//            timingManager.createdNoteList[i].SetActive(false);
//            //오브젝트풀을 반납해준다
//            ObjectPool.instance.noteQueueR.Enqueue(timingManager.createdNoteList[i]);
//            ObjectPool.instance.noteQueueB.Enqueue(timingManager.createdNoteList[i]);
//            ObjectPool.instance.noteQueueY.Enqueue(timingManager.createdNoteList[i]);

//        }

//        //게임이 끝나면 리스트를 초기화해야함
//        timingManager.createdNoteList.Clear();


//    }

//}


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

    //노트 생성상태
    bool noteActive = true;


    void Start()
    {






        timingManager = FindObjectOfType<TimingManager>();
        notes = parser.Parse();  // BMS 노트 데이터 파싱
        audioSource.Play();
    }

    void Update()
    {
        if (!GameManager.instance.isStartGame) return;
        if (nextIndex >= notes.Count) return;

        float songTime = audioSource.time;

        // 미리보기 시간 1.5초
        while (nextIndex < notes.Count && notes[nextIndex].time <= songTime + 1.5f)
        {
            SpawnNote(notes[nextIndex]);
            nextIndex++;
        }
    }

    void SpawnNote(NoteData2 noteData)
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
            Debug.LogWarning("풀에 노트가 없습니다!");
        }
    }


    //노트의 컬라이더구간을 벗어나면 미스가 나게함
    private void OnTriggerExit2D(Collider2D collision)
    {
        //노트가 활성화되지않았다면 무시
        if (!noteActive) return;

        //노트가 다 지나가면 노트를 없애야함
        if (collision.CompareTag("NoteR")|| collision.CompareTag("NoteB")|| collision.CompareTag("NoteY"))
        {
            //노트가 활성화되어 있을때만 miss를 출력
            if (collision.GetComponent<Note>().GetNoteFlag())
            {
                timingManager.MissRecord();

            }
            //노트가 리스트에 존재하고 있다면
            if (timingManager.createdNoteList.Contains(collision.gameObject))
            {
                //파괴하기전 리스트에서 삭제
                timingManager.createdNoteList.Remove(collision.gameObject);
            }


            // 태그에 따라 맞는 큐에만 반납
            if (collision.CompareTag("NoteR"))
            {
                Debug.Log("NoteR 반납됨");
                ObjectPool.instance.noteQueueR.Enqueue(collision.gameObject);
            }
            else if (collision.CompareTag("NoteB"))
            {
                Debug.Log("NoteB 반납됨");
                ObjectPool.instance.noteQueueB.Enqueue(collision.gameObject);
            }
            else if (collision.CompareTag("NoteY"))
            {
                Debug.Log("NoteY 반납됨");
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

            // 각각의 큐로 반환
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


