
///*
// bpm변수만들기
//노트 프리팹을 담고 생성
//노트 태그와 닿았을때 노트를 삭제시킨다
//ui-노트에 스크립트 삽입

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
<<<<<<< Updated upstream
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
=======
        MoveNote();
    }


    public void MoveNote()
    {
        if (GameManager.instance.isStartGame)
        {
            float songTime = audioSource.time;

            //노트를 발생시킨다
            // songTime + n초로 노트가 나타나는 타이밍 조절
            while (nextIndex < notes.Count && notes[nextIndex].time <= songTime + 3.8f)
            {
                SpawnNote(notes[nextIndex]);
                nextIndex++;
            }
            //노래가 끝나면 결과창 호출
            if (!audioSource.isPlaying && !result.isResultShown)
            {
                Debug.Log("노래 종료");
                GameManager.instance.GameOver();
            }

        }


    }

    public void ResetNote()
    {
        //인덱스를 처음으로 되돌림
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


