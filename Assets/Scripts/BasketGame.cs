using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class BasketGame : MonoBehaviour, IHistoryNode, IFlowControl
{
    [SerializeField] DialogTurnNode[] nextNodes;
    DialogTurnNode currentNextNode;
    bool finalized;
    [SerializeField] int numberOfAttemptsLimit;
    int currentNumberOfAttemps = 0, goals;
    float holderStopDistance = 1.2f;
    [SerializeField] Animator ballAnimator;
    bool moveRigth, enableThrow;
    [SerializeField] GameObject ballHolder, stopPointLeft, stopPointRigth, visual;
    [SerializeField] GameObject [] basketedBalls;
    [SerializeField] string goodReactionMessage, badReactionMessage, neutralReactionMessage;
    [SerializeField] float holderSpeed;
    

    public IHistoryNode NextNode()
    {
        return currentNextNode;
    }

    public void SelectNextNode(int nodeIndex)
    {
        StopCoroutine("HolderMovement");
        StopCoroutine("RestartBall");
        currentNextNode = nextNodes[nodeIndex];
        enableThrow = false;
        StartCoroutine("FinalizeDelay");
    }

    public void Execute()
    {
        finalized = false;
        visual.SetActive(true);
        enableThrow = true;
        DisableBaketedBalls();
        currentNumberOfAttemps = 0;
        goals = 0;
        StartCoroutine("HolderMovement");
    }

    public bool Finalized()
    {
        return finalized;
    }

    public void ThrowBall()//throw the paper ball
    {
        if (enableThrow)
        {
            enableThrow = false;
            StartCoroutine("EnableThrowDelay");
            ballAnimator.SetTrigger("throwBall");
            StopCoroutine("HolderMovement");
            StartCoroutine("RestartBall");
            currentNumberOfAttemps++;
            if (currentNumberOfAttemps == numberOfAttemptsLimit)
            {
                if (goals > numberOfAttemptsLimit - goals)
                {
                    SelectNextNode(0);
                }
                else
                {
                    SelectNextNode(1);
                }
            }
        }
    }

    IEnumerator EnableThrowDelay()//It is a small waiting time between each launch
    {
        yield return new WaitForSeconds(2.5f);
        enableThrow = true;
        if ((currentNumberOfAttemps % 2 == 0))
        {
            if ((goals > currentNumberOfAttemps - goals))
            {
                PlayerMessage(goodReactionMessage);
            }
            else if(goals < currentNumberOfAttemps - goals)
            {
                PlayerMessage(badReactionMessage);
            }
            else
            {
                PlayerMessage(neutralReactionMessage);
            }
        }
    }

    IEnumerator FinalizeDelay()//It is a short waiting time after finishing the mini-game.
    {
        yield return new WaitForSeconds(2f);
        visual.SetActive(false);
        finalized = true;
    }

    IEnumerator RestartBall()//place a new paper ball in your hand
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine("HolderMovement");
    }

    IEnumerator HolderMovement()//shaking hand movement
    {
        while (true)
        {
            if (Vector2.Distance(ballHolder.transform.position, stopPointLeft.transform.position) < holderStopDistance)
            {
                moveRigth = true;
            }
            else if (Vector2.Distance(ballHolder.transform.position, stopPointRigth.transform.position) < holderStopDistance)
            {
                moveRigth = false;
            }
            if (moveRigth)
            {
                ballHolder.transform.position = Vector2.Lerp(ballHolder.transform.position, stopPointRigth.transform.position, holderSpeed);
            }
            else
            {
                ballHolder.transform.position = Vector2.Lerp(ballHolder.transform.position, stopPointLeft.transform.position, holderSpeed);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void Dunk()//This function is called when we score a goal
    {
        basketedBalls[goals].SetActive(true);
        goals++;
    }

    void DisableBaketedBalls()//hide the paper balls in the basket at the beginning
    {
        foreach (GameObject gameObject in basketedBalls)
        {
            gameObject.SetActive(false);
        }
    }

    void PlayerMessage(string message)//player comments during the game
    {
        DialogManager dialogManager = DialogManagerInstance.GetInstance();
        var dialogTexts = new List<DialogData>();
        DialogData dialogData;
        dialogData = new DialogData(message, "Li");
        dialogTexts.Add(dialogData);
        dialogData = new DialogData("Yo: " + goals + " | Cesto: " + (currentNumberOfAttemps - goals), "Li");
        dialogTexts.Add(dialogData);
        dialogManager.Show(dialogTexts);
    }
}
