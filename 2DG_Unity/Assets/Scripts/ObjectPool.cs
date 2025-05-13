using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� ������Ʈ(������ƮǮ)�� ����

//��ü�� ������ ��� Ŭ���� ����
[System.Serializable]
public class ObjectInfo
{
    public GameObject goPrefab;

    //Ǯ���� �������� ����
    public int count;

    public Transform itPoolParent;
}


public class ObjectPool : MonoBehaviour
{

    [SerializeField] ObjectInfo[] objectInfo = null;


    //�ν��Ͻ��� ���� ��𼭵� ObjectPool����, �Լ��� ���� ��������
    public static ObjectPool instance;


    //Queue : ���Լ��� �ڷ���. Ǯ���� ����� ������Ʈ ����
    public Queue<GameObject> noteQueue = new Queue<GameObject>();



    void Start()
    {

        instance = this;
        noteQueue = InsertQueue(objectInfo[0]);



        
    }


    //Ǯ�� �����ϴ� �Լ�
    Queue<GameObject> InsertQueue(ObjectInfo p_objectInfo)
    {
        Queue<GameObject> t_queue = new Queue<GameObject>();


        for(int i=0; i<p_objectInfo.count; i++)
        {
            //��Ʈ �������� �߻���Ű��, ��Ȱ��ȭ�ص�
            GameObject t_clone = Instantiate(p_objectInfo.goPrefab, transform.position, Quaternion.identity);
            t_clone.SetActive(false);

            //���� �θ�ü�� �����ϸ� �� ��ü�� �θ�� ���
            if(p_objectInfo.itPoolParent !=null)
            {
                t_clone.transform.SetParent(p_objectInfo.itPoolParent);
            }
            else
            {
                //�θ� null�̸� �� ��ũ��Ʈ�� ���� ������Ʈ�� �θ�� ��´�
                t_clone.transform.SetParent(this.transform);
            }
            //count��ŭ�� ��ü�� ������
            t_queue.Enqueue(t_clone);

        }
        return t_queue;


    }





}
