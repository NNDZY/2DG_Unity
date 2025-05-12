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



    private void Awake()
    {
        noteImage = GetComponent<Image>();
    }




    void Update()
    {
        //localposition인 이유 : 그냥 position이면 캔버스 내 좌표가 아니라 월드좌표로 움직인다
        transform.localPosition += Vector3.left * noteSpeed * Time.deltaTime;

    }

    //노트를 숨김
    private void HideNote()
    {
        noteImage.enabled = false;
    }


}
