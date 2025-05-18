using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public AudioSource music;
    BMSParser parser;

    public Transform[] spawnPoints; // 0: AA, 1: BB, 2: CC
    public GameObject notePrefabR;
    public GameObject notePrefabB;
    public GameObject notePrefabY;

    private List<NoteData2> notes;
    private int nextIndex = 0;

    void Start()
    {
        parser = FindObjectOfType<BMSParser>();
        notes = parser.Parse();
        music.Play();
    }

    void Update()
    {
        if (nextIndex >= notes.Count) return;

        float songTime = music.time;

        while (nextIndex < notes.Count && notes[nextIndex].time <= songTime)
        {
            SpawnNote(notes[nextIndex]);
            nextIndex++;
        }
        //while (nextIndex < notes.Count && notes[nextIndex].time <= songTime + 1.5f)
        //{
        //    SpawnNote(notes[nextIndex]);
        //    nextIndex++;
        //}
    }

    void SpawnNote(NoteData2 note2)
    {
        Transform spawnPoint = spawnPoints[note2.lane];

        GameObject prefab = null;

        switch (note2.lane)
        {
            case 0: prefab = notePrefabY; break; // AA
            case 1: prefab = notePrefabR; break; // BB
            case 2: prefab = notePrefabB; break; // CC
        }

        if (prefab != null)
        {
            Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
