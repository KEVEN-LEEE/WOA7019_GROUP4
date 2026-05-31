using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using System.Collections;
using System.Collections.Generic;

// If you installed the Mobile Notifications plugin, this error will disappear
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif

public class NoteEditor : MonoBehaviour
{
    [Header("UI References")]
    public GameObject editorPanel;
    public TMP_InputField input1;
    public TMP_InputField input2;
    public TMP_InputField input3;

    [Header("Voice Memo UI")]
    public TMP_Text recordBtnText;
    public GameObject recordingIndicator;
    private bool isRecording = false;

    [Header("Reminder Feature UI")]
    public TMP_Dropdown hourDropdown;   // Hour
    public TMP_Dropdown minuteDropdown; // Minute

    private bool isDropdownInitialized = false;
    private GameObject currentNote;

    // Color configuration
    private Color colorYellow = new Color(1f, 0.92f, 0.6f, 1f);
    private Color colorBlue = new Color(0.6f, 0.8f, 1f, 1f);
    private Color colorRed = new Color(1f, 0.6f, 0.6f, 1f);
    private Color colorGreen = new Color(0.6f, 1f, 0.6f, 1f);

    // Called to open the edit panel when the user taps a sticky note in the AR scene
    public void SelectNote(GameObject note)
    {
        if (note == null) return;
        currentNote = note;

        // Load existing text from the current sticky note into the input fields
        LoadTaskText(note, "Canvas/Task1", input1);
        LoadTaskText(note, "Canvas/Task2", input2);
        LoadTaskText(note, "Canvas/Task3", input3);

        InitTimeDropdowns(); // Initialize the alarm dropdown list
        
        if (recordingIndicator) recordingIndicator.SetActive(false);
        editorPanel.SetActive(true);
    }

    private void LoadTaskText(GameObject note, string path, TMP_InputField input)
    {
        Transform t = note.transform.Find(path + "/Text");
        if (t != null && t.GetComponent<TMP_Text>() != null)
        {
            string txt = t.GetComponent<TMP_Text>().text;
            // Strip strikethrough tags so the input field shows clean text
            input.text = txt.Replace("<s>", "").Replace("</s>", "");
        }
    }

    // [Core Fix]: Called when clicking the "Done/Save" button to ensure text is synced and saved
    public void SaveText()
    {
        if (currentNote != null)
        {
            // Force write input field content back to the sticky note object
            SyncToNote(1, input1.text);
            SyncToNote(2, input2.text);
            SyncToNote(3, input3.text);

            // Trigger global save
            if (SaveManager.instance != null) SaveManager.instance.SaveNotes();
            
            // Attempt to save the AR map (if WorldMapManager exists)
            FindObjectOfType<WorldMapManager>()?.SaveWorldMap();
        }
        ClosePanelDirectly();
    }

    private void SyncToNote(int index, string text)
    {
        Transform t = currentNote.transform.Find($"Canvas/Task{index}");
        if (t != null)
        {
            TaskItem item = t.GetComponent<TaskItem>();
            Toggle tog = t.Find("Toggle")?.GetComponent<Toggle>();
            if (item != null)
            {
                // Call TaskItem's initialization method to sync text and state
                item.InitTask(text, tog != null && tog.isOn);
            }
        }
    }

    public void ClosePanelDirectly()
    {
        if (isRecording) ToggleRecording(); // Automatically stop recording if currently recording upon closing
        editorPanel.SetActive(false);
    }

    public void DeleteCurrentNote()
    {
        if (currentNote != null)
        {
            SaveManager.instance?.RemoveNote(currentNote);
        }
        ClosePanelDirectly();
    }

    // --- Color Switching Feature ---
    public void SetColorYellow() { ApplyColor(colorYellow); }
    public void SetColorBlue() { ApplyColor(colorBlue); }
    public void SetColorRed() { ApplyColor(colorRed); }
    public void SetColorGreen() { ApplyColor(colorGreen); }

    private void ApplyColor(Color c)
    {
        if (currentNote == null) return;
        currentNote.GetComponent<MeshRenderer>().material.color = c;
        Transform bg = currentNote.transform.Find("Canvas/Background");
        if (bg != null && bg.GetComponent<Image>() != null)
        {
            bg.GetComponent<Image>().color = c;
        }
        SaveManager.instance?.SaveNotes(); // Auto-save after changing color
    }

