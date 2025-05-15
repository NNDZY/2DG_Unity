using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BMS_Test : MonoBehaviour
{

    public string bmsFileName = "XH-PLUTO.bms";


    void Start()
    {
        string path = Path.Combine(Application.streamingAssetsPath, bmsFileName);
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (line.StartsWith("#"))
                {
                    ParseLine(line.Trim());
                }
            }
        }
    }

    void ParseLine(string line)
    {
        // 헤더 필드 처리 예
        if (line.Contains(":"))
        {
            var split = line.Split(':');
            var key = split[0];
            var value = split[1];

            if (key.StartsWith("#WAV"))
            {
                Debug.Log($"Sample mapping: {key} -> {value}");
            }
            else if (key.Length >= 6)
            {
                var measure = key.Substring(1, 3);
                var channel = key.Substring(4, 2);
                Debug.Log($"Note data: Measure {measure}, Channel {channel}, Data {value}");
            }
        }
    }


}
