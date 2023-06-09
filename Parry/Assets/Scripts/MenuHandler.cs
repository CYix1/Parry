using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public GameObject optionPanel;
    private MainInput input;
    void Awake()
    {
        input = new MainInput();
    }

    private void Start()    
    {
        
        Application.targetFrameRate = 50;
        
        QualitySettings.vSyncCount = 0;
        GameData.instance.health = 20;
        GameData.instance.coins = 0;
        var s=        optionPanel.GetComponentsInChildren<Slider>();
        SetMasterVolume(s[0].value);
        SetEffectVolume(s[1].value);
        SetBackgroundVolume(s[2].value);

    }
    private void Update()
    {
        if (input.Character.esc.WasPerformedThisFrame())
        {
            
            Resume();
        }
    }

    public void Resume()
    {
        triggerOptionPanel();
        Time.timeScale = optionPanel.activeSelf ? 0 : 1;
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

//        Debug.Log("set" + select + " v " + sliderValue);
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
    private void OnDisable()
    {
        
        input.Disable();
    }
    private void OnEnable()
    {
        
        input.Enable();
    }    
}
