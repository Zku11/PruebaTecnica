using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeTypes { dialog, control, situation};

public interface IHistoryNode
{
    IHistoryNode NextNode();
    NodeTypes GetNodeType();
    void Execute();
    bool Finalized();
}
