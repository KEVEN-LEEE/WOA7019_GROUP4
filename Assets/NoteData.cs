using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class NoteData
{
    // Unique ID for Apple's physical anchor
    public string anchorId; 

    // Color R, G, B values
    public float r = 1f;
    public float g = 0.92f;
    public float b = 0.6f;

    // Independently save the text and check status of 3 tasks
    public string text1;
    public bool isDone1;

    public string text2;
    public bool isDone2;

    public string text3;
    public bool isDone3;

    // ==========================================
    // [New] Whether it is high priority (whether to show the ⭐ icon)
    // ==========================================
    public bool isHighPriority;
}