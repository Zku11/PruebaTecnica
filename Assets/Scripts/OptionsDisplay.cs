using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsDisplay : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject displayPanel;
    static OptionsDisplay instance;
    OptionsList optionReceiver;

    void Awake()
    {
        instance = this;
    }

    public static OptionsDisplay GetInstance()
    {
        return instance;
    }

    public void ShowOptions(OptionsList optionReceiver, string[] options)
    {
        this.optionReceiver = optionReceiver;
        UnableOptions();
        for (int i = 0; i < options.Length && i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
            buttons[i].GetComponent<DialogOption>().SetText(options[i]);
        }
        displayPanel.SetActive(true);
    }

    void UnableOptions()
    {
        foreach (GameObject gameObject in buttons)
        {
            gameObject.SetActive(false);
        }
    }

    public void SelectOption(int index)
    {
        optionReceiver.SelectNextNode(index);
        displayPanel.SetActive(false);
    }
}
