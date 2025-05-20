using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


[System.Serializable]
public class NoteData
{
    public float time;       // 음악 시작 후 몇 초에 노트 생성
    public int lane;         // 0:AA, 1:BB, 2:CC
}




public class BMSParser : MonoBehaviour
{
    public string bmsFileName = "XH-PLUTO.bms"; // 확장자 포함 (StreamingAssets 안에 있어야 함)
    public float bpm = 155f;    //bpm연결


    //파일을 줄 단위로 읽고 노트데이터를 리스트로 반환
    public List<NoteData> Parse()
    {
        List<NoteData> notes = new List<NoteData>();

        // StreamingAssets 경로에서 BMS 파일 읽기
        string path = Path.Combine(Application.streamingAssetsPath, bmsFileName);

        //파일이 경로에 없으면
        if (!File.Exists(path))
        {
            Debug.LogError("BMS 파일을 찾을 수 없습니다: " + path);
            return notes;
        }


        string[] lines = File.ReadAllLines(path);
        float beatDuration = 60f / bpm;     //초당 bpm..박자

        //foreach (string line in lines)
        //{
        //    //#이 없는 데이터 등은 넘어가라
        //    if (!line.StartsWith("#") || !line.Contains(":")) continue;


        //    string measure = line.Substring(1, 3);
        //    string channel = line.Substring(4, 2);
        //    string data = line.Split(':')[1].Trim();

        //    int measureNum = int.Parse(measure);
        //    float totalDiv = data.Length / 2;
        //    float measureTime = measureNum * 4f * beatDuration;

        //    for (int i = 0; i < totalDiv; i++)
        //    {
        //        string note = data.Substring(i * 2, 2);
        //        if (note == "00") continue; //00 : 노트없음

        //        int lane = -1;
        //        if (note == "AA") lane = 0;
        //        else if (note == "BB") lane = 1;
        //        else if (note == "CC") lane = 2;
        //        else continue;

        //        float timing = measureTime + ((float)i / totalDiv) * 4f * beatDuration;
        //        notes.Add(new NoteData { time = timing, lane = lane });
        //}
        //}

        var mergedData = new Dictionary<string, string>();

        foreach (string line in lines)
        {
            if (!line.StartsWith("#") || !line.Contains(":")) continue;

            string header = line.Substring(1, 5);
            string data = line.Split(':')[1].Trim();

            if (!mergedData.ContainsKey(header))
                mergedData[header] = data;
            else
                mergedData[header] += data;
        }

        foreach (var kv in mergedData)
        {
            string measure = kv.Key.Substring(0, 3);
            string channel = kv.Key.Substring(3, 2);
            string data = kv.Value;

            // 데이터 길이는 반드시 2로 나누어떨어져야 함
            if (data.Length % 2 != 0)
            {
                Console.WriteLine($"[경고] 데이터 길이가 홀수입니다: {kv.Key} => {data.Length}");
                continue;
            }

            int totalDiv = data.Length / 2; // 정수 기반 분할
            int measureNum = int.Parse(measure);
            float measureStartTime = measureNum * 4f * beatDuration;

            for (int i = 0; i < totalDiv; i++)
            {
                string note = data.Substring(i * 2, 2);
                if (note == "00") continue;

                int lane = -1;
                if (note == "BB") lane = 0;    //R
                else if (note == "CC") lane = 1;    //B
                else if (note == "AA") lane = 2;         //Y
                else continue;

                // 분할 위치에 따른 정확한 타이밍 계산
                float timing = measureStartTime + ((float)i / totalDiv) * 4f * beatDuration;
                Debug.Log($"[NOTE] measure:{measure}, channel:{channel}, i:{i}, note:{note}, timing:{timing:F4}, lane:{lane}");
                notes.Add(new NoteData { time = timing, lane = lane });
            }
        }









        Debug.Log($"노트 개수: {notes.Count}");
        return notes;
    }
}
