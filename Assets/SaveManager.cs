using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.ARFoundation;
using System.IO;
using UnityEngine.Networking;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    [Header("AR Anchor Manager")]
    public ARAnchorManager anchorManager;

    [Header("UI References (Optional)")]
    public TMP_Text toggleVisibilityBtnText; 

    [Header("All sticky notes currently in the scene")]
    public List<GameObject> notesList = new List<GameObject>();

    private Dictionary<string, NoteData> memoryDataDict = new Dictionary<string, NoteData>();
    private bool isNotesVisible = true; 
    private bool isDataLoaded = false; 

    private void Awake()
    {
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        LoadDataToMemory(); 
    }

    private void OnEnable()
    {
        if (anchorManager != null) anchorManager.anchorsChanged += OnAnchorsChanged;
    }

    private void OnDisable()
    {
        if (anchorManager != null) anchorManager.anchorsChanged -= OnAnchorsChanged;
    }

    private void OnAnchorsChanged(ARAnchorsChangedEventArgs eventArgs)
    {
        if (!isDataLoaded) return; 

        foreach (ARAnchor anchor in eventArgs.added)
        {
            string anchorId = anchor.trackableId.ToString();
            GameObject noteObj = anchor.gameObject;

            if (notesList.Contains(noteObj)) continue;

            if (!memoryDataDict.ContainsKey(anchorId))
            {
                Destroy(noteObj); // Physically erase ghost anchors
                continue;
            }

            notesList.Add(noteObj);
            RestoreNoteUI(noteObj, memoryDataDict[anchorId]);
            ApplyCurrentVisibility(noteObj);
        }

        foreach (ARAnchor anchor in eventArgs.removed)
        {
            if (notesList.Contains(anchor.gameObject)) notesList.Remove(anchor.gameObject);
        }
    }

    public void RemoveNote(GameObject note)
    {
        if (note == null) return;
        ARAnchor anchor = note.GetComponent<ARAnchor>();
        if (anchor != null)
        {
            string anchorId = anchor.trackableId.ToString();
            if (memoryDataDict.ContainsKey(anchorId)) memoryDataDict.Remove(anchorId);
            string audioPath = Path.Combine(Application.persistentDataPath, anchorId + ".wav");
            if (File.Exists(audioPath)) File.Delete(audioPath);
        }
        if (notesList.Contains(note)) notesList.Remove(note);
        Destroy(note); 
        SaveNotes(); 
    }

    public void SaveNotes()
    {
        if (!isDataLoaded) return; 

        for (int i = notesList.Count - 1; i >= 0; i--)
        {
            GameObject note = notesList[i];
            if (note == null) { notesList.RemoveAt(i); continue; }

            ARAnchor anchor = note.GetComponent<ARAnchor>();
            if (anchor == null) continue; 

            string id = anchor.trackableId.ToString();
            NoteData data = new NoteData { anchorId = id };

            MeshRenderer mr = note.GetComponent<MeshRenderer>();
            if (mr != null) { data.r = mr.material.color.r; data.g = mr.material.color.g; data.b = mr.material.color.b; }

            ExtractTaskData(note, "Canvas/Task1", out data.text1, out data.isDone1);
            ExtractTaskData(note, "Canvas/Task2", out data.text2, out data.isDone2);
            ExtractTaskData(note, "Canvas/Task3", out data.text3, out data.isDone3);

            Transform pIcon = note.transform.Find("Canvas/PriorityIcon");
            data.isHighPriority = pIcon != null && pIcon.gameObject.activeSelf;

            memoryDataDict[id] = data; 
        }

        NotesWrapper wrapper = new NotesWrapper { notes = new List<NoteData>(memoryDataDict.Values) };
        PlayerPrefs.SetString("AR_Notes_UI_Data", JsonUtility.ToJson(wrapper));
        PlayerPrefs.Save();
    }

    private void ExtractTaskData(GameObject note, string path, out string text, out bool isDone)
    {
        text = ""; isDone = false;
        Transform taskTrans = note.transform.Find(path);
        if (taskTrans != null)
        {
            TMP_Text textComp = taskTrans.Find("Text")?.GetComponent<TMP_Text>();
            Toggle toggleComp = taskTrans.Find("Toggle")?.GetComponent<Toggle>();
            if (textComp != null) text = textComp.text.Replace("<s>", "").Replace("</s>", "");
            if (toggleComp != null) isDone = toggleComp.isOn;
        }
    }

    private void LoadDataToMemory()
    {
        string json = PlayerPrefs.GetString("AR_Notes_UI_Data", "");
        if (!string.IsNullOrEmpty(json))
        {
            NotesWrapper wrapper = JsonUtility.FromJson<NotesWrapper>(json);
            if (wrapper != null && wrapper.notes != null)
                foreach (var data in wrapper.notes) memoryDataDict[data.anchorId] = data;
        }
        isDataLoaded = true;
    }

    private void RestoreNoteUI(GameObject note, NoteData data)
    {
        Color c = new Color(data.r, data.g, data.b, 1f);
        if (note.GetComponent<MeshRenderer>()) note.GetComponent<MeshRenderer>().material.color = c;
        Transform bg = note.transform.Find("Canvas/Background");
        if (bg && bg.GetComponent<Image>()) bg.GetComponent<Image>().color = c;

        ApplyTaskToUI(note, "Canvas/Task1", data.text1, data.isDone1);
        ApplyTaskToUI(note, "Canvas/Task2", data.text2, data.isDone2);
        ApplyTaskToUI(note, "Canvas/Task3", data.text3, data.isDone3);

        Transform pIcon = note.transform.Find("Canvas/PriorityIcon");
        if (pIcon) pIcon.gameObject.SetActive(data.isHighPriority);

        // [Restored Feature]: Load audio and show icon
        string audioPath = Path.Combine(Application.persistentDataPath, data.anchorId + ".wav");
        bool hasAudio = File.Exists(audioPath);
        Transform vIcon = note.transform.Find("Canvas/VoiceIcon");
        if (vIcon) vIcon.gameObject.SetActive(hasAudio);
        if (hasAudio) StartCoroutine(LoadAudioCoroutine(note, audioPath));
    }

    private void ApplyTaskToUI(GameObject note, string path, string text, bool isDone)
    {
        Transform t = note.transform.Find(path);
        if (t) (t.GetComponent<TaskItem>() ?? t.gameObject.AddComponent<TaskItem>()).InitTask(text, isDone);
    }

    private System.Collections.IEnumerator LoadAudioCoroutine(GameObject note, string path)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file://" + path, AudioType.WAV))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                AudioSource s = note.GetComponent<AudioSource>() ?? note.AddComponent<AudioSource>();
                s.clip = DownloadHandlerAudioClip.GetContent(www);
            }
        }
    }

    public void RegisterNote(GameObject note) { if (!notesList.Contains(note)) notesList.Add(note); }

    public void ToggleAllNotesVisibility()
    {
        isNotesVisible = !isNotesVisible;
        foreach (GameObject note in notesList) ApplyCurrentVisibility(note);
        if (toggleVisibilityBtnText) toggleVisibilityBtnText.text = isNotesVisible ? "👁️ Hide All" : "👓 Show All";
    }

    private void ApplyCurrentVisibility(GameObject note)
    {
        if (note == null) return;
        foreach (var r in note.GetComponentsInChildren<Renderer>()) r.enabled = isNotesVisible;
        foreach (var c in note.GetComponentsInChildren<Canvas>()) c.enabled = isNotesVisible;
        foreach (var col in note.GetComponentsInChildren<Collider>()) col.enabled = isNotesVisible;
    }
}