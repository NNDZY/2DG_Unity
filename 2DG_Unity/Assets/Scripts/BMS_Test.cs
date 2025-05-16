using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NoteData
{
    public int measurePosition; // 001 ����(���� ó������)��ġ

    public int linePosition; // A2 ������ġ(ù��°����)

    public string notePosition; // 00AA ��Ʈ��ġ

    public float noteTime; // ��Ʈ ���� �ð�

    public float songStartTime; // ���� ��� �ð�
}






//BMS������ �ҷ����� ��ũ��Ʈ
public class BMS_Test : MonoBehaviour
{

    //static���� �ۼ�/��𼭵� ���� �����ϵ���

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
        Debug.Log("BMS ������ �ҷ��ɴϴ�.");
        this.SetHeaderData();
    }

    //��� ������ ��������
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
            Debug.Log("��� �����Ͱ� �ε�Ǿ����ϴ�.");
            this.SetNoteData();
        }
    }
    public Dictionary<string, string> GetHeaderData()
    {
        return this.dicHeaderData;
    }



    //��Ʈ ������ ��������
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
                        int tempMeasurePosition = int.Parse(arrData[0].Substring(0, 3));// 001      //���� ��ġ
                        int tempLinePosition = int.Parse(arrData[0].Substring(3, 2));// 11      //��Ʈ ��ġ(11 : Y(AA)/ 12 : R(BB)/ 13 : B(CC)) 
                        string tempNotePosition = arrData[1];////00AA00AA0000BBBB
                        switch (tempLinePosition)
                        {
                            //�������� 000,01,ZZ
                            case 01:
                                {
                                    for (int i = 0; i < tempNotePosition.Length / 2; i++)
                                    {
                                        if (tempNotePosition.Substring(i * 2, 2).StartsWith("Z"))
                                        {//�������� : 000, zz
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
                            //�Ϲݳ�Ʈ AA
                            case 11:
                                {
                                    for (int i = 0; i < tempNotePosition.Length / 2; i++)
                                    {
                                        if (tempNotePosition.Substring(i * 2, 2).StartsWith("A"))   
                                        {//�Ϲݳ�Ʈ
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
                            //�Ϲݳ�Ʈ BB
                            case 12:
                                {
                                    for (int i = 0; i < tempNotePosition.Length / 2; i++)
                                    {
                                        if (tempNotePosition.Substring(i * 2, 2).StartsWith("B"))
                                        {//�Ϲݳ�Ʈ
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
                            //�Ϲݳ�Ʈ CC
                            case 13:
                                {
                                    for (int i = 0; i < tempNotePosition.Length / 2; i++)
                                    {
                                        if (tempNotePosition.Substring(i * 2, 2).StartsWith("C"))
                                        {//�Ϲݳ�Ʈ
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
                Debug.Log("��Ʈ �����Ͱ� �ε�Ǿ����ϴ�.");
                break;
            }
        }
    }
    //��Ʈ������ aa,bb,cc,zz...?
    public Queue<NoteData> GetNoteDataAZ()
    {
        return this.queNoteDataAZ;
    }








    //void ParseLine(string line)
    //{
    //    // ��� �ʵ� ó�� ��
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
