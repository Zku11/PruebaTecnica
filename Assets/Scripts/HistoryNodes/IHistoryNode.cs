using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*This interface establishes the necessary functions
*common to all types of nodes (dialogue, flow control and situation)
*/
public interface IHistoryNode
{
    void Execute();//run the node
    bool Finalized();//returns "true" if the node has finished its tasks
    IHistoryNode NextNode();//we get the next node from the current node
}