    // --- Priority Switching ---
    public void TogglePriority()
    {
        if (currentNote == null) return;
        Transform icon = currentNote.transform.Find("Canvas/PriorityIcon");
        if (icon != null)
        {
            icon.gameObject.SetActive(!icon.gameObject.activeSelf);
        }
        SaveManager.instance?.SaveNotes();
    }

    // --- Recording Feature ---
    public void ToggleRecording()
    {
        if (currentNote == null) return;
        AudioSource s = currentNote.GetComponent<AudioSource>() ?? currentNote.AddComponent<AudioSource>();

        if (!isRecording)
        {
            s.clip = Microphone.Start(null, false, 60, 44100);
            isRecording = true;
            if (recordBtnText) recordBtnText.text = "⏹ Stop Recording";
            if (recordingIndicator) recordingIndicator.SetActive(true);
        }
        else
        {
            int pos = Microphone.GetPosition(null);
            Microphone.End(null);
            isRecording = false;
            if (recordBtnText) recordBtnText.text = "🎤 Start Recording";
            if (recordingIndicator) recordingIndicator.SetActive(false);

            if (pos > 0)
            {
                ARAnchor anchor = currentNote.GetComponent<ARAnchor>();
                if (anchor != null)
                {
                    // Save recording to local storage
                    WavUtility.Save(anchor.trackableId.ToString() + ".wav", s.clip);
                    // Show the recording icon on the sticky note
                    Transform vIcon = currentNote.transform.Find("Canvas/VoiceIcon");
                    if (vIcon) vIcon.gameObject.SetActive(true);
                }
            }
        }
    }

    public void PlayAudio()
    {
        AudioSource s = currentNote?.GetComponent<AudioSource>();
        if (s != null && s.clip != null) s.Play();
    }

    // --- Alarm Setting Logic ---
    private void InitTimeDropdowns()
    {
        if (isDropdownInitialized) return;
        hourDropdown.ClearOptions(); minuteDropdown.ClearOptions();
        List<string> h = new List<string>(); for (int i = 0; i < 24; i++) h.Add(i.ToString("D2"));
        List<string> m = new List<string>(); for (int i = 0; i < 60; i++) m.Add(i.ToString("D2"));
        hourDropdown.AddOptions(h); minuteDropdown.AddOptions(m);
        hourDropdown.value = System.DateTime.Now.Hour;
        minuteDropdown.value = System.DateTime.Now.Minute;
        isDropdownInitialized = true;
    }

    public void ScheduleReminder()
    {
        if (currentNote == null) return;
        string id = currentNote.GetComponent<ARAnchor>()?.trackableId.ToString() ?? "default";
#if UNITY_IOS
        StartCoroutine(RequestAndScheduleNotification(hourDropdown.value, minuteDropdown.value, id));
#else
        Debug.Log($"Alarm set (Simulated): {hourDropdown.value}:{minuteDropdown.value}");
#endif
    }

    // [Restored Feature]: Cancel alarm
    public void CancelReminder()
    {
        if (currentNote == null) return;
        string noteID = "default";
        ARAnchor anchor = currentNote.GetComponent<ARAnchor>();
        if (anchor != null) noteID = anchor.trackableId.ToString();

#if UNITY_IOS
        iOSNotificationCenter.RemoveScheduledNotification(noteID);
        Debug.Log($"🚫 Cancelled alarm with ID {noteID}");
#else
        Debug.Log($"🚫 Simulated: Cancelled alarm with ID {noteID}");
#endif
    }

#if UNITY_IOS
    private IEnumerator RequestAndScheduleNotification(int hour, int minute, string noteID)
    {
        var auth = AuthorizationOption.Alert | AuthorizationOption.Sound;
        using (var req = new AuthorizationRequest(auth, true))
        {
            while (!req.IsFinished) yield return null;
            if (req.Granted)
            {
                var trigger = new iOSNotificationCalendarTrigger() { Hour = hour, Minute = minute, Repeats = false };
                var notification = new iOSNotification() {
                    Identifier = noteID,
                    Title = "⏰ AR Sticky Note Reminder",
                    Body = $"you set {hour:D2}:{minute:D2} Mission time is up!",
                    Trigger = trigger,
                    ShowInForeground = true
                };
                iOSNotificationCenter.ScheduleNotification(notification);
                Debug.Log("✅ Alarm successfully scheduled");
            }
        }
    }
#endif
}