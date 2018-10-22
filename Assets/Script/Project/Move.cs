using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move {

    public float linearTolerance;

    protected class State
    {
        public ElementalMove move;
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

    protected List<State> states; 

    protected int currentState = 0;

    protected Skeleton lastPose;

    // Use this for initialization
    virtual protected void Start (float newLinearTolerance) {

    }
	
	virtual public bool verify(Skeleton currentPose)
    {
        return false;
    }

    protected void UpdatePose(Skeleton currentPose)
    {
        lastPose.body.position = currentPose.body.position;
        lastPose.leftElbow.position = currentPose.leftElbow.position;
        lastPose.leftHand.position = currentPose.leftHand.position;
        lastPose.leftShoulder.position = currentPose.leftShoulder.position;
        lastPose.leftWrist.position = currentPose.leftWrist.position;
        lastPose.neck.position = currentPose.neck.position;
        lastPose.rightElbow.position = currentPose.rightElbow.position;
        lastPose.rightHand.position = currentPose.rightHand.position;
        lastPose.rightShoulder.position = currentPose.rightShoulder.position;
        lastPose.rightWrist.position = currentPose.rightWrist.position;
    }

    protected virtual void reinitialize()
    {
        for (int i = 0; i < states.Count; i++)
        {
            states[i].unvalidate();
        }
        currentState = 0;
    }

}
