using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARKit;
using Unity.Collections;
using System.Collections;
using System.IO;

public class WorldMapManager : MonoBehaviour
{
    private ARKitSessionSubsystem sessionSubsystem;
    private string worldMapPath;

    void Start()
    {
        worldMapPath = Path.Combine(Application.persistentDataPath, "worldMap.worldmap");
        ARSession session = FindObjectOfType<ARSession>();
        if (session != null) sessionSubsystem = (ARKitSessionSubsystem)session.subsystem;
        StartCoroutine(WaitAndLoad());
    }

    private IEnumerator WaitAndLoad()
    {
        while (ARSession.state < ARSessionState.SessionTracking) yield return null;
        LoadWorldMap();
    }

    public void SaveWorldMap() { StartCoroutine(Save()); }

    IEnumerator Save()
    {
        if (sessionSubsystem == null) yield break;
        var request = sessionSubsystem.GetARWorldMapAsync();
        while (!request.status.IsDone()) yield return null;
        if (request.status == ARWorldMapRequestStatus.Success)
        {
            var data = request.GetWorldMap().Serialize(Allocator.Temp);
            File.WriteAllBytes(worldMapPath, data.ToArray());
            data.Dispose();
        }
    }

    public void LoadWorldMap()
    {
        if (!File.Exists(worldMapPath)) return;
        var data = File.ReadAllBytes(worldMapPath);
        var nativeData = new NativeArray<byte>(data, Allocator.Temp);
        if (ARWorldMap.TryDeserialize(nativeData, out ARWorldMap worldMap)) sessionSubsystem.ApplyWorldMap(worldMap);
        nativeData.Dispose();
    }
}