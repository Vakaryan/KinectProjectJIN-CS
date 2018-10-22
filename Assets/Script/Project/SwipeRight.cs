using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRight : Move {



    public SwipeRight()
    {
        states = new List<State>();

        lastPose = new Skeleton();
        lastPose.body = new GameObject().transform;
        lastPose.leftElbow = new GameObject().transform;
        lastPose.leftHand = new GameObject().transform;
        lastPose.leftShoulder = new GameObject().transform;
        lastPose.leftWrist = new GameObject().transform;
        lastPose.neck = new GameObject().transform;
        lastPose.rightElbow = new GameObject().transform;
        lastPose.rightHand = new GameObject().transform;
        lastPose.rightShoulder = new GameObject().transform;
        lastPose.rightWrist = new GameObject().transform;

        Start();
    }



    // Use this for initialization
    override protected void Start ()
    {
        State tmp1 = new State();
        tmp1.move = new MoveRight();
        tmp1.move.linearTolerance = linearTolerance;
        states.Add(tmp1);
        State tmp2 = new State();
        tmp2.move = new MoveLeft();
        tmp2.move.linearTolerance = linearTolerance;
        states.Add(tmp2);



    }

    public override bool verify(Skeleton currentPose)
    {

        if (states[currentState].move.verify(lastPose.rightWrist, currentPose.rightWrist))
        {
            states[currentState].validate();

        }
        if (currentState == states.Count - 1 && states[currentState].validated)
        {
            reinitialize();
            return true;
        }
        else if(states[currentState].validated && states[currentState +1].move.verify(lastPose.rightWrist, currentPose.rightWrist))
        {
            currentState++;
        }





        return false;
    }

}
