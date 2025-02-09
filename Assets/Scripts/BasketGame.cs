using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasketGame : MonoBehaviour, IHistoryNode, IFlowControl
{
    [SerializeField] DialogTurnNode[] nextNodes;
    DialogTurnNode currentNextNode;
    bool finalized;
    [SerializeField] int numberOfAttemptsLimit;
    int currentNumberOfAttemps = 0, goals;
    float holderStopDistance = 0.7f;
    [SerializeField] Animator ballAnimator;
    bool moveRigth, enableThrow;
    [SerializeField] GameObject ballHolder, stopPointLeft, stopPointRigth, visual;
    [SerializeField] GameObject [] basketedBalls;


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

    public void ThrowBall()
    {
        if (enableThrow)
        {
            ballAnimator.SetTrigger("throwBall");
            StopCoroutine("HolderMovement");
            StartCoroutine("RestartBall");
            currentNumberOfAttemps++;
            if (currentNumberOfAttemps == numberOfAttemptsLimit)
            {
                if (goals > numberOfAttemptsLimit / 2)
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

    IEnumerator FinalizeDelay()
    {
        yield return new WaitForSeconds(2f);
        visual.SetActive(false);
        finalized = true;
    }

    IEnumerator RestartBall()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine("HolderMovement");
    }

    IEnumerator HolderMovement()
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
                ballHolder.transform.position = Vector2.Lerp(ballHolder.transform.position, stopPointRigth.transform.position, 0.007f);
            }
            else
            {
                ballHolder.transform.position = Vector2.Lerp(ballHolder.transform.position, stopPointLeft.transform.position, 0.007f);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void Dunk()
    {
        basketedBalls[goals].SetActive(true);
        goals++;
    }

    void DisableBaketedBalls()
    {
        foreach (GameObject gameObject in basketedBalls)
        {
            gameObject.SetActive(false);
        }
    }
}
