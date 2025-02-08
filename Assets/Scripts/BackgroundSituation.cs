using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSituation : MonoBehaviour, IHistoryNode
{
    [SerializeField] DialogTurnNode nextDialogNode;
    [SerializeField] OptionsList nextControlNode;
    [SerializeField] BasketGame nextControlNodeBasketGame;
    IHistoryNode nextNode;
    [SerializeField] GameObject backgroundPanel;
    bool finalized;
    [SerializeField] float FinalizeTime; 

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
        else if (nextControlNodeBasketGame)
        {
            nextNode = nextControlNodeBasketGame;
        }
    }

    public IHistoryNode NextNode()
    {
        return nextNode;
    }

    public void Execute()
    {
        finalized = false;
        backgroundPanel.SetActive(true);
        StartCoroutine("FinalizeDelay");
    }

    public bool Finalized()
    {
        return finalized;
    }

    IEnumerator FinalizeDelay()
    {
        yield return new WaitForSeconds(FinalizeTime);
        finalized = true;
    }
}
