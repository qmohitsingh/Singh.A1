using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerManager : MonoBehaviour
{
    void Awake()
    {
        // Find all Audio Listeners in the scene
        AudioListener[] listeners = FindObjectsOfType<AudioListener>();
        
        foreach (var listener in listeners)
        {
            // Disable all Audio Listeners except the one on the Main Camera
            if(listener.gameObject != Camera.main.gameObject)
            {
                listener.enabled = false;
            }
        }
    }
}
