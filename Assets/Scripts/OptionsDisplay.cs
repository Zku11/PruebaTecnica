using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script shows the current dialog options in the UI
 */

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

    //shows the indicated options and the receiver of the event when pressing an option
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

    void UnableOptions()//hide all previous options
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
