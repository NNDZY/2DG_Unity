using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//빈 오브젝트(오브젝트풀)에 삽입

//객체의 정보를 담는 클래스 생성
[System.Serializable]
public class ObjectInfo
{
    public GameObject goPrefab;

    //풀링할 프리팹의 개수
    public int count;

    public Transform itPoolParent;
}


public class ObjectPool : MonoBehaviour
{

    [SerializeField] ObjectInfo[] objectInfo = null;


    //인스턴스를 통해 어디서든 ObjectPool변수, 함수에 접근 가능해짐
    public static ObjectPool instance;


    //Queue : 선입선출 자료형. 풀링에 사용할 오브젝트 선언
    public Queue<GameObject> noteQueue = new Queue<GameObject>();



    void Start()
    {

        instance = this;
        noteQueue = InsertQueue(objectInfo[0]);



        
    }


    //풀을 생성하는 함수
    Queue<GameObject> InsertQueue(ObjectInfo p_objectInfo)
    {
        Queue<GameObject> t_queue = new Queue<GameObject>();


        for(int i=0; i<p_objectInfo.count; i++)
        {
            //노트 프리팹을 발생시키고, 비활성화해둠
            GameObject t_clone = Instantiate(p_objectInfo.goPrefab, transform.position, Quaternion.identity);
            t_clone.SetActive(false);

            //만약 부모객체가 존재하면 그 객체를 부모로 삼고
            if(p_objectInfo.itPoolParent !=null)
            {
                t_clone.transform.SetParent(p_objectInfo.itPoolParent);
            }
            else
            {
                //부모가 null이면 이 스크립트를 가진 오브젝트를 부모로 삼는다
                t_clone.transform.SetParent(this.transform);
            }
            //count만큼의 객체를 생성함
            t_queue.Enqueue(t_clone);

        }
        return t_queue;


    }





}
