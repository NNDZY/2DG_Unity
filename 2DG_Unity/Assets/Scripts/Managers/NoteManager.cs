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
    //bpm변수만들기
    public int bpm;

    //노트 생성을 위한 시간 체크용 변수. 정확한 수치를 위해 double 사용
    double currentTime = 0d;

    //노트가 생성될 위치 변수
    [SerializeField] Transform appearNote = null;

    //노트프리팹을 담을 곳(삭제)
    //[SerializeField] GameObject notePrefab = null;


    //노트 생성 상태
    //(삭제)bool noteActive = true;


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
            //오브젝트풀링 사용 : Dequeue로 noteQueue에 접근하여 Queue에 있는 객체를 꺼내온다
            GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();

            //노트 객체의 위치값을 설정하고 활성화한다
            t_note.transform.position = appearNote.position;
            t_note.SetActive(true);

            //노트프리팹이 생성되면 리스트에 담는다
            timingManager.createdNoteList.Add(t_note);

            //ct에 델타타임을 더해주면서 조금 약간의 오차가 생김->누적되면서 노트생성시간에 차이가 생김. 다음 노트는 오차만큼 더 빨리 나오는 식으로 조정하는 것
            currentTime -= 60d / bpm;
        }



    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        //노트가 다 지나가면 노트를 파괴해라
        if(collision.CompareTag("Note"))
        {
            //노트가 활성화되어 있을때만 miss를 출력
            if(collision.GetComponent<Note>().GetNoteFlag())
            {
                timingManager.MissRecord();
                //노트가 구간을 빠져나가면 4(miss)출력
                effectManager.JudgementEffect(4);
                //콤보 리셋
                comboManager.Resetcombo();
                //미스일경우 체력 감소
                statusManager.DecreaseHP(1);
              


            }
            //파괴하기전 리스트에서 삭제
            timingManager.createdNoteList.Remove(collision.gameObject);

            //충돌한 객체를 Enqueue를 이용해 반납하고 비활성화함
            ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);

            //(삭제)Destroy(collision.gameObject);
        }



    }



    //나와있는 모든 노트를 없앨 것
    public void RemoveNote()
    {
        gameManager.isStartGame = false;

        for(int i = 0; i<timingManager.createdNoteList.Count; i++)
        {
            //리스트로 만들어두었던 노트를 모두 비활성화
            timingManager.createdNoteList[i].SetActive(false);
            //오브젝트풀을 반납해준다
            ObjectPool.instance.noteQueue.Enqueue(timingManager.createdNoteList[i]);
        }

    }





}
