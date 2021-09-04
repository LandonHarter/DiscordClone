using System.Collections.Generic;
using Photon.Voice;
using Photon.Voice.Unity;
using TMPro;
using UnityEngine;

public class MicrophoneSetup : MonoBehaviour
{

    public TMP_Dropdown dropdown;
    public Recorder recorder;
    
    private string[] microphones;
    private int currentValue;

    void Update()
    {
#if !UNITY_WEBGL
      microphones = Microphone.devices;

        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        for (int i = 0; i < microphones.Length; i++)
        {
            options.Add(new TMP_Dropdown.OptionData(microphones[i]));
        }

        dropdown.itemText.enableAutoSizing = true;
        dropdown.itemText.fontSizeMin = 8;
        dropdown.itemText.maxVisibleLines = 1;
        dropdown.options = options;  
#endif
    }

    public void UpdateMicrophone()
    {
#if !UNITY_WEBGL
        microphones = Microphone.devices;
        
        currentValue = dropdown.value;
        string newMic = microphones[currentValue];

        if (currentValue == 0) currentValue = -128;

        recorder.MicrophoneDevice = new DeviceInfo(newMic, newMic);
#endif
    }

}
