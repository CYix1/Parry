using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public GameObject optionPanel;

    public void UpdateValues()
    {
        Slider slider = optionPanel.GetComponentInChildren<Slider>();
        Toggle toggle = optionPanel.GetComponentInChildren<Toggle>();

        if (toggle.isOn)
            AudioManager.instance.masterVolume = 0;
        else
        {
            AudioManager.instance.masterVolume = slider.value;
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
