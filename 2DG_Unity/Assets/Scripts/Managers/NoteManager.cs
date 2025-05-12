using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 bpm변수만들기
노트 프리팹을 담고 생성
노트 태그와 닿았을때 노트를 삭제시킨다
 
 */


public class NoteManager : MonoBehaviour
{
    public int bpm;

    //노트 생성을 위한 시간 체크용 변수. 정확한 수치를 위해 double 사용
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
            //노트프리팹 출현
            GameObject note = Instantiate(notePrefab, appearNote.position, Quaternion.identity);

            //노트프리팹의 부모를 플레이존으로 설정
            note.transform.SetParent(this.transform);

            //노트프리팹이 생성되면 리스트에 담는다
            timingManager.createdNoteList.Add(note);

            //ct에 델타타임을 더해주면서 조금 약간의 오차가 생김->누적되면서 노트생성시간에 차이가 생김. 다음 노트는 오차만큼 더 빨리 나오는 식으로 조정하는 것
            currentTime -= 60d / bpm;
        }



    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        //노트가 다 지나가면 노트를 파괴해라
        if(collision.CompareTag("Note"))
        {
            //파괴하기전 리스트에서 삭제
            timingManager.createdNoteList.Remove(collision.gameObject);

            Destroy(collision.gameObject);
        }



    }





}
