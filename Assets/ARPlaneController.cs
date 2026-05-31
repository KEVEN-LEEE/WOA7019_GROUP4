using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPlaneController : MonoBehaviour
{
    private ARPlaneManager planeManager;
    
    // Add this variable to remember whether it is currently shown or hidden (shown by default)
    private bool arePlanesVisible = true; 

    void Start()
    {
        planeManager = GetComponent<ARPlaneManager>();
    }

    // ==========================================
    // [New] This is a "toggle" function specifically for buttons
    // ==========================================
    public void TogglePlanes()
    {
        // State inversion: if true it becomes false, if false it becomes true
        arePlanesVisible = !arePlanesVisible; 
        
        // Execute show or hide
        SetPlanesVisible(arePlanesVisible);
    }

    // The original execution logic remains unchanged
    public void SetPlanesVisible(bool visible)
    {
        if (planeManager == null) planeManager = GetComponent<ARPlaneManager>();

        // 1. Enable/disable the plane manager
        planeManager.enabled = visible;

        // 2. Hide/show all currently generated yellow grid planes
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(visible);
        }

        Debug.Log(visible ? "AR planes shown" : "AR planes hidden");
    }
}