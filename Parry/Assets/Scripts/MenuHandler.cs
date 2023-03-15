using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public GameObject optionPanel;

    private void Start()
    {
        GameData.instance.health = 3;
    }

    public void SetMasterVolume(float sliderValue) => SetLevel("MasterVolume", sliderValue);
    public void SetEffectVolume(float sliderValue) => SetLevel("effectVolume", sliderValue);
    public void SetBackgroundVolume(float sliderValue) => SetLevel("backgroundVolume", sliderValue);

    private void SetLevel(string select, float sliderValue)
    {
        Toggle toggle = optionPanel.GetComponentInChildren<Toggle>();

        if (toggle.isOn)
            AudioManager.instance.masterVolume = 0;
        else
        {
            AudioManager.instance.masterVolume = sliderValue;
        }
        AudioManager.instance.mixer.SetFloat(select, Mathf.Log10(sliderValue) * 20);
        switch (select)
        {
            case "effectVolume":
                AudioManager.instance.soundEffectVolume = sliderValue;
                return;
            case "backgroundVolume":
                AudioManager.instance.backgroundVolume = sliderValue;
                return;
            default:
                AudioManager.instance.masterVolume = sliderValue;
                return;
        }
    }
    public void Exitgame()
    {
            
        Application.Quit();
    }
    
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void triggerOptionPanel()
    {
        optionPanel.SetActive(!optionPanel.activeSelf);
            
    }
}
