using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NoteData
{
    public int measurePosition; // 001 마디(제일 처음마디)위치

    public int linePosition; // A2 라인위치(첫번째라인)

    public string notePosition; // 00AA 노트위치

    public float noteTime; // 노트 생성 시간

    public float songStartTime; // 음악 재생 시간
}






//BMS파일을 불러오는 스크립트
public class BMS_Test : MonoBehaviour
{

    //static으로 작성/어디서든 접근 가능하도록

    public static BMS_Test bms_test;

    public static BMS_Test GetbmsData()
    {
        if (BMS_Test.bms_test == null)
        {
            BMS_Test.bms_test = new BMS_Test();
        }
        return BMS_Test.bms_test;
    }


    [SerializeField] private string bmsFile;

    public NoteData noteData;


    private int headKey;
    private int noteKey;
    private float tikTime;



    private Dictionary<int, string> dicBmsData;
    private Dictionary<string, string> dicHeaderData;

    private Queue<NoteData> queNoteDataAZ;



    void Start()
    {
        ReadBMSfile();
    }



    private void ReadBMSfile()
    {
      
        string[] bmsData = File.ReadAllLines(bmsFile);
        for (int i = 0; i < bmsData.Length; i++)
        {
            this.dicBmsData.Add(i, bmsData[i]);
        }
        Debug.Log("BMS 파일을 불러옵니다.");
        this.SetHeaderData();
    }

    //헤더 데이터 가져오기
    private void SetHeaderData()
    {
        foreach (var pair in this.dicBmsData)
        {
            var key = pair.Key;
            var data = pair.Value;
            if (data == "*---------------------- HEADER FIELD")
            {
                this.headKey = key;
                for (int i = this.headKey; i < this.dicBmsData.Count; i++)
                {
                    if (this.dicBmsData[i].StartsWith("#"))
                    {//#BPM 146.5
                        string[] arrNote = this.dicBmsData[i].Split('#');
                        //BPM 146.5
                        string[] stageData = arrNote[1].Split(' ');
                        //BPM
                        //146.5
                        this.dicHeaderData.Add(stageData[0], stageData[1]);
                    }
                    else if (this.dicBmsData[i] == "*---------------------- MAIN DATA FIELD")
                    {
                        goto EXIT;
                    }
                }
            }
        }
    EXIT:
        {
            Debug.Log("헤더 데이터가 로드되었습니다.");
            this.SetNoteData();
        }
    }
    public Dictionary<string, string> GetHeaderData()
    {
        return this.dicHeaderData;
    }



