using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This interface establishes the necessary and common functions for flow control type nodes.
 */
public interface IFlowControl
{
    void SelectNextNode(int nodeIndex);
}
