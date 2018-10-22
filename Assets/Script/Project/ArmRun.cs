using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRun : Move {

    protected class State
    {
        public ElementalMove moveLeft;
        public ElementalMove moveRight;
        public float minimalDistanceX = 0f;
        public float maximalDistanceX = 0f;
        public float minimalDistanceY = 0f;
        public float maximalDistanceY = 0f;
        public float minimalDistanceZ = 0f;
        public float maximalDistanceZ = 0f;
        public bool validated = false;
        public void validate() { validated = true; }
        public void unvalidate() { validated = false; }
    }

    List<State> states;


    public ArmRun(float newLinearTolerance)
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

        Start(newLinearTolerance);
    }

    override protected void Start(float newLinearTolerance)
    {
        State tmp1 = new State();
        tmp1.moveLeft = new MoveForward();
        tmp1.moveLeft.linearTolerance = newLinearTolerance;
        tmp1.moveRight = new MoveBackward();
        tmp1.moveRight.linearTolerance = newLinearTolerance;
        states.Add(tmp1);
        State tmp2 = new State();
        tmp2.moveLeft = new MoveBackward();
        tmp2.moveLeft.linearTolerance = newLinearTolerance;
        tmp2.moveRight = new MoveForward();
        tmp2.moveRight.linearTolerance = newLinearTolerance;
        states.Add(tmp2);
    }



    public override bool verify(Skeleton currentPose)
    {

        if (states[currentState].moveRight.verify(lastPose.rightElbow, currentPose.rightElbow) && states[currentState].moveLeft.verify(lastPose.leftElbow, currentPose.leftElbow))
        {
            states[currentState].validate();

        }
        if (currentState == states.Count - 1 && states[currentState].validated)
        {
            reinitialize();
            return true;
        }
        else if (states[currentState].validated && states[currentState + 1].moveRight.verify(lastPose.rightElbow, currentPose.rightElbow) && states[currentState + 1].moveLeft.verify(lastPose.leftElbow, currentPose.leftElbow))
        {
            currentState++;
        }

        UpdatePose(currentPose);




        return false;
    }


    protected override void reinitialize()
    {
        for (int i = 0; i < states.Count; i++)
        {
            states[i].unvalidate();
        }
        currentState = 0;
    }
}
