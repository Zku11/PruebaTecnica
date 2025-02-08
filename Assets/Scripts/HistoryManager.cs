using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;


public class HistoryManager : MonoBehaviour
{
    [SerializeField] BackgroundSituation initialNode;
    IHistoryNode currentNode;
    [SerializeField] DialogManager DialogManager;
    [SerializeField] string characterNameA, characterNameB;

    void Start()
    {
        currentNode = (IHistoryNode) initialNode;
        ExecuteNode(currentNode);
    }

    private void ExecuteNode(IHistoryNode node)
    {
        node.Execute();
    }

    void Update()
    {
        if (currentNode.Finalized())
        {
            currentNode = currentNode.NextNode();
            ExecuteNode(currentNode);
        }
    }
}
