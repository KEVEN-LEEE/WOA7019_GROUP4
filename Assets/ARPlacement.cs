using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using UnityEngine.EventSystems; 

public class ARPlacement : MonoBehaviour
{
    public GameObject stickyPrefab;
    private ARRaycastManager raycastManager;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start() { raycastManager = GetComponent<ARRaycastManager>(); }

    void Update()
    {
        if (Input.touchCount == 0 || Input.GetTouch(0).phase != TouchPhase.Began) return;
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform.CompareTag("Sticky")) return;

        if (raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;
            if (Physics.OverlapSphere(pose.position, 0.10f).Length > 1) return; 

            GameObject note = Instantiate(stickyPrefab, pose.position, pose.rotation);
            if (note.GetComponent<ARAnchor>() == null) note.AddComponent<ARAnchor>();

            SaveManager.instance?.RegisterNote(note);
            StartCoroutine(DelayedSave());
        }
    }

    private System.Collections.IEnumerator DelayedSave()
    {
        yield return new WaitForSeconds(0.5f);
        SaveManager.instance?.SaveNotes();
        FindObjectOfType<WorldMapManager>()?.SaveWorldMap();
    }
}