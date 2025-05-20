using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//노트에 넣음
//왼쪽으로 움직이면서 박자에 맞게? 움직여야함
public class Note : MonoBehaviour
{
    private float noteSpeed = 400.0f;

    Image noteImage;


    // 이 노트가 어느 라인(AA, BB, CC)에 속하는지에 대한 변수
    public int lane;

    //1번씩 호출
    private void OnEnable()
    {
        //노트이미지가 비활성화일때만 컨포넌트를 가져와서 활성화한다
        if(noteImage==null)
        {
        noteImage = GetComponent<Image>();
        }
        noteImage.enabled = true;
    }
    void Update()
    {
        //localposition인 이유 : 그냥 position이면 캔버스 내 좌표가 아니라 월드좌표로 움직인다
        transform.localPosition += Vector3.left * noteSpeed * Time.deltaTime;

    }

    //노트를 숨김
    public void HideNote()
    {
        noteImage.enabled = false;
    }

    //노트이미지를 비활성화
    public bool GetNoteFlag()
    {
        return noteImage.enabled;
    }


}
