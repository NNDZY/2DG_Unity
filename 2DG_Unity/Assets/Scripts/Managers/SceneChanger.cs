using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//�������Ʈ(��ü����)�� �ֱ�
public class SceneChanger : MonoBehaviour
{


    public void GotoOpenningScene()
    {
        SceneManager.LoadScene("1OpenningScene");    
    }

    public void GotoSelectScene()
    {
        SceneManager.LoadScene("2SelectScene");
    }

    public void GotoInGameScene()
    {
        SceneManager.LoadScene("3InGameScene");
    }

    public void GotoResultScene()
    {
        SceneManager.LoadScene("4EndingScene");
    }


    void Start()
    {
        //���콺 Ŀ���� ���� �߾ӿ� ������Ű�� �Ⱥ��̰� ��/��ư�� ��Ȱ��ȭ�Ǵ� ���� �߻�...
        //Cursor.lockState = CursorLockMode.Locked;
    }


}
