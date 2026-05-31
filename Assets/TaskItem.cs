using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskItem : MonoBehaviour
{
    private Toggle toggle;
    private TMP_Text textComponent;
    private string rawText = ""; 

    void Awake()
    {
        toggle = GetComponentInChildren<Toggle>();
        textComponent = GetComponentInChildren<TMP_Text>();
        if (toggle != null) toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    public void InitTask(string text, bool isDone)
    {
        rawText = string.IsNullOrEmpty(text) ? "" : text.Replace("<s>", "").Replace("</s>", "");
        if (toggle != null) toggle.SetIsOnWithoutNotify(isDone);
        UpdateTextDisplay(isDone);
    }

    private void OnToggleChanged(bool isOn)
    {
        UpdateTextDisplay(isOn);
        SaveManager.instance?.SaveNotes(); 
    }

    public void UpdateTextDisplay(bool isOn)
    {
        if (textComponent == null) return;
        if (isOn && !string.IsNullOrEmpty(rawText))
        {
            textComponent.text = $"<s>{rawText}</s>";
            textComponent.color = Color.gray;
        }
        else
        {
            textComponent.text = rawText;
            textComponent.color = Color.black; 
        }
    }
}