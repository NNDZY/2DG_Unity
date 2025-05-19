using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class NoteData
{
    public float time;       // ���� ���� �� �� �ʿ� ��Ʈ ����
    public int lane;         // 0:AA, 1:BB, 2:CC
}




public class BMSParser : MonoBehaviour
{
    public string bmsFileName = "XH-PLUTO.bms"; // Ȯ���� ���� (StreamingAssets �ȿ� �־�� ��)
    public float bpm = 155f;    //bpm����


    //������ �� ������ �а� ��Ʈ�����͸� ����Ʈ�� ��ȯ
    public List<NoteData> Parse()
    {
        List<NoteData> notes = new List<NoteData>();

        // StreamingAssets ��ο��� BMS ���� �б�
        string path = Path.Combine(Application.streamingAssetsPath, bmsFileName);

        //������ ��ο� ������
        if (!File.Exists(path))
        {
            Debug.LogError("BMS ������ ã�� �� �����ϴ�: " + path);
            return notes;
        }


        string[] lines = File.ReadAllLines(path);
        float beatDuration = 60f / bpm;     //�ʴ� bpm..����

        foreach (string line in lines)
        {
            //#�� ���� ������ ���� �Ѿ��
            if (!line.StartsWith("#") || !line.Contains(":")) continue;


            string measure = line.Substring(1, 3);
            string channel = line.Substring(4, 2);
            string data = line.Split(':')[1].Trim();

            int measureNum = int.Parse(measure);
            int totalDiv = data.Length / 2;
            float measureTime = measureNum * 4f * beatDuration;

            for (int i = 0; i < totalDiv; i++)
            {
                string note = data.Substring(i * 2, 2);
                if (note == "00") continue; //00 : ��Ʈ����

                int lane = -1;
                if (note == "AA") lane = 0;
                else if (note == "BB") lane = 1;
                else if (note == "CC") lane = 2;
                else continue;

                float timing = measureTime + ((float)i / totalDiv) * 4f * beatDuration;
                notes.Add(new NoteData { time = timing, lane = lane });
            }
        }

        Debug.Log($"��Ʈ ����: {notes.Count}");
        return notes;
    }
}
