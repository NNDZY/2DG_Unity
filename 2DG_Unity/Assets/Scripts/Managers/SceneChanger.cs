using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//빈오브젝트(씬체인저)에 넣기
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
        //마우스 커서를 게임 중앙에 고정시키고 안보이게 함/버튼이 비활성화되는 문제 발생...
        //Cursor.lockState = CursorLockMode.Locked;
    }


}
