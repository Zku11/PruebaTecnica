using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsList : MonoBehaviour, IHistoryNode, IFlowControl
{
    [SerializeField] DialogTurnNode[] nextNodes;
    DialogTurnNode currentNextNode;
    bool finalized;
    [SerializeField] string[] optionsText;

    public IHistoryNode NextNode()
    {
        return currentNextNode;
    }

    public void SelectNextNode(int nodeIndex)
    {
        currentNextNode = nextNodes[nodeIndex];
        finalized = true;
    }

    public void Execute()
    {
        finalized = false;
        OptionsDisplay.GetInstance().ShowOptions(this, optionsText);
    }

    public bool Finalized()
    {
        return finalized;
    }
}
