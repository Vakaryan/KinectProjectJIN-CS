using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeLeft : MonoBehaviour
{
    
    private Skeleton lastPose;
    private Skeleton currentPose;

    [SerializeField]
    private Vector3 treshold;
    /*
    struct States
    {
        public bool isStarted;
        public bool movesLeft;
        public bool passedRange;
        public bool movesRight;
    }
    private States states;*/

    private bool[] states;

    [SerializeField]
    private Vector3 range;




    void reinitialize()
    {
        foreach (bool i in states)
        {
        }
    }

    public bool watch(Skeleton skeletonPose)
    {
        currentPose = skeletonPose;

        


        lastPose = skeletonPose;

        return false;
    }

    private bool movesLeft()
    {
        return true;
    }
    private bool movesLeftOnly()
    {
        return true;
    }
    private bool movesRight()
    {
        return true;
    }
    private bool movesRightOnly()
    {
        return true;
    }
    private bool movesUp()
    {
        return true;
    }
    private bool movesUpOnly()
    {
        return true;
    }
    private bool movesDown()
    {
        return true;
    }
    private bool movesDownOnly()
    {
        return true;
    }
    private bool movesForward()
    {
        return true;
    }
    private bool movesForwardOnly()
    {
        return true;
    }
    private bool movesBack()
    {
        return true;
    }
    private bool movesBackOnly()
    {
        return true;
    }
    private bool stay()
    {
        return true;
    }



}
