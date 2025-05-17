using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ffStageManager : MonoBehaviour
{

    [SerializeField] GameObject stage = null;
    Transform[] stagePlates;

    int stepCount = 0;
    int totalPlateCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        stagePlates = stage.GetComponent<ffStage>().plates;
        totalPlateCount = stagePlates.Length;
    }

    public void ShowNextPlates()
    {
        if(stepCount<totalPlateCount)
        {
        stagePlates[stepCount++].gameObject.SetActive(true);

        }
    }
}
