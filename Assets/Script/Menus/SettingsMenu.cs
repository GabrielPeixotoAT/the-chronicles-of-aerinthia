using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider sliderVolume;

    void Awake()
    {
        sliderVolume.value = GameMenager.Volume;
    }

    public void SetVolume(float value)
    {
        GameMenager.Volume = value;
        AudioListener.volume = GameMenager.Volume;
    }
}
