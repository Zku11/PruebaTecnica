using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*This interface establishes the necessary functions
*common to all types of nodes (dialogue, flow control and situation)
*/
public interface IHistoryNode
{
    IHistoryNode NextNode();
    void Execute();
    bool Finalized();
}
