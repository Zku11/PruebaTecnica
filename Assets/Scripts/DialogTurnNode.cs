using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class DialogTurnNode : MonoBehaviour, IHistoryNode
{
    [SerializeField] string [] dialogLines;
    [SerializeField] string characterName;
    [SerializeField] DialogTurnNode nextDialogNode;
    [SerializeField] OptionsList nextControlNode;
    IHistoryNode nextNode;
    DialogManager dialogManager;
    bool finalized;

    void Start()
    {
        if (nextDialogNode != null)
        {
            nextNode = nextDialogNode;
        }
        else if (nextControlNode != null)
        {
            nextNode = nextControlNode;
        }
    }

    public IHistoryNode NextNode()
    {
        return nextNode;
    }

    public string[] GetDialogLines()
    {
        return dialogLines;
    }

    public string GetCharacterName()
    {
        return characterName;
    }

    public NodeTypes GetNodeType()
    {
        return NodeTypes.dialog;
    }

    public void Execute()
    {
        finalized = false;
        dialogManager = DialogManagerInstance.GetInstance();
        var dialogTexts = new List<DialogData>();
        DialogData dialogData;
        for (int i = 0; i < dialogLines.Length; i++)
        {
            dialogData = new DialogData(dialogLines[i], characterName);
            dialogTexts.Add(dialogData);
            if (i == dialogLines.Length - 1)
            {
                dialogData.Callback = () => {
                    finalized = true;
                };
            }
        }
        dialogManager.Show(dialogTexts);
    }

    public bool Finalized()
    {
        return finalized;
    }
}
