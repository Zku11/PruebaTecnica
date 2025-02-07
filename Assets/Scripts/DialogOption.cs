using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogOption : MonoBehaviour
{
    [SerializeField] TMP_Text buttonText;
    [SerializeField] int optionIndex;

    public void ButtonClick()
    {
        OptionsDisplay.GetInstance().SelectOption(optionIndex);
    }

    public void SetText(string text)
    {
        buttonText.text = text;
    }
}
