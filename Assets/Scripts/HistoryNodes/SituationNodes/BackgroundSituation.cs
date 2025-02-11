using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
this script shows background situations such as the landscape during dusk
 */

public class BackgroundSituation : MonoBehaviour, IHistoryNode
{
    [SerializeField] DialogTurnNode nextDialogNode;
    [SerializeField] OptionsList nextControlNode;
    [SerializeField] BasketGame nextControlNodeBasketGame;
    IHistoryNode nextNode;
    [SerializeField] GameObject backgroundPanel;
    bool finalized;
    [SerializeField] float FinalizeTime;
    static List<BackgroundSituation> situationsList;

    void Awake()
    {
        situationsList = new List<BackgroundSituation>();
    }

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
        else if (nextControlNodeBasketGame != null)
        {
            nextNode = nextControlNodeBasketGame;
        }
        situationsList.Add(this);
    }

    public void Execute()
    {
        HideAll();
        finalized = false;
        backgroundPanel.SetActive(true);
        StartCoroutine("FinalizeDelay");
    }

    public bool Finalized()
    {
        return finalized;
    }

    public IHistoryNode NextNode()
    {
        return nextNode;
    }

    IEnumerator FinalizeDelay()//is a delay time before moving to the next node
    {
        yield return new WaitForSeconds(FinalizeTime);
        finalized = true;
    }

    void HideAll()//hide all previous backgrounds
    {
        foreach (BackgroundSituation backgroundSituation in situationsList)
        {
            backgroundSituation.backgroundPanel.SetActive(false);
        }
    }
}
