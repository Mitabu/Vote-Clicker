using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMechanics : MonoBehaviour
{
    public static int AudioSetting;
    private int TempAudioSetting = -1;
    public AudioSource AudioObject;
    public GameObject AudioOffImage;

    public void Update()
    {
        CheckAudioState();
    }

    private void CheckAudioState()
    {
        if (TempAudioSetting == -1)
        {
            TempAudioSetting = AudioSetting;
            //Debug.Log("Updating temp...");
            SwitchAudio();
        }
        if(TempAudioSetting != AudioSetting)
        {
            SwitchAudio();
            //Debug.Log("Switching audio....");
        }
        //Debug.Log(AudioSetting);
    }
    private void SwitchAudio()
    {
        AudioSetting = PlayerPrefs.GetInt("AudioSetting");
        if (AudioSetting == 0)
        {
            AudioObject.Play();
            AudioSetting = 0;
            AudioOffImage.SetActive(false);
            TempAudioSetting = AudioSetting;
        }
        else if (AudioSetting == 1)
        {
            AudioObject.Stop();
            AudioSetting = 1;
            AudioOffImage.SetActive(true);
            TempAudioSetting = AudioSetting;
        }
    }

    public void SwitchAudioState()
    {
        if (PlayerPrefs.GetInt("AudioSetting") == 0)
        {
            PlayerPrefs.SetInt("AudioSetting", 1);
            AudioSetting = 1;
            //Debug.Log("Turning Audio off...");
        }
        else if (PlayerPrefs.GetInt("AudioSetting") == 1)
        {
            PlayerPrefs.SetInt("AudioSetting", 0);
            AudioSetting = 0;
            //Debug.Log("Turning Audio on...");
        }
    }
}
