using UnityEngine;
using UnityEngine.EventSystems; // Must import this to detect UI clicks

public class NoteSelectable : MonoBehaviour
{
    void Update()
    {
        // 1. Trigger detection only at the exact moment of mouse down (PC) or finger touching the screen (Mobile)
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // =======================================================
            // [Kept your perfect logic]: Check if the click is on UI (prevent pass-through)
            // =======================================================
            if (EventSystem.current != null)
            {
                int pointerId = (Input.touchCount > 0) ? Input.GetTouch(0).fingerId : -1;
                
                if (EventSystem.current.IsPointerOverGameObject(pointerId))
                {
                    return; 
                }
            }

            Vector3 inputPos = Input.GetMouseButtonDown(0) ? Input.mousePosition : (Vector3)Input.GetTouch(0).position;
            if (Camera.main == null) return; 

            Ray ray = Camera.main.ScreenPointToRay(inputPos);
            
            // =======================================================
            // [Core Upgrade]: Changed to RaycastAll (penetrating raycast)
            // Solved the issue of AR plane grid colliders blocking clicks on sticky notes
            // =======================================================
            RaycastHit[] allHits = Physics.RaycastAll(ray);
            
            foreach (RaycastHit hit in allHits)
            {
                // Iterate through all objects hit by the raycast, trigger if it includes self
                if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                {
                    TriggerEditor();
                    break; // Break out of the loop immediately after triggering
                }
            }
        }
    }

    private void TriggerEditor()
    {
        NoteEditor editor = FindObjectOfType<NoteEditor>();
        
        if (editor != null)
        {
            editor.SelectNote(this.gameObject);
        }
    }
}