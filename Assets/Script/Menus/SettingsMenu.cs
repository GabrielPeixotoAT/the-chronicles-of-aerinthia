using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void SetVolume(float value)
    {
        GameMenager.Volume = value;
        AudioListener.volume = GameMenager.Volume;
    }
}
