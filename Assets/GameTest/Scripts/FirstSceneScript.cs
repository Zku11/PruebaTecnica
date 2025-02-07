using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using TMPro;


public class FirstSceneScript : MonoBehaviour
{
    public TMP_Text debugText;
    public DialogManager DialogManager;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        var dialog1 = new DialogData("Here you can create any mini-game you can think of and make me react to it", "Li");

        dialog1.Callback = () => {
            debugText.text = "xxxxxxxxx";
        };
        
        dialogTexts.Add(dialog1);



        DialogManager.Show(dialogTexts);
    }
}
