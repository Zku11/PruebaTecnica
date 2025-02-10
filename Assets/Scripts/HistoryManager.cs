using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;


public class HistoryManager : MonoBehaviour//Execute the different nodes of which the story is made up
{
    [SerializeField] BackgroundSituation initialNode;
    IHistoryNode currentNode;
    [SerializeField] DialogManager DialogManager;

    void Start()
    {
        currentNode = (IHistoryNode) initialNode;
        ExecuteNode(currentNode);//Execute the first node
    }

    private void ExecuteNode(IHistoryNode node)//Execute nodes (IHistoryNode interface)
    {
        node.Execute();
    }

    void Update()
    {
        if (currentNode.Finalized())//when a node finishes its execution this function returns true
        {
            currentNode = currentNode.NextNode();//We obtain the next node to execute, which has its reference in the current node
            ExecuteNode(currentNode);
        }
    }
}
