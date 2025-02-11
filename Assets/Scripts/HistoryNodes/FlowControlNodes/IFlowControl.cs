using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This interface establishes the necessary and common functions for flow control type nodes.
 */
public interface IFlowControl
{
    void SelectNextNode(int nodeIndex);//From an internal list of nodes we choose one, according to the logic of the flow controller
}
