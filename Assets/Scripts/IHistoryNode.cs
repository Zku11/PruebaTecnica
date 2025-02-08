using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHistoryNode
{
    IHistoryNode NextNode();
    void Execute();
    bool Finalized();
}