    //노트 데이터 가져오기
    private void SetNoteData()
    {
        foreach (var pair in this.GetHeaderData())
        {
            var bpm = pair.Key;
            var data = pair.Value;
            if (bpm == "BPM")
            {
                float musicBPM = float.Parse(data);
                this.tikTime = (4 * 60) / musicBPM;
                break;
            }
        }
        foreach (var pair in this.dicBmsData)
        {
            var key = pair.Key;
            var data = pair.Value;
            if (data == "*---------------------- MAIN DATA FIELD")
            {
                this.noteKey = key;
                for (int j = this.noteKey; j < this.dicBmsData.Count; j++)
                {
                    if (this.dicBmsData[j].StartsWith("#"))
                    {
                        //#00111:00AA00AA00AA0000
                        string[] arrNote = this.dicBmsData[j].Split('#');
                        //00111:00AA00AA00AA0000
                        string[] arrData = arrNote[1].Split(':');
                        //00111
                        //00AA00AA00AA0000
                        int tempMeasurePosition = int.Parse(arrData[0].Substring(0, 3));// 001      //마디 위치
                        int tempLinePosition = int.Parse(arrData[0].Substring(3, 2));// 11      //노트 위치(11 : Y(AA)/ 12 : R(BB)/ 13 : B(CC)) 
                        string tempNotePosition = arrData[1];////00AA00AA0000BBBB
                        switch (tempLinePosition)
                        {
                            //음악정보 000,01,ZZ
                            case 01:
                                {
                                    for (int i = 0; i < tempNotePosition.Length / 2; i++)
                                    {
                                        if (tempNotePosition.Substring(i * 2, 2).StartsWith("Z"))
                                        {//음악정보 : 000, zz
                                            float tempNoteTime = ((tempMeasurePosition) * (this.tikTime)) + ((i) * (this.tikTime) / (tempNotePosition.Length / 2));//ZZ
                                            this.noteData = new NoteData();
                                            this.noteData.songStartTime = tempNoteTime;
                                            this.noteData.measurePosition = tempMeasurePosition;
                                            this.noteData.linePosition = tempLinePosition;
                                            this.noteData.noteTime = 10000.0f;
                                            this.noteData.notePosition = tempNotePosition;
                                            this.queNoteDataAZ.Enqueue(this.noteData);
                                        }
                                    }
                                    break;
                                }
                            //일반노트 AA
                            case 11:
                                {
                                    for (int i = 0; i < tempNotePosition.Length / 2; i++)
                                    {
                                        if (tempNotePosition.Substring(i * 2, 2).StartsWith("A"))   
                                        {//일반노트
                                            float tempNoteTime = ((tempMeasurePosition) * (this.tikTime)) + ((i) * (this.tikTime) / (tempNotePosition.Length / 2));//AA
                                            this.noteData = new NoteData();
                                            this.noteData.measurePosition = tempMeasurePosition;
                                            this.noteData.linePosition = tempLinePosition;
                                            this.noteData.noteTime = tempNoteTime;
                                            this.noteData.notePosition = tempNotePosition;
                                            this.noteData.songStartTime = 10000.0f;
                                            this.queNoteDataAZ.Enqueue(this.noteData);
                                        }
                                    }
                                    break;
                                }
                            //일반노트 BB
                            case 12:
                                {
                                    for (int i = 0; i < tempNotePosition.Length / 2; i++)
                                    {
                                        if (tempNotePosition.Substring(i * 2, 2).StartsWith("B"))
                                        {//일반노트
                                            float tempNoteTime = ((tempMeasurePosition) * (this.tikTime)) + ((i) * (this.tikTime) / (tempNotePosition.Length / 2));//BB
                                            this.noteData = new NoteData();
                                            this.noteData.measurePosition = tempMeasurePosition;
                                            this.noteData.linePosition = tempLinePosition;
                                            this.noteData.noteTime = tempNoteTime;
                                            this.noteData.notePosition = tempNotePosition;
                                            this.noteData.songStartTime = 10000.0f;
                                            this.queNoteDataAZ.Enqueue(this.noteData);
                                        }
                                    }
                                    break;
                                }
                            //일반노트 CC
                            case 13:
                                {
                                    for (int i = 0; i < tempNotePosition.Length / 2; i++)
                                    {
                                        if (tempNotePosition.Substring(i * 2, 2).StartsWith("C"))
                                        {//일반노트
                                            float tempNoteTime = ((tempMeasurePosition) * (this.tikTime)) + ((i) * (this.tikTime) / (tempNotePosition.Length / 2));//CC
                                            this.noteData = new NoteData();
                                            this.noteData.measurePosition = tempMeasurePosition;
                                            this.noteData.linePosition = tempLinePosition;
                                            this.noteData.noteTime = tempNoteTime;
                                            this.noteData.notePosition = tempNotePosition;
                                            this.noteData.songStartTime = 10000.0f;
                                            this.queNoteDataAZ.Enqueue(this.noteData);
                                        }
                                    }
                                    break;
                                }  
                          
                        }
                    }
                }
                Debug.Log("노트 데이터가 로드되었습니다.");
                break;
            }
        }
    }
    //노트데이터 aa,bb,cc,zz...?
    public Queue<NoteData> GetNoteDataAZ()
    {
        return this.queNoteDataAZ;
    }








    //void ParseLine(string line)
    //{
    //    // 헤더 필드 처리 예
    //    if (line.Contains(":"))
    //    {
    //        var split = line.Split(':');
    //        var key = split[0];
    //        var value = split[1];

    //        if (key.StartsWith("#WAV"))
    //        {
    //            Debug.Log($"Sample mapping: {key} -> {value}");
    //        }
    //        else if (key.Length >= 6)
    //        {
    //            var measure = key.Substring(1, 3);
    //            var channel = key.Substring(4, 2);
    //            Debug.Log($"Note data: Measure {measure}, Channel {channel}, Data {value}");
    //        }
    //    }
    //}


}
