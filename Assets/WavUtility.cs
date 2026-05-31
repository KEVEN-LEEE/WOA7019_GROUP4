using System;
using System.IO;
using UnityEngine;

public static class WavUtility
{
    // Convert AudioClip to standard WAV format and save it to the mobile sandbox
    public static bool Save(string filename, AudioClip clip)
    {
        if (clip == null) return false;
        string filepath = Path.Combine(Application.persistentDataPath, filename);
        
        try 
        {
            using (FileStream fileStream = new FileStream(filepath, FileMode.Create)) 
            {
                using (BinaryWriter writer = new BinaryWriter(fileStream)) 
                {
                    int hz = clip.frequency;
                    int channels = clip.channels;
                    int samples = clip.samples;
                    float[] data = new float[samples * channels];
                    clip.GetData(data, 0);

                    Int16[] intData = new Int16[data.Length];
                    for (int i = 0; i < data.Length; i++) {
                        intData[i] = (short)(data[i] * 32767);
                    }

                    // Write WAV file header
                    writer.Write(new char[4] { 'R', 'I', 'F', 'F' });
                    writer.Write(36 + intData.Length * 2);
                    writer.Write(new char[4] { 'W', 'A', 'V', 'E' });
                    writer.Write(new char[4] { 'f', 'm', 't', ' ' });
                    writer.Write(16);
                    writer.Write((short)1);
                    writer.Write((short)channels);
                    writer.Write(hz);
                    writer.Write(hz * channels * 2);
                    writer.Write((short)(channels * 2));
                    writer.Write((short)16);
                    writer.Write(new char[4] { 'd', 'a', 't', 'a' });
                    writer.Write(intData.Length * 2);

                    // Write audio data
                    foreach (var sample in intData) {
                        writer.Write(sample);
                    }
                }
            }
            return true;
        } 
        catch (Exception e) 
        {
            Debug.LogError("Failed to save WAV: " + e.Message);
            return false;
        }
    }
}